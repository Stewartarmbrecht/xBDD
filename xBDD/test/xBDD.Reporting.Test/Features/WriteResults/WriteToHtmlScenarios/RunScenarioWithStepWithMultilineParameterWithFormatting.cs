using xBDD.Test;
namespace xBDD.Reporting.Test.Features.WriteResults.WriteToHtmlScenarios
{
    public class RunScenarioWithStepWithMultilineParameterWithFormatting : IExecute<string>
    {
        public string Execute()
        {
            var xBDD = new xBDDMock();
            xBDD.CurrentRun.TestRun.Name = "My Test Run";
            xBDD.CurrentRun
                .AddScenario("My Scenario", "My Feature", "My.Area.Path")
                .Given(xBDD.CreateStep(
                    "my starting condition with the following", 
                    (s) => { }, 
                    "My\r\n  multiline\r\n    parameter"))
                .And(xBDD.CreateStep(
                    "my formatted genric code",
                    (s) => { },
                    "public void MyClass {}",
                    TextFormat.code))
                .And(xBDD.CreateStep(
                    "my formatted specific code (html)",
                    (s) => { },
                    "<table><tr><td>Hey</td></tr></table>",
                    TextFormat.html))
                .When(xBDD.CreateStep("my action"))
                .Then(xBDD.CreateStep("my ending condition"))
                .Run();
            return xBDD.CurrentRun.TestRun.WriteToHtml();
        }
    }
}
