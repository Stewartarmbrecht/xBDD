﻿namespace xBDD.Test.Features.DefineScenarios
{
    public class AddAStep
    {
        [ScenarioFact]
        public void Given()
        {
            Steps s = new Steps();
            s.State.StepType = "Given";
            s.State.StepName = "my step";
            s.State.AddedStepName = "Given my step";
            xBDD.CurrentRun.AddScenario()
                .Given(s.Given.a_scenario)
                .When(s.When.a_StepType_step_is_added_to_a_scenario_with_a_name_of_StepName)
                .Then(s.Then.the_added_step_name_should_be_AddedStepName);
        }
        [ScenarioFact]
        public void GivenAsync()
        {
            xBDD.CurrentRun.AddScenario().Skip();
        }
        [ScenarioFact]
        public void When()
        {
            xBDD.CurrentRun.AddScenario().Skip();
        }
        [ScenarioFact]
        public void WhenAsync()
        {
            xBDD.CurrentRun.AddScenario().Skip();
        }
        [ScenarioFact]
        public void Then()
        {
            xBDD.CurrentRun.AddScenario().Skip();
        }
        [ScenarioFact]
        public void ThenAsync()
        {
            xBDD.CurrentRun.AddScenario().Skip();
        }
        [ScenarioFact]
        public void And()
        {
            xBDD.CurrentRun.AddScenario().Skip();
        }
        [ScenarioFact]
        public void AndAsync()
        {
            xBDD.CurrentRun.AddScenario().Skip();
        }
    }
}
