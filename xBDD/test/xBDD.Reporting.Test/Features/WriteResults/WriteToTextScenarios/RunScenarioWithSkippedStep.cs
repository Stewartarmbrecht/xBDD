﻿using xBDD.Test;
namespace xBDD.Reporting.Test.Features.WriteResults.WriteToTextScenarios
{
    public class RunScenarioWithSkippedStep : IExecute<string>
    {
        public string Execute()
        {
            var xBDD = new xBDDMock();
            xBDD.CurrentRun.TestRun.Name = "My Test Run";
            try
            {
                xBDD.CurrentRun
                    .AddScenario("My Scenario", "My Feature", "My.Area.Path")
                    .Given(xBDD.CreateStep("my starting condition"))
                    .When(xBDD.CreateStep("my action", (s) => { throw new SkipStepException("Deferred"); }))
                    .Then(xBDD.CreateStep("my ending condition"))
                    .Run();
            }
            catch { }
            return xBDD.CurrentRun.TestRun.WriteToText();
        }
    }
}