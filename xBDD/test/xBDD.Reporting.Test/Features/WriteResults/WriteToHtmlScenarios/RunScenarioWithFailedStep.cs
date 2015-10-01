using System;
using xBDD.Test;
namespace xBDD.Reporting.Test.Features.WriteResults.WriteToHtmlScenarios
{
    public class RunScenarioWithFailedStep : IExecute<string>
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
                    .When(xBDD.CreateStep("my action", (s) => { throw new Exception("My Error"); }))
                    .Then(xBDD.CreateStep("my ending condition"))
                    .Run();
            }
            catch { }
            return xBDD.CurrentRun.TestRun.WriteToHtml();
        }
    }
}
