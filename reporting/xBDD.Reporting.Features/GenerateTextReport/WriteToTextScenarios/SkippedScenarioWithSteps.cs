using System.Threading.Tasks;
using xBDD.Test;
namespace xBDD.Reporting.Features.GenerateTextReport.WriteToTextScenarios
{
    public class SkippedScenarioWithSteps : IExecute<string>
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
                    .When(xBDD.CreateStep("my action"))
                    .Then(xBDD.CreateStep("my ending condition"))
                    .Skip("Deferred");
            }
            catch { }
            return await xBDD.CurrentRun.TestRun.WriteToText();
        }
    }
}
