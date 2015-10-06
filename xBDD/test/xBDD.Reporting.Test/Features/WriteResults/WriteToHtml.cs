using Xunit;
using Xunit.Abstractions;
using xBDD.xUnit;

namespace xBDD.Reporting.Test.Features.WriteResults
{
    [Collection("xBDDReportingTest")]
    public class WriteToHtml
    {
        private readonly OutputWriter outputWriter;

        public WriteToHtml(ITestOutputHelper output)
        {
            outputWriter = new OutputWriter(output);
        }

        //  public void Run(IExecute<string> action, bool writeActual = false, [CallerMemberName]string methodName = "")
        //  {
        //      var actionName = action.GetType().Name;
        //      Wrapper<string> text = new Wrapper<string>();
        //      xBDD.CurrentRun
        //          .AddScenario(this, methodName)
        //          .SetOutputWriter(outputWriter)
        //          .Given(Code.HasMethod("\\Features\\WriteResults\\WriteToHtmlScenarios\\" + actionName + ".cs"))
        //          .When(Code.ExecuteMethod((s) =>
        //          {
        //              text.Object = action.Execute();
        //          }))
        //          .Then(HtmlReport.ShouldMatch(
        //              "\\Features\\WriteResults\\WriteToHtmlScenarios\\" + actionName + ".html", text, writeActual, "html", TextFormat.htmlpreview))
        //          .Run();
        //  }

        //  [ScenarioFact]
        //  public void WriteEmtpyTestRun()
        //  {
        //      Run(new WriteToHtmlScenarios.EmptyTestRun());
        //  }
        //  [ScenarioFact]
        //  public void WriteRunEmptyScenario()
        //  {
        //      Run(new WriteToHtmlScenarios.RunEmptyScenario());
        //  }
        //  [ScenarioFact]
        //  public void WriteSkippedEmptyScenario()
        //  {
        //      Run(new WriteToHtmlScenarios.SkippedEmptyScenario());
        //  }
        //  [ScenarioFact]
        //  public void WriteSkippedScenarioWithSteps()
        //  {
        //      Run(new WriteToHtmlScenarios.SkippedScenarioWithSteps());
        //  }
        //  [ScenarioFact]
        //  public void WriteRunScenarioWithSteps()
        //  {
        //      Run(new WriteToHtmlScenarios.RunScenarioWithSteps());
        //  }
        //  [ScenarioFact]
        //  public void WriteRunScenarioWithSkippedStep()
        //  {
        //      Run(new WriteToHtmlScenarios.RunScenarioWithSkippedStep());
        //  }
        //  [ScenarioFact]
        //  public void WriteRunScenarioWithNotImplementedStep()
        //  {
        //      Run(new WriteToHtmlScenarios.RunScenarioWithNotImplementedStep());
        //  }
        //  [ScenarioFact]
        //  public void WriteRunScenarioWithFailedStep()
        //  {
        //      Run(new WriteToHtmlScenarios.RunScenarioWithFailedStep());
        //  }
        //  [ScenarioFact]
        //  public void WriteRunMultipleWriteToHtmlScenariosSameFeature()
        //  {
        //      Run(new WriteToHtmlScenarios.RunMultipleScenariosSameFeature());
        //  }
        //  [ScenarioFact]
        //  public void WriteRunMultipleFeaturesSameArea()
        //  {
        //      Run(new WriteToHtmlScenarios.RunMultipleFeaturesSameArea());
        //  }
        //  [ScenarioFact]
        //  public void WriteRunMultipleAreas()
        //  {
        //      Run(new WriteToHtmlScenarios.RunMultipleAreas());
        //  }
        //  [ScenarioFact]
        //  public void WriteRunScenarioWithStepWithMultilineParameter()
        //  {
        //      Run(new WriteToHtmlScenarios.RunScenarioWithStepWithMultilineParameter());
        //  }
        //  [ScenarioFact]
        //  public void WriteRunScenarioWithStepWithMultilineParameterWithFormatting()
        //  {
        //      Run(new WriteToHtmlScenarios.RunScenarioWithStepWithMultilineParameterWithFormatting());
        //  }
        //  [ScenarioFact]
        //  public void WriteRunScenarioWithStepWithMultilineParameterWithHtmlFormattingAndPreview()
        //  {
        //      Run(new WriteToHtmlScenarios.RunScenarioWithStepWithMultilineParameterWithHtmlFormattingAndPreview());
        //  }
    }
}
