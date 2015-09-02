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
            var scenario = xBDD.CurrentRun.AddScenario();
            scenario.Given(s.a_simple_passing_scenario)
                .When(s.the_scenario_is_run)
                .Then(s.the_scenario_name_should_come_from_the_fact_method_name)
                .And(s.the_feature_name_should_come_from_the_class_name)
                .And(s.the_area_path_should_come_from_the_namespace)
                .And(s.the_step_name_should_come_from_the_method_name);

            s.ExpectedAreaPath = "xBDD.Test.Sample";
            s.ExpectedFeatureName = "Simple Test Run Using Dynamic State";
            s.ExpectedScenarioName = "Passing Scenario";
            s.ExpectedStep1Name = "Given the user logs in as 'test.user@tococms.com'";
            s.ExpectedStep2Name = "When the user loads the 'Home - ToCo CMS' page";
            s.ExpectedStep3Name = "Then the loaded page should have a header of 'ToCo CMS'";

            scenario.RunAsync();
        }

        [Fact]
        public void FailingScenario()
        {
            var s = new RunningScenariosSteps();
            var scenario = xBDD.CurrentRun.AddScenario();
            scenario.Given(s.a_simple_failing_scenario)
                .When(s.the_scenario_is_run_and_the_exception_caught)
                .Then(s.the_scenario_name_should_come_from_the_fact_method_name)
                .And(s.the_feature_name_should_come_from_the_class_name)
                .And(s.the_area_path_should_come_from_the_namespace)
                .And(s.the_step_name_should_come_from_the_method_name)
                .And(s.the_step_exception_have_a_message_of_x);

            s.ExpectedAreaPath = "xBDD.Test.Sample";
            s.ExpectedFeatureName = "Simple Test Run Using Dynamic State";
            s.ExpectedScenarioName = "Failing Scenario";
            s.ExpectedStep1Name = "Given the user logs in as 'test.user@tococms.com'";
            s.ExpectedStep2Name = "When the user loads the 'Home - ToCo CMS' page";
            s.ExpectedStep3Name = "Then the loaded page should have a header of x";
            s.ExpectedExceptionMessage = "Page load failed.";

            scenario.RunAsync();
        }
        [Fact]
        public async Task PassingScenarioAsync()
        {
            var s = new RunningScenariosSteps();
            var scenario = xBDD.CurrentRun.AddScenario();
            scenario.Given(s.a_simple_passing_async_scenario)
                .WhenAsync(s.the_async_scenario_is_run)
                .Then(s.the_scenario_name_should_come_from_the_fact_method_name)
                .And(s.the_feature_name_should_come_from_the_class_name)
                .And(s.the_area_path_should_come_from_the_namespace)
                .And(s.the_step_name_should_come_from_the_method_name);

            s.ExpectedAreaPath = "xBDD.Test.Sample";
            s.ExpectedFeatureName = "Simple Test Run Using Dynamic State";
            s.ExpectedScenarioName = "Passing Scenario Async";
            s.ExpectedStep1Name = "Given the user logs in as 'test.user@tococms.com'";
            s.ExpectedStep2Name = "When the user loads the 'Home - ToCo CMS' page";
            s.ExpectedStep3Name = "Then the loaded page should have a header of 'ToCo CMS'";

            await scenario.RunAsync();
        }
        [Fact]
        public async Task FailingScenarioAsync()
        {
            var s = new RunningScenariosSteps();
            var scenario = xBDD.CurrentRun.AddScenario();
            scenario.Given(s.a_simple_failing_async_scenario)
                .WhenAsync(s.the_scenario_is_run_async_and_the_exception_caught)
                .Then(s.the_scenario_name_should_come_from_the_fact_method_name)
                .And(s.the_feature_name_should_come_from_the_class_name)
                .And(s.the_area_path_should_come_from_the_namespace)
                .And(s.the_step_name_should_come_from_the_method_name)
                .And(s.the_step_exception_have_a_message_of_x);

            s.ExpectedAreaPath = "xBDD.Test.Sample";
            s.ExpectedFeatureName = "Simple Test Run Using Dynamic State";
            s.ExpectedScenarioName = "Failing Scenario Async";
            s.ExpectedStep1Name = "Given the user logs in as 'test.user@tococms.com'";
            s.ExpectedStep2Name = "When the user loads the 'Home - ToCo CMS' page";
            s.ExpectedStep3Name = "Then the loaded page should have a header of x";
            s.ExpectedExceptionMessage = "Page load failed.";

            await scenario.RunAsync();
        }
    }
}
