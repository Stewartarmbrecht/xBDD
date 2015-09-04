using Xunit;

namespace xBDD.Test.Features.OverrideNames
{
    public class OverrideFeatureName
    {
        [ScenarioFact]
        public void WhenAdding()
        {
            xBDD.CurrentRun.AddScenario();
            throw new SkipStepException("Not Implemented");
        }
        [ScenarioFact]
        public void WithAnAttribute()
        {
            xBDD.CurrentRun.AddScenario();
            throw new SkipStepException("Not Implemented");
        }

        //[ScenarioFact]
        //public void WithFeatureNameAttribute()
        //{
        //    var s = new OverridingNamesSteps();
        //    s.ExpectedFeatureName = "My New Feature Name";
        //    xBDD.CurrentRun.AddScenario()
        //        .When(s.a_simple_passing_scenario_with_an_feature_name_attribute_is_run)
        //        .Then(s.the_feature_name_should_match_the_feature_name_attribute_setting)
        //        .Run();
        //}
        //[ScenarioFact]
        //public void WhenAddingScenario()
        //{
        //    var s = new OverridingNamesSteps();
        //    s.ExpectedFeatureName = "My Explicitly Set Feature Name";
        //    xBDD.CurrentRun.AddScenario()
        //        .When(s.a_simple_passing_scenario_with_a_feature_name_set_when_adding_the_scenario)
        //        .Then(s.the_feature_name_should_match_the_string_value_used)
        //        .Run();
        //}
    }
}
