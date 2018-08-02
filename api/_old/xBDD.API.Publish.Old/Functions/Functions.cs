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
                req.TestRun.RowKey = req.TestRun.Id.ToString();
                req.TestRun.PartitionKey = req.TestRun.ConfigurationId.ToString();
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
                foreach(var scenario in req.Scenarios)
                {
                    scenario.RowKey = scenario.Id.ToString();
                    scenario.PartitionKey = scenario.TestRunId.ToString();
                    scenarios.Add(scenario);
                    foreach(var step in scenario.Steps)
                    {
                        steps.Add(step);
                    }
                }
                return new OkObjectResult(req.Scenarios);
            } 
            catch (Exception ex) 
            {
                var res = new {req, ex};
                return new BadRequestObjectResult(res);
            }
        }
    }
}
