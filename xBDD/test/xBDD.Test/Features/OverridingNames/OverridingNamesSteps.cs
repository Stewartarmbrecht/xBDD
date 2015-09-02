using xBDD.Test.Sample;
using Xunit;

namespace xBDD.Test.Features.OverridingNames
{
    public class OverridingNamesSteps : CommonSteps
    {
        public string ExpectedAreaPath { get; internal set; }
        public string ExpectedFeatureName { get; internal set; }
        public string ExpectedScenarioName { get; internal set; }


        internal void a_simple_passing_scenario_with_an_scenario_name_attribute_is_run(IStep step)
        {
            SimpleTestRun = new SimpleTestRunUsingTypedStateWithCustomAttributes();
            SimpleTestRun.PassingScenario();
        }
        internal void the_scenario_name_should_match_the_scenario_name_attribute_setting(IStep step)
        {
            Assert.Equal(ExpectedScenarioName, SimpleTestRun.Scenario.Name);
        }
        internal void a_simple_passing_scenario_with_a_scenario_name_set_when_adding_the_scenario(IStep step)
        {
            SimpleTestRun = new SimpleTestRunUsingTypedStateWithCustomAreaSetAtAdd();
            SimpleTestRun.PassingScenarioWithTimeCapturingStep();
        }
        internal void the_scenario_name_should_match_the_string_value_used(IStep step)
        {
            Assert.Equal(ExpectedScenarioName, SimpleTestRun.Scenario.Name);
        }

        internal void a_simple_passing_scenario_with_an_area_path_attribute_is_run(IStep step)
        {
            SimpleTestRun = new SimpleTestRunUsingTypedStateWithCustomAttributes();
            SimpleTestRun.PassingScenario();
        }
        internal void the_area_path_should_match_the_area_path_attribute_setting(IStep step)
        {
            Assert.Equal(ExpectedAreaPath, SimpleTestRun.Scenario.AreaPath);
        }
        internal void a_simple_passing_scenario_with_an_area_path_set_when_adding_the_scenario(IStep step)
        {
            SimpleTestRun = new SimpleTestRunUsingTypedStateWithCustomAreaSetAtAdd();
            SimpleTestRun.PassingScenario();
        }
        internal void the_area_path_should_match_the_string_value_used(IStep step)
        {
            Assert.Equal(ExpectedAreaPath, SimpleTestRun.Scenario.AreaPath);
        }

        internal void a_simple_passing_scenario_with_an_feature_name_attribute_is_run(IStep step)
        {
            SimpleTestRun = new SimpleTestRunUsingTypedStateWithCustomAttributes();
            SimpleTestRun.PassingScenario();
        }
        internal void the_feature_name_should_match_the_feature_name_attribute_setting(IStep step)
        {
            Assert.Equal(ExpectedFeatureName, SimpleTestRun.Scenario.FeatureName);
        }
        internal void a_simple_passing_scenario_with_a_feature_name_set_when_adding_the_scenario(IStep step)
        {
            SimpleTestRun = new SimpleTestRunUsingTypedStateWithCustomAreaSetAtAdd();
            try
            {
                SimpleTestRun.FailingScenario();
            }
            catch
            {
                return;
            }
        }
        internal void the_feature_name_should_match_the_string_value_used(IStep step)
        {
            Assert.Equal(ExpectedFeatureName, SimpleTestRun.Scenario.FeatureName);
        }
    }
}
