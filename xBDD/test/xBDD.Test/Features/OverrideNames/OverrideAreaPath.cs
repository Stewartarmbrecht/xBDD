﻿using Xunit;

namespace xBDD.Test.Features.OverrideNames
{
    public class OverrideAreaPath
    {
        [ScenarioFact]
        public void WhenAdding()
        {
            throw new SkipStepException("Not Implemented");
        }
        [ScenarioFact]
        public void WithAnAttribute()
        {
            throw new SkipStepException("Not Implemented");
        }

        //[ScenarioFact]
        //public void WithAreaPathAttribute()
        //{
        //    var s = new OverridingNamesSteps();
        //    s.ExpectedAreaPath = "My.New.Area.Path";
        //    xBDD.CurrentRun.AddScenario()
        //        .When(s.a_simple_passing_scenario_with_an_area_path_attribute_is_run)
        //        .Then(s.the_area_path_should_match_the_area_path_attribute_setting)
        //        .Run();
        //}
        //[ScenarioFact]
        //public void WhenAddingScenario()
        //{
        //    var s = new OverridingNamesSteps();
        //    s.ExpectedAreaPath = "My.Explicitly.Set.Area";
        //    xBDD.CurrentRun.AddScenario()
        //        .When(s.a_simple_passing_scenario_with_an_area_path_set_when_adding_the_scenario)
        //        .Then(s.the_area_path_should_match_the_string_value_used)
        //        .Run();
        //}
    }
}