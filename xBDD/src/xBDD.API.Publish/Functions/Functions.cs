using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;
using System.Linq;
using System.Threading.Tasks;
using xBDD.API.Model.Messages;
using xBDD.API.Model.Events;
using xBDD.API.Model.Entities;

namespace xBDD.API.Publish
{
    public class Functions
    {
        public static IActionResult TestRun(PublishTestRunRequest req, out TestRun testRun, TraceWriter log)
        {
            log.Info("Processing TestRun Publish.");
            try 
            {
                var testRunPublishedEvent = new TestRunPublishedEvent()
                {
                    TestRun = req.TestRun
                };
                var json = JsonConvert.SerializeObject(testRunPublishedEvent);
                testRun = req.TestRun;
                return new OkObjectResult(req.TestRun);
            } 
            catch (Exception ex) 
            {
                testRun = null;
                var res = new {req, ex};
                return new BadRequestObjectResult(res);
            }
        }
        public static IActionResult Scenario(PublishScenarioBatchRequest req, ICollector<Scenario> scenarios, ICollector<Step> steps, TraceWriter log)
        {
            log.Info("Processing Scenario Batch Publish.");
            try 
            {
                var scenarioBatchPublishedEvent = new ScenarioBatchPublishedEvent()
                {
                    Scenarios = req.Scenarios
                };
                var json = JsonConvert.SerializeObject(scenarioBatchPublishedEvent);
                foreach(var scenario in req.Scenarios)
                {
                    scenarios.Add(scenario);
                    foreach(var step in scenario.Steps)
                    {
                        steps.Add(step);
                    }
                }
                return new OkObjectResult(scenarioBatchPublishedEvent);
            } 
            catch (Exception ex) 
            {
                var res = new {req, ex};
                return new BadRequestObjectResult(res);
            }
        }
    }
}
