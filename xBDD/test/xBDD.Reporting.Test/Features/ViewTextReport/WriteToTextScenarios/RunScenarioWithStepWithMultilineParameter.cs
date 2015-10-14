using xBDD.Test;
namespace xBDD.Reporting.Test.Features.ViewTextReport.WriteToTextScenarios
{
    public class RunScenarioWithStepWithMultilineParameter : IExecute<string>
    {
        public string Execute()
        {
            var xBDD = new xBDDMock();
            xBDD.CurrentRun.TestRun.Name = "My Test Run";
            xBDD.CurrentRun
                .AddScenario("My Scenario", "My Feature", "My.Area.Path")
                .Given(xBDD.CreateStep("my starting condition with the following", (s) => { }, "My\r\nmultiline\r\nparameter"))
                .When(xBDD.CreateStep("my action"))
                .Then(xBDD.CreateStep("my ending condition"))
                .Run();
            return xBDD.CurrentRun.TestRun.WriteToText();
        }
    }
}
