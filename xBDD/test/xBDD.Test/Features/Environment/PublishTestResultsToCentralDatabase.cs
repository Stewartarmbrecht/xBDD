using Xunit;

namespace xBDD.Test.Features.Environment
{
    public class PublishTestResultsToCentralDatabase
    {
        [ScenarioFact]
        public void PublishAfterTestRun ()
        {
            var s = new Steps();
            xBDD.CurrentRun.AddScenario()
                .When(s.the_solution_is_set_to_the_Publish_configuration)
                .And(s.there_is_a_valid_connection_string_set_for_the_ConfigurationSetting_setting)
                .Then(s.it_should_publish_the_test_results_to_that_database)
                .Run();
        }
        [ScenarioFact]
        public void PublishAfterCITestRun()
        {
            var s = new Steps();
            xBDD.CurrentRun.AddScenario()
                .When(s.a_developer_pushes_a_commit_to_the_GitHub_repository)
                .Then(s.a_visual_studio_online_build_should_trigger)
                .And(s.build_the_projects)
                .And(s.run_the_tests)
                .And(s.publish_the_xBDD_test_restults_to_an_azure_database)
                .And(s.publish_the_xUnit_test_restults_to_visual_studio_online)
                .Run();
        }
    }
}
