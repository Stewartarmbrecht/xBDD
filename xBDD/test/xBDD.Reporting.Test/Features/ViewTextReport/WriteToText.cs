using System.Runtime.CompilerServices;
using Xunit;
using Xunit.Abstractions;
using xBDD.Test;
using xBDD.xUnit;
using xBDD.Reporting.Test.Steps;

namespace xBDD.Reporting.Test.Features.ViewTextReport
{
    [Collection("xBDDReportingTest")]
    public class WriteToText
    {
        private readonly OutputWriter outputWriter;

        public WriteToText(ITestOutputHelper output)
        {
            outputWriter = new OutputWriter(output);
        }

        public void Run(IExecute<string> action, bool writeActual = false, [CallerMemberName]string methodName = "")
        {
            var actionName = action.GetType().Name;
            Wrapper<string> text = new Wrapper<string>();
            xB.CurrentRun
                .AddScenario(this, methodName)
                .SetOutputWriter(outputWriter)
                .Given(Code.HasTheFollowingScenario("\\Features\\ViewTextReport\\WriteToTextScenarios\\" + actionName + ".cs"))
                .When(Code.IsExecuted((s) =>
                {
                    text.Object = action.Execute();
                }))
                .Then(TextReport.ShouldMatch(
                    "\\Features\\ViewTextReport\\WriteToTextScenarios\\" + actionName + ".txt", text, writeActual))
                .Run();
        }

        [ScenarioFact]
        public void WriteEmtpyTestRun()
        {
            Run(new WriteToTextScenarios.EmptyTestRun());
        }
        [ScenarioFact]
        public void WriteSkippedEmptyScenario()
        {
            Run(new WriteToTextScenarios.SkippedEmptyScenario());
        }
        [ScenarioFact]
        public void WriteRunEmptyScenario()
        {
            Run(new WriteToTextScenarios.RunEmptyScenario());
        }
        [ScenarioFact]
        public void WriteSkippedScenarioWithSteps()
        {
            Run(new WriteToTextScenarios.SkippedScenarioWithSteps());
        }
        [ScenarioFact]
        public void WriteRunScenarioWithSteps()
        {
            Run(new WriteToTextScenarios.RunScenarioWithSteps());
        }
        [ScenarioFact]
        public void WriteRunScenarioWithSkippedStep()
        {
            Run(new WriteToTextScenarios.RunScenarioWithSkippedStep());
        }
        [ScenarioFact]
        public void WriteRunScenarioWithNotImplementedStep()
        {
            Run(new WriteToTextScenarios.RunScenarioWithNotImplementedStep());
        }
        [ScenarioFact]
        public void WriteRunScenarioWithFailedStep()
        {
            Run(new WriteToTextScenarios.RunScenarioWithFailedStep());
        }
        [ScenarioFact]
        public void WriteRunMultipleScenariosSameFeature()
        {
            Run(new WriteToTextScenarios.RunMultipleScenariosSameFeature());
        }
        [ScenarioFact]
        public void WriteRunMultipleFeaturesSameArea()
        {
            Run(new WriteToTextScenarios.RunMultipleFeaturesSameArea());
        }
        [ScenarioFact]
        public void WriteRunMultipleAreas()
        {
            Run(new WriteToTextScenarios.RunMultipleAreas());
        }
        [ScenarioFact]
        public void WriteRunScenarioWithStepWithMultilineParameter()
        {
            Run(new WriteToTextScenarios.RunScenarioWithStepWithMultilineParameter());
        }
    }
}
