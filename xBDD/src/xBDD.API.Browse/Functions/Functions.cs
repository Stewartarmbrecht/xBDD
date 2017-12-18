using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.WindowsAzure.Storage.Table;
using Newtonsoft.Json;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using xBDD.API.Model.Messages;
using xBDD.API.Model.Events;
using xBDD.API.Model.Entities;

namespace xBDD.API.Browse
{
    public class Functions
    {
        public static IActionResult GetTestRuns(GetTestRunsRequest req,  CloudTable testRunBinding, TraceWriter log)
        {
            log.Info("Processing GetTestRuns.");
            try 
            {
            TableQuery<TestRun> tq = new TableQuery().Where(TableQuery.GenerateFilterCondition("PartitionKey",QueryComparisons.Equal,req.ConfigurationId));
                return new OkObjectResult(testRunBinding.);
            } 
            catch (Exception ex) 
            {
                testRunBinding = null;
                var res = new {req, ex};
                return new BadRequestObjectResult(res);
            }
        }
        [FunctionName("GetScenarios")]
        public static IActionResult GetScenarios(GetScenarioBatchRequest req, [Table("testrun")] IQueryable<Scenario> scenariosBinding, [Table("testrun")] IQueryable<Step> stepsBinding, TraceWriter log)
        {
            log.Info("Processing Scenario Batch Publish.");
            try 
            {
                return new OkObjectResult(scenariosBinding.AsQueryable().ToList());
            } 
            catch (Exception ex) 
            {
                var res = new {req, ex};
                return new BadRequestObjectResult(res);
            }
        }
    }
}
