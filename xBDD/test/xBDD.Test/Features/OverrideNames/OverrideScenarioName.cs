using Xunit;

namespace xBDD.Test.Features.OverrideNames
{
    public class OverrideScenarioName
    {
        [ScenarioFact]
        public void WhenAdding()
        {
            xBDD.CurrentRun.AddScenario().Skip();
        }
        [ScenarioFact]
        public void WithAnAttribute()
        {
            xBDD.CurrentRun.AddScenario().Skip();
        }

        //[ScenarioFact]
        //public void WhenAddingScenario()
        //{
        //    var s = new OverridingNamesSteps();
        //    s.ExpectedScenarioName = "My New Scenario Name";
        //    xBDD.CurrentRun.AddScenario()
        //        .When(s.a_simple_passing_scenario_with_an_scenario_name_attribute_is_run)
        //        .Then(s.the_scenario_name_should_match_the_scenario_name_attribute_setting)
        //        .Run();
        //}
        //[ScenarioFact]
        //[ScenarioName("With A Scenario Name Attribute")]
        //public void WithScenarioNameAttribute()
        //{
        //    var s = new OverridingNamesSteps();
        //    s.ExpectedScenarioName = "My Explicitly Set Scenario Name";
        //    xBDD.CurrentRun.AddScenario()
        //        .When(s.a_simple_passing_scenario_with_a_scenario_name_set_when_adding_the_scenario)
        //        .Then(s.the_scenario_name_should_match_the_string_value_used)
        //        .Run();
        //}
    }
}
