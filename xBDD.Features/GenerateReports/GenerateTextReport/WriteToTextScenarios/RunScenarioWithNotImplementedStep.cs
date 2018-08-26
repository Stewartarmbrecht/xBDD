﻿using System;
using System.Threading.Tasks;
using xBDD.Features;

namespace xBDD.Features.GenerateReports.GenerateTextReport.WriteToTextScenarios
{
    public class RunScenarioWithNotImplementedStep : IExecute<string>
    {
        public async Task<string> Execute()
        {
            var xBDD = new xBDDMock();
            xBDD.CurrentRun.TestRun.Name = "My Test Run";
            try
            {
                await xBDD.CurrentRun
                    .AddScenario("My Scenario", "My Feature", "My.Area.Path")
                    .Given(xBDD.CreateStep("my starting condition"))
                    .When(xBDD.CreateStep("my action", (s) => { throw new NotImplementedException(); }))
                    .Then(xBDD.CreateStep("my ending condition"))
                    .Run();
            }
            catch { }
            return xBDD.CurrentRun.TestRun.WriteToText();
        }
    }
}
