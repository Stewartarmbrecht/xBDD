using System.Threading.Tasks;
using xBDD.Test;
namespace xBDD.Reporting.Features.ViewTextReport.WriteToTextScenarios
{
    public class RunMultipleFeaturesSameArea : IExecute<string>
    {
        public async Task<string> Execute()
        {
            var xBDD = new xBDDMock();
            xBDD.CurrentRun.TestRun.Name = "My Test Run";
            try
            {
                await xBDD.CurrentRun
                    .AddScenario("My Scenario One", "My Feature One", "My.Area.Path")
                    .Given(xBDD.CreateStep("my starting condition"))
                    .When(xBDD.CreateStep("my action"))
                    .Then(xBDD.CreateStep("my ending condition"))
                    .Run();
                await xBDD.CurrentRun
                    .AddScenario("My Scenario Two", "My Feature One", "My.Area.Path")
                    .Given(xBDD.CreateStep("my starting condition"))
                    .When(xBDD.CreateStep("my action"))
                    .Then(xBDD.CreateStep("my ending condition"))
                    .Run();
                await xBDD.CurrentRun
                    .AddScenario("My Scenario One", "My Feature Two", "My.Area.Path")
                    .Given(xBDD.CreateStep("my starting condition"))
                    .When(xBDD.CreateStep("my action"))
                    .Then(xBDD.CreateStep("my ending condition"))
                    .Run();
                await xBDD.CurrentRun
                    .AddScenario("My Scenario Two", "My Feature Two", "My.Area.Path")
                    .Given(xBDD.CreateStep("my starting condition"))
                    .When(xBDD.CreateStep("my action"))
                    .Then(xBDD.CreateStep("my ending condition"))
                    .Run();
            }
            catch { }
            return await xBDD.CurrentRun.TestRun.WriteToText();
        }
    }
}
