using System;
using System.Threading.Tasks;
using Xunit;

namespace xBDD.Test.Features.RunningScenarios
{
    public class RunSimpleScenario
    {
        [Fact]
        public void PassingScenario()
        {
            var s = new RunningScenariosSteps();
            s.ExpectedAreaPath = "xBDD.Test.Sample";
            s.ExpectedFeatureName = "Simple Test Run Using Dynamic State";
            s.ExpectedScenarioName = "Passing Scenario";
            s.ExpectedStep1Name = "Given the user logs in as 'test.user@tococms.com'";
            s.ExpectedStep2Name = "When the user loads the 'Home - ToCo CMS' page";
            s.ExpectedStep3Name = "Then the loaded page should have a header of 'ToCo CMS'";


            xBDD.CurrentRun.AddScenario()
                .When(s.a_simple_passing_scenario_is_run)
                .Then(s.the_scenario_name_should_come_from_the_fact_method_name)
                .And(s.the_feature_name_should_come_from_the_class_name)
                .And(s.the_area_path_should_come_from_the_namespace)
                .And(s.the_step_name_should_come_from_the_method_name)
                .Run();
        }

        [Fact]
        public void FailingScenario()
        {
            var s = new RunningScenariosSteps();
            s.ExpectedAreaPath = "xBDD.Test.Sample";
            s.ExpectedFeatureName = "Simple Test Run Using Dynamic State";
            s.ExpectedScenarioName = "Failing Scenario";
            s.ExpectedStep1Name = "Given the user logs in as 'test.user@tococms.com'";
            s.ExpectedStep2Name = "When the user loads the 'Home - ToCo CMS' page";
            s.ExpectedStep3Name = "Then the loaded page should have a header of x";
            s.ExpectedExceptionMessage = "Page load failed.";

            xBDD.CurrentRun.AddScenario()
                .When(s.a_simple_failing_scenario_is_run_and_the_exception_caught)
                .Then(s.the_scenario_name_should_come_from_the_fact_method_name)
                .And(s.the_feature_name_should_come_from_the_class_name)
                .And(s.the_area_path_should_come_from_the_namespace)
                .And(s.the_step_name_should_come_from_the_method_name)
                .And(s.the_step_exception_shoul_have_a_message_of_x)
                .Run();
        }
        [Fact]
        public async Task PassingScenarioAsync()
        {
            var s = new RunningScenariosSteps();
            s.ExpectedAreaPath = "xBDD.Test.Sample";
            s.ExpectedFeatureName = "Simple Test Run Using Dynamic State";
            s.ExpectedScenarioName = "Passing Scenario Async";
            s.ExpectedStep1Name = "Given the user logs in as 'test.user@tococms.com'";
            s.ExpectedStep2Name = "When the user loads the 'Home - ToCo CMS' page";
            s.ExpectedStep3Name = "Then the loaded page should have a header of 'ToCo CMS'";

            await xBDD.CurrentRun.AddScenario()
                .WhenAsync(s.a_simple_passing_async_scenario_is_run)
                .Then(s.the_scenario_name_should_come_from_the_fact_method_name)
                .And(s.the_feature_name_should_come_from_the_class_name)
                .And(s.the_area_path_should_come_from_the_namespace)
                .And(s.the_step_name_should_come_from_the_method_name)
                .RunAsync();
        }
        [Fact]
        public async Task FailingScenarioAsync()
        {
            var s = new RunningScenariosSteps();
            s.ExpectedAreaPath = "xBDD.Test.Sample";
            s.ExpectedFeatureName = "Simple Test Run Using Dynamic State";
            s.ExpectedScenarioName = "Failing Scenario Async";
            s.ExpectedStep1Name = "Given the user logs in as 'test.user@tococms.com'";
            s.ExpectedStep2Name = "When the user loads the 'Home - ToCo CMS' page";
            s.ExpectedStep3Name = "Then the loaded page should have a header of x";
            s.ExpectedExceptionMessage = "Page load failed.";

            await xBDD.CurrentRun.AddScenario()
                .WhenAsync(s.a_simple_failing_async_scenario_is_run_and_the_exception_caught)
                .Then(s.the_scenario_name_should_come_from_the_fact_method_name)
                .And(s.the_feature_name_should_come_from_the_class_name)
                .And(s.the_area_path_should_come_from_the_namespace)
                .And(s.the_step_name_should_come_from_the_method_name)
                .And(s.the_step_exception_shoul_have_a_message_of_x)
                .RunAsync();
        }
    }
}
