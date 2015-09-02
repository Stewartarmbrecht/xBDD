using System;
using System.Threading.Tasks;
using Xunit;

namespace xBDD.Test.Features.RunningScenarios
{
    public class RunTypedStateScenario
    {
        [Fact]
        public void PassingScenario()
        {
            var s = new RunningScenariosSteps();
            var scenario = xBDD.CurrentRun.AddScenario();
            scenario
                .When(s.a_simple_passing_scenario_with_typed_state_is_run)
                .Then(s.the_scenario_name_should_come_from_the_fact_method_name)
                .And(s.the_feature_name_should_come_from_the_class_name)
                .And(s.the_area_path_should_come_from_the_namespace)
                .And(s.the_step_name_should_come_from_the_method_name);

            s.ExpectedAreaPath = "xBDD.Test.Sample";
            s.ExpectedFeatureName = "Simple Test Run Using Typed State";
            s.ExpectedScenarioName = "Passing Scenario";
            s.ExpectedStep1Name = "Given the user logs in as 'test.user@tococms.com' typed";
            s.ExpectedStep2Name = "When the user loads the 'Home - ToCo CMS' page typed";
            s.ExpectedStep3Name = "Then the loaded page should have a header of 'ToCo CMS' typed";

            scenario.RunAsync();
        }
    }
}
