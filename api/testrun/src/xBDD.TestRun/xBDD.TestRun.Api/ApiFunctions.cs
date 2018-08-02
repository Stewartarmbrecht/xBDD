using System;
using System.IO;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;
using xBDD.Shared;
using xBDD.Shared.UserAuthentication;
using xBDD.TestRun.Services;
using xBDD.TestRun.Services.Converters;
using xBDD.TestRun.Services.Models.Requests;
using xBDD.TestRun.Services.Models.Results;
using xBDD.TestRun.Services.Repositories;

namespace xBDD.TestRun.Api
{
    public static class ApiFunctions
    {
        private const string JsonContentType = "application/json";
        public static ITestRunService TestRunService = new TestRunService(new TestRunRepository(), new EventGridPublisherService());
        public static IUserAuthenticationService UserAuthenticationService = new QueryStringUserAuthenticationService();

        [FunctionName("AddTestRun")]
        public static async Task<IActionResult> AddTestRun(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "testrun")]HttpRequest req,
            TraceWriter log)
        {
            // get the request body
            var requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            CreateTestRunRequest data;
            try
            {
                data = JsonConvert.DeserializeObject<CreateTestRunRequest>(requestBody);
            }
            catch (JsonReaderException)
            {
                return new BadRequestObjectResult(new { error = "Body should be provided in JSON format." });
            }

            // validate request
            if (data == null)
            {
                return new BadRequestObjectResult(new { error = "Missing required properties 'testrun', and 'categoryId'." });
            }
            else if (string.IsNullOrEmpty(data.TestRun))
            {
                return new BadRequestObjectResult(new { error = "Missing required property 'testrun'." });
            }
            else if (string.IsNullOrEmpty(data.CategoryId))
            {
                return new BadRequestObjectResult(new { error = "Missing required property 'categoryId'." });
            }

            // get the user ID
            if (! await UserAuthenticationService.GetUserIdAsync(req, out var userId, out var responseResult))
            {
                return responseResult;
            }

            // create testrun
            try
            {
                var testrunId = await TestRunService.AddTestRunAsync(data.TestRun, userId, data.CategoryId);
                return new OkObjectResult(new { id = testrunId });
            }
            catch (Exception ex)
            {
                log.Error("Unhandled exception", ex);
                return new ExceptionResult(ex, false);
            }
        }

        [FunctionName("DeleteTestRun")]
        public static async Task<IActionResult> DeleteTestRun(
            [HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "testrun/{id}")]HttpRequest req,
            TraceWriter log,
            string id)
        {
            // validate request
            if (string.IsNullOrEmpty(id))
            {
                return new BadRequestObjectResult(new { error = "Missing required argument 'id'." });
            }

            // get the user ID
            if (! await UserAuthenticationService.GetUserIdAsync(req, out var userId, out var responseResult))
            {
                return responseResult;
            }

            // delete testrun
            try
            {
                await TestRunService.DeleteTestRunAsync(id, userId); // we ignore the result of this call - whether it's Success or NotFound, we return an 'Ok' back to the client
                return new NoContentResult();
            }
            catch (Exception ex)
            {
                log.Error("Unhandled exception", ex);
                return new ExceptionResult(ex, false);
            }
        }

        [FunctionName("UpdateTestRun")]
        public static async Task<IActionResult> UpdateTestRun(
            [HttpTrigger(AuthorizationLevel.Anonymous, "patch", Route = "testrun/{id}")]HttpRequest req,
            TraceWriter log,
            string id)
        {
            // get the request body
            var requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            UpdateTestRunRequest data;
            try
            {
                data = JsonConvert.DeserializeObject<UpdateTestRunRequest>(requestBody);
            }
            catch (JsonReaderException)
            {
                return new BadRequestObjectResult(new { error = "Body should be provided in JSON format." });
            }

            // validate request
            if (data == null)
            {
                return new BadRequestObjectResult(new { error = "Missing required properties 'userId' and 'testrun'." });
            }
            if (data.Id != null && id != null && data.Id != id)
            {
                return new BadRequestObjectResult(new { error = "Property 'id' does not match the identifier specified in the URL path." });
            }
            if (string.IsNullOrEmpty(data.Id))
            {
                data.Id = id;
            }
            if (string.IsNullOrEmpty(data.TestRun))
            {
                return new BadRequestObjectResult(new { error = "Missing required property 'testrun'." });
            }

            // get the user ID
            if (! await UserAuthenticationService.GetUserIdAsync(req, out var userId, out var responseResult))
            {
                return responseResult;
            }

            // update testrun
            try
            {
                var result = await TestRunService.UpdateTestRunAsync(data.Id, userId, data.TestRun);
                if (result == UpdateTestRunResult.NotFound)
                {
                    return new NotFoundResult();
                }

                return new NoContentResult();
            }
            catch (Exception ex)
            {
                log.Error("Unhandled exception", ex);
                return new ExceptionResult(ex, false);
            }
        }
        
        [FunctionName("GetTestRun")]
        public static async Task<IActionResult> GetTestRun(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "testrun/{id}")]HttpRequest req,
            TraceWriter log,
            string id)
        {
            // get the user ID
            if (! await UserAuthenticationService.GetUserIdAsync(req, out var userId, out var responseResult))
            {
                return responseResult;
            }

            // get the testrun note
            try
            {
                var document = await TestRunService.GetTestRunAsync(id, userId);
                if (document == null)
                {
                    return new NotFoundResult();
                }

                return new OkObjectResult(document);
            }
            catch (Exception ex)
            {
                log.Error("Unhandled exception", ex);
                return new ExceptionResult(ex, false);
            }
        }

        [FunctionName("ListTestRun")]
        public static async Task<IActionResult> ListTestRun(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "testrun")]HttpRequest req,
            TraceWriter log)
        {
            // get the user ID
            if (! await UserAuthenticationService.GetUserIdAsync(req, out var userId, out var responseResult))
            {
                return responseResult;
            }

            // lilst the testrun notes
            try
            {
                var summaries = await TestRunService.ListTestRunsAsync(userId);
                if (summaries == null)
                {
                    return new NotFoundResult();
                }

                // serialise the summaries using a custom converter
                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    Formatting = Formatting.Indented
                };
                settings.Converters.Add(new TestRunSummariesConverter());
                var json = JsonConvert.SerializeObject(summaries, settings);

                return new ContentResult
                {
                    Content = json,
                    ContentType = JsonContentType,
                    StatusCode = StatusCodes.Status200OK
                };
            }
            catch (Exception ex)
            {
                log.Error("Unhandled exception", ex);
                return new ExceptionResult(ex, false);
            }
        }
    }
}
