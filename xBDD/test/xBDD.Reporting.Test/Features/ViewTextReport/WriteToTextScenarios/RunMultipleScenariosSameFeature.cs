﻿using xBDD.Test;
namespace xBDD.Reporting.Test.Features.ViewTextReport.WriteToTextScenarios
{
    public class RunMultipleScenariosSameFeature : IExecute<string>
    {
        public string Execute()
        {
            var xBDD = new xBDDMock();
            xBDD.CurrentRun.TestRun.Name = "My Test Run";
            try
            {
                xBDD.CurrentRun
                    .AddScenario("My Scenario One", "My Feature", "My.Area.Path")
                    .Given(xBDD.CreateStep("my starting condition"))
                    .When(xBDD.CreateStep("my action"))
                    .Then(xBDD.CreateStep("my ending condition"))
                    .Run();
                xBDD.CurrentRun
                    .AddScenario("My Scenario Two", "My Feature", "My.Area.Path")
                    .Given(xBDD.CreateStep("my starting condition"))
                    .When(xBDD.CreateStep("my action"))
                    .Then(xBDD.CreateStep("my ending condition"))
                    .Run();
            }
            catch { }
            return xBDD.CurrentRun.TestRun.WriteToText();
        }
    }
}
