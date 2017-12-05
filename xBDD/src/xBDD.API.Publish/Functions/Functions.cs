using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using System.Linq;

namespace xBDD.API.Publish
{
    public class Functions
    {
        public static void TestRun(HttpRequest req, TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");

            using(System.IO.StreamReader reader = new System.IO.StreamReader(req.Body))
            {
                log.Info(reader.ReadToEnd());
            }
        }
        public static void Scenario(HttpRequest req, TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");

            using(System.IO.StreamReader reader = new System.IO.StreamReader(req.Body))
            {
                log.Info(reader.ReadToEnd());
            }
        }
    }
}
