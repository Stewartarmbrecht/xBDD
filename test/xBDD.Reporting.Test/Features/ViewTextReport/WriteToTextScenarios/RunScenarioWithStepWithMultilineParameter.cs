using System.Threading.Tasks;
using xBDD.Test;
namespace xBDD.Reporting.Test.Features.ViewTextReport.WriteToTextScenarios
{
    public class RunScenarioWithStepWithMultilineParameter : IExecute<string>
    {
        public async Task<string> Execute()
        {
            var xBDD = new xBDDMock();
            xBDD.CurrentRun.TestRun.Name = "My Test Run";
            await xBDD.CurrentRun
                .AddScenario("My Scenario", "My Feature", "My.Area.Path")
                .Given(xBDD.CreateStep("my starting condition with the following", (s) => { }, $"My{System.Environment.NewLine}multiline{System.Environment.NewLine}parameter"))
                .When(xBDD.CreateStep("my action"))
                .Then(xBDD.CreateStep("my ending condition"))
                .Run();
            return await xBDD.CurrentRun.TestRun.WriteToText();
        }
    }
}
