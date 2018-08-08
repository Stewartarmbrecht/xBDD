using System.Runtime.CompilerServices;
//using Xunit;
//using Xunit.Abstractions;
using xBDD.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using xBDD.Reporting.Features.Steps;
using System.Threading.Tasks;

namespace xBDD.Reporting.Features.GenerateTextReport
{
    [TestClass]
    public class WriteToText
    {
        private readonly TestContextWriter outputWriter;

        public WriteToText()
        {
            outputWriter = new TestContextWriter();
        }

        public async Task Run(IExecute<string> action, bool writeActual = false, [CallerMemberName]string methodName = "")
        {
            var actionName = action.GetType().Name;
            Wrapper<string> text = new Wrapper<string>();
			var seperator = System.IO.Path.DirectorySeparatorChar;
			var scenarioPath = $"{seperator}GenerateTextReport{seperator}WriteToTextScenarios{seperator}";

            await xB.CurrentRun
                .AddScenario(this, methodName)
                .SetOutputWriter(outputWriter)
                .Given(Code.HasTheFollowingScenario(scenarioPath + actionName + ".cs"))
                .When(Code.IsExecuted(async (s) =>
                {
                    text.Object = await action.Execute();
                }))
                .Then(TextReport.ShouldMatch(
                    scenarioPath + actionName + ".txt", text, writeActual))
                .Run();
        }

        [TestMethod]
        public async Task WriteEmtpyTestRun()
        {
            await Run(new  WriteToTextScenarios.EmptyTestRun());
        }
        [TestMethod]
        public async Task WriteSkippedEmptyScenario()
        {
            await Run(new  WriteToTextScenarios.SkippedEmptyScenario());
        }
        [TestMethod]
        public async Task WriteRunEmptyScenario()
        {
            await Run(new  WriteToTextScenarios.RunEmptyScenario());
        }
        [TestMethod]
        public async Task WriteSkippedScenarioWithSteps()
        {
            await Run(new  WriteToTextScenarios.SkippedScenarioWithSteps());
        }
        [TestMethod]
        public async Task WriteRunScenarioWithSteps()
        {
            await Run(new  WriteToTextScenarios.RunScenarioWithSteps());
        }
        [TestMethod]
        public async Task WriteRunScenarioWithSkippedStep()
        {
            await Run(new  WriteToTextScenarios.RunScenarioWithSkippedStep());
        }
        [TestMethod]
        public async Task WriteRunScenarioWithNotImplementedStep()
        {
            await Run(new  WriteToTextScenarios.RunScenarioWithNotImplementedStep());
        }
        [TestMethod]
        public async Task WriteRunScenarioWithFailedStep()
        {
            await Run(new  WriteToTextScenarios.RunScenarioWithFailedStep());
        }
        [TestMethod]
        public async Task WriteRunMultipleScenariosSameFeature()
        {
            await Run(new  WriteToTextScenarios.RunMultipleScenariosSameFeature());
        }
        [TestMethod]
        public async Task WriteRunMultipleFeaturesSameArea()
        {
            await Run(new  WriteToTextScenarios.RunMultipleFeaturesSameArea());
        }
        [TestMethod]
        public async Task WriteRunMultipleAreas()
        {
            await Run(new  WriteToTextScenarios.RunMultipleAreas());
        }
        [TestMethod]
        public async Task WriteRunScenarioWithStepWithMultilineParameter()
        {
            await Run(new  WriteToTextScenarios.RunScenarioWithStepWithMultilineParameter());
        }
    }
}
