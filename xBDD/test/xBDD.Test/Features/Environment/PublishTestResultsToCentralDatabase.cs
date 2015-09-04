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
    }
}
