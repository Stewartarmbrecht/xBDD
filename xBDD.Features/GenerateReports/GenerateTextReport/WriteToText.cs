using System.Runtime.CompilerServices;
//using Xunit;
//using Xunit.Abstractions;
using xBDD.Features;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using xBDD.Features.Steps;
using xBDD.Features.Actors;
using System.Threading.Tasks;

namespace xBDD.Features.GenerateReports.GenerateTextReport
{
    [TestClass]
    public class WriteToText: IFeature
    {
        private Developer you = new Developer();

		public IOutputWriter OutputWriter { get; private set; }

        public WriteToText()
        {
            this.OutputWriter = new TestContextWriter();
        }

        public async Task Run(IExecute<string> action, bool writeActual = false, int sortOrder = 0, [CallerMemberName]string methodName = "")
        {
            var actionName = action.GetType().Name;
            Wrapper<string> text = new Wrapper<string>();
			var seperator = System.IO.Path.DirectorySeparatorChar;
			var scenarioPath = $"{seperator}GenerateReports{seperator}GenerateTextReport{seperator}WriteToTextScenarios{seperator}";

            await xB.CurrentRun
                .AddScenario(this, sortOrder, methodName)
                .Given(you.HaveTheFollowingClass("",scenarioPath + actionName + ".cs"))
                .WhenAsync("you execute the scenario", async step => {
                    text.Object = await action.Execute();
                })
                .Then(you.WillSeeTheOutputMatches(scenarioPath + actionName + ".txt", text))
                .Run();
        }

        [TestMethod]
        public async Task WriteEmtpyTestRun()
        {
            await Run(new  WriteToTextScenarios.EmptyTestRun(), false, 1);
        }
        [TestMethod]
        public async Task WriteSkippedEmptyScenario()
        {
            await Run(new  WriteToTextScenarios.SkippedEmptyScenario(), false, 2);
        }
        [TestMethod]
        public async Task WriteRunEmptyScenario()
        {
            await Run(new  WriteToTextScenarios.RunEmptyScenario(), false, 3);
        }
        [TestMethod]
        public async Task WriteSkippedScenarioWithSteps()
        {
            await Run(new  WriteToTextScenarios.SkippedScenarioWithSteps(), false, 4);
        }
        [TestMethod]
        public async Task WriteRunScenarioWithSteps()
        {
            await Run(new  WriteToTextScenarios.RunScenarioWithSteps(), false, 5);
        }
        [TestMethod]
        public async Task WriteRunScenarioWithSkippedStep()
        {
            await Run(new  WriteToTextScenarios.RunScenarioWithSkippedStep(), false, 6);
        }
        [TestMethod]
        public async Task WriteRunScenarioWithNotImplementedStep()
        {
            await Run(new  WriteToTextScenarios.RunScenarioWithNotImplementedStep(), false, 7);
        }
        [TestMethod]
        public async Task WriteRunScenarioWithFailedStep()
        {
            await Run(new  WriteToTextScenarios.RunScenarioWithFailedStep(), false, 8);
        }
        [TestMethod]
        public async Task WriteRunMultipleScenariosSameFeature()
        {
            await Run(new  WriteToTextScenarios.RunMultipleScenariosSameFeature(), false, 9);
        }
        [TestMethod]
        public async Task WriteRunMultipleFeaturesSameArea()
        {
            await Run(new  WriteToTextScenarios.RunMultipleFeaturesSameArea(), false, 10);
        }
        [TestMethod]
        public async Task WriteRunMultipleAreas()
        {
            await Run(new  WriteToTextScenarios.RunMultipleAreas(), false, 11);
        }
        [TestMethod]
        public async Task WriteRunScenarioWithStepWithMultilineParameter()
        {
            await Run(new  WriteToTextScenarios.RunScenarioWithStepWithMultilineParameter(), false, 12);
        }
    }
}
