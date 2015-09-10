using xBDD.xUnit;
using Xunit.Abstractions;

namespace xBDD.Test.Features.DefineScenarios
{
    public class AddAStep
    {
        private readonly IOutputWriter outputWriter;

        public AddAStep(ITestOutputHelper output)
        {
            outputWriter = new OutputWriter(output);
        }

        [ScenarioFact]
        public void Given()
        {
            Steps s = new Steps();
            s.State.StepType = "Given";
            s.State.StepName = "my step";
            s.State.AddedStepName = "Given my step";
            xBDD.CurrentRun
                .AddScenario()
                .SetOutputWriter(outputWriter)
                .Given(s.Given.a_scenario)
                .When(s.When.a_StepType_step_is_added_to_a_scenario_with_a_name_of_StepName)
                .Then(s.Then.the_added_step_name_should_be_AddedStepName);
        }
        [ScenarioFact]
        public void GivenAsync()
        {
            xBDD.CurrentRun
                .AddScenario()
                .SetOutputWriter(outputWriter)
                .Skip();
        }
        [ScenarioFact]
        public void When()
        {
            xBDD.CurrentRun
                .AddScenario()
                .SetOutputWriter(outputWriter)
                .Skip();
        }
        [ScenarioFact]
        public void WhenAsync()
        {
            xBDD.CurrentRun
                .AddScenario()
                .SetOutputWriter(outputWriter)
                .Skip();
        }
        [ScenarioFact]
        public void Then()
        {
            xBDD.CurrentRun
                .AddScenario()
                .SetOutputWriter(outputWriter)
                .Skip();
        }
        [ScenarioFact]
        public void ThenAsync()
        {
            xBDD.CurrentRun
                .AddScenario()
                .SetOutputWriter(outputWriter)
                .Skip();
        }
        [ScenarioFact]
        public void And()
        {
            xBDD.CurrentRun
                .AddScenario()
                .SetOutputWriter(outputWriter)
                .Skip();
        }
        [ScenarioFact]
        public void AndAsync()
        {
            xBDD.CurrentRun
                .AddScenario()
                .SetOutputWriter(outputWriter)
                .Skip();
        }
    }
}
