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
            Steps s = new Steps();
            s.State.StepType = "Given";
            s.c.State.StepName = "my step";
            s.State.AddedStepName = "Given my step";
            xBDD.CurrentRun
                .AddScenario(this)
                .SetOutputWriter(outputWriter)
                .Given(s.c.Given.a_scenario)
                .When(s.When.a_StepType_step_is_added_to_a_scenario_with_a_name_of_StepName)
                .Then(s.Then.the_added_step_name_should_be_AddedStepName);
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
