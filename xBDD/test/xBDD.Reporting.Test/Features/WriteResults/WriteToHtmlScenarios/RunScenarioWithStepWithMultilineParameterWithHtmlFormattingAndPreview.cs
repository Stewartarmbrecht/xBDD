using xBDD.Test;
namespace xBDD.Reporting.Test.Features.WriteResults.WriteToHtmlScenarios
{
    public class RunScenarioWithStepWithMultilineParameterWithHtmlFormattingAndPreview : IExecute<string>
    {
        public string Execute()
        {
            var xBDD = new xBDDMock();
            xBDD.CurrentRun.TestRun.Name = "My Test Run";
            xBDD.CurrentRun
                .AddScenario("My Scenario", "My Feature", "My.Area.Path")
                .Given(xBDD.CreateStep(
                    "my starting condition with the following", 
                    () => { }, 
                    "My\r\n  multiline\r\n    parameter"))
                .And(xBDD.CreateStep(
                    "my formatted genric code",
                    () => { },
                    "public void MyClass {}",
                    MultilineParameterFormat.code))
                .And(xBDD.CreateStep(
                    "my formatted specific code (html)",
                    () => { },
                    "<table>\r\n    <tr>\r\n        <td>\r\n            Hey\r\n        </td>\r\n    </tr>\r\n</table>",
                    MultilineParameterFormat.htmlpreview))
                .When(xBDD.CreateStep("my action"))
                .Then(xBDD.CreateStep("my ending condition"))
                .Run();
            return xBDD.CurrentRun.TestRun.WriteToHtml();
        }
    }
}
