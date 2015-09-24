using xBDD.xUnit;
using Xunit.Abstractions;

namespace xBDD.Core.Test.Features.DefineScenarios
{
    public class AddAStep
    {
        private readonly OutputWriter outputWriter;

        public AddAStep(ITestOutputHelper output)
        {
            outputWriter = new OutputWriter(output);
        }

        [ScenarioFact]
        public void Given()
        {
            Wrapper<Scenario> scenarioWrapper = new Wrapper<Scenario>();
            Wrapper<Step> stepWrapper = new Wrapper<Step>();
            xBDD.CurrentRun
                .AddScenario(this)
                .SetOutputWriter(outputWriter)
                .Given(Code.HasMethod("\\Features\\DefineScenarios\\SampleCode\\AddAGivenStep.cs"))
                .When(Code.ExecuteMethod(() =>
                {
                    scenarioWrapper.Object = new SampleCode.AddAGivenStep().Add();
                }))
                .Then(ScenarioTarget.ShouldBeCreated(scenarioWrapper))
                .And(ScenarioTarget.ShouldHaveAStep(1,scenarioWrapper, stepWrapper))
                .And(StepTarget.NameShouldBe("my starting condition", stepWrapper))
                .And(StepTarget.FullNameShouldBe("Given my starting condition", stepWrapper))
                .And(StepTarget.ActionShouldNotBeNull(stepWrapper))
                .Run();
        }
        [ScenarioFact]
        public void GivenAsync()
        {
            xBDD.CurrentRun
                .AddScenario(this)
                .SetOutputWriter(outputWriter)
                .Skip("Not Started");
        }
        [ScenarioFact]
        public void When()
        {
            xBDD.CurrentRun
                .AddScenario(this)
                .SetOutputWriter(outputWriter)
                .Skip("Not Started");
        }
        [ScenarioFact]
        public void WhenAsync()
        {
            xBDD.CurrentRun
                .AddScenario(this)
                .SetOutputWriter(outputWriter)
                .Skip("Not Started");
        }
        [ScenarioFact]
        public void Then()
        {
            xBDD.CurrentRun
                .AddScenario(this)
                .SetOutputWriter(outputWriter)
                .Skip("Not Started");
        }
        [ScenarioFact]
        public void ThenAsync()
        {
            xBDD.CurrentRun
                .AddScenario(this)
                .SetOutputWriter(outputWriter)
                .Skip("Not Started");
        }
        [ScenarioFact]
        public void And()
        {
            xBDD.CurrentRun
                .AddScenario(this)
                .SetOutputWriter(outputWriter)
                .Skip("Not Started");
        }
        [ScenarioFact]
        public void AndAsync()
        {
            xBDD.CurrentRun
                .AddScenario(this)
                .SetOutputWriter(outputWriter)
                .Skip("Not Started");
        }
        [ScenarioFact]
        public void InAnInheritedMethod()
        {
            xBDD.CurrentRun
                .AddScenario(this)
                .SetOutputWriter(outputWriter)
                .Skip("Not Started");
        }
    }
}
