using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using xBDD.Test.Sample;
using Xunit;

namespace xBDD.Test.Features.OverridingNames
{
    public class OverridingNamesSteps : CommonSteps
    {
        public string ExpectedAreaPath { get; internal set; }

        internal void a_simple_passing_scenario_with_an_area_path_attribute_is_run(IStep obj)
        {
            SimpleTestRun = new SimpleTestRunUsingTypedStateWithCustomAreaAttribute();
            SimpleTestRun.PassingScenario();
        }

        internal void the_area_path_should_match_the_area_path_attribute_setting(IStep step)
        {
            Assert.Equal(ExpectedAreaPath, SimpleTestRun.Scenario.AreaPath);
        }
    }
}
