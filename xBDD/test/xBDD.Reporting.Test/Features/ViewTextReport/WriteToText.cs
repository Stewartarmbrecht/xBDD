using System.Runtime.CompilerServices;
using Xunit;
using Xunit.Abstractions;
using xBDD.Test;
using xBDD.xUnit;
using xBDD.Reporting.Test.Steps;
using System.Threading.Tasks;

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

        public async Task Run(IExecute<string> action, bool writeActual = false, [CallerMemberName]string methodName = "")
        {
            var actionName = action.GetType().Name;
            Wrapper<string> text = new Wrapper<string>();
            await xB.CurrentRun
                .AddScenario(this, methodName)
                .SetOutputWriter(outputWriter)
                .Given(Code.HasTheFollowingScenario("\\Features\\ViewTextReport\\WriteToTextScenarios\\" + actionName + ".cs"))
                .When(Code.IsExecuted(async (s) =>
                {
                    text.Object = await action.Execute();
                }))
                .Then(TextReport.ShouldMatch(
                    "\\Features\\ViewTextReport\\WriteToTextScenarios\\" + actionName + ".txt", text, writeActual))
                .Run();
        }

        [ScenarioFact]
        public async Task WriteEmtpyTestRun()
        {
            await Run(new  WriteToTextScenarios.EmptyTestRun());
        }
        [ScenarioFact]
        public async Task WriteSkippedEmptyScenario()
        {
            await Run(new  WriteToTextScenarios.SkippedEmptyScenario());
        }
        [ScenarioFact]
        public async Task WriteRunEmptyScenario()
        {
            await Run(new  WriteToTextScenarios.RunEmptyScenario());
        }
        [ScenarioFact]
        public async Task WriteSkippedScenarioWithSteps()
        {
            await Run(new  WriteToTextScenarios.SkippedScenarioWithSteps());
        }
        [ScenarioFact]
        public async Task WriteRunScenarioWithSteps()
        {
            await Run(new  WriteToTextScenarios.RunScenarioWithSteps());
        }
        [ScenarioFact]
        public async Task WriteRunScenarioWithSkippedStep()
        {
            await Run(new  WriteToTextScenarios.RunScenarioWithSkippedStep());
        }
        [ScenarioFact]
        public async Task WriteRunScenarioWithNotImplementedStep()
        {
            await Run(new  WriteToTextScenarios.RunScenarioWithNotImplementedStep());
        }
        [ScenarioFact]
        public async Task WriteRunScenarioWithFailedStep()
        {
            await Run(new  WriteToTextScenarios.RunScenarioWithFailedStep());
        }
        [ScenarioFact]
        public async Task WriteRunMultipleScenariosSameFeature()
        {
            await Run(new  WriteToTextScenarios.RunMultipleScenariosSameFeature());
        }
        [ScenarioFact]
        public async Task WriteRunMultipleFeaturesSameArea()
        {
            await Run(new  WriteToTextScenarios.RunMultipleFeaturesSameArea());
        }
        [ScenarioFact]
        public async Task WriteRunMultipleAreas()
        {
            await Run(new  WriteToTextScenarios.RunMultipleAreas());
        }
        [ScenarioFact]
        public async Task WriteRunScenarioWithStepWithMultilineParameter()
        {
            await Run(new  WriteToTextScenarios.RunScenarioWithStepWithMultilineParameter());
        }
    }
}
