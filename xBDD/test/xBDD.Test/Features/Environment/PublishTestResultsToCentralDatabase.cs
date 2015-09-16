using xBDD.xUnit;
using Xunit.Abstractions;

namespace xBDD.Test.Features.Environment
{
    public class PublishTestResultsToCentralDatabase
    {
        private readonly OutputWriter outputWriter;

        public PublishTestResultsToCentralDatabase(ITestOutputHelper output)
        {
            outputWriter = new OutputWriter(output);
        }

        [ScenarioFact]
        public void PublishAfterTestRun ()
        {
            var s = new Steps();
            xBDD.CurrentRun
                .AddScenario(this)
                .SetOutputWriter(outputWriter)
                .Given(s.Given.the_solution_is_set_to_the_Publish_configuration)
                .And(s.Given.there_is_a_valid_connection_string_set_for_the_ConfigurationSetting_setting)
                .When(s.When.the_tests_are_run)
                .Then(s.Then.it_should_publish_the_test_results_to_that_database)
                .Run();
        }
        [ScenarioFact]
        public void PublishAfterCTestRun()
        {
            var s = new Steps();
            xBDD.CurrentRun
                .AddScenario(this)
                .SetOutputWriter(outputWriter)
                .When(s.When.a_developer_pushes_a_commit_to_the_GitHub_repository)
                .Then(s.Then.a_visual_studio_online_build_should_trigger)
                .And(s.Then.build_the_projects)
                .And(s.Then.run_the_tests)
                .And(s.Then.publish_the_xBDD_test_restults_to_an_azure_database)
                .And(s.Then.publish_the_xUnit_test_restults_to_visual_studio_online)
                .Run();
        }
    }
}
