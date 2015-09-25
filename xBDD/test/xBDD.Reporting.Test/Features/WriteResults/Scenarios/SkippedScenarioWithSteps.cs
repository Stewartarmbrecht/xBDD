using xBDD.Test;
namespace xBDD.Reporting.Test.Features.WriteResults.Scenarios
{
    public class SkippedScenarioWithSteps : IExecute<string>
    {
        public string Execute()
        {
            var xBDD = new xBDDMock();
            xBDD.CurrentRun.Name = "My Test Run";
            try
            {
                xBDD.CurrentRun
                    .AddScenario("My Scenario", "My Feature", "My.Area.Path")
                    .Given(xBDD.CreateStep("my starting condition"))
                    .When(xBDD.CreateStep("my action"))
                    .Then(xBDD.CreateStep("my ending condition"))
                    .Skip("Deferred");
            }
            catch { }
            return xBDD.CurrentRun.WriteToText();
        }
    }
}
