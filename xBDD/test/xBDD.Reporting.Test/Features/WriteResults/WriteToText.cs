using System;
using System.Runtime.CompilerServices;
using xBDD.Reporting.Test.Steps;
using xBDD.Test;
using xBDD.xUnit;
using Xunit;
using Xunit.Abstractions;

namespace xBDD.Reporting.Test.Features.WriteResults
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
            xBDD.CurrentRun
                .AddScenario(this, methodName)
                .SetOutputWriter(outputWriter)
                .Given(Code.HasMethod("\\Features\\WriteResults\\WriteToTextScenarios\\" + actionName + ".cs"))
                .When(Code.ExecuteMethod(() =>
                {
                    text.Object = action.Execute();
                }))
                .Then(TestResults.ShouldMatch(
                    "\\Features\\WriteResults\\WriteToTextScenarios\\" + actionName + ".txt", text, writeActual))
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
