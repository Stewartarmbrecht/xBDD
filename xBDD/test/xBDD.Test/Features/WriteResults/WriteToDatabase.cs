using xBDD.xUnit;
using Xunit;
using Xunit.Abstractions;

namespace xBDD.Test.Features.SaveResults
{
    [Collection("TestRunCollection")]
    public class WriteToDatabase
    {
        private readonly IOutputWriter outputWriter;

        public WriteToDatabase(ITestOutputHelper output)
        {
            outputWriter = new OutputWriter(output);
        }

        [ScenarioFact]
        public void ToNewDatabase()
        {
            var s = new Steps();
            xBDD.CurrentRun
                .AddScenario()
                .SetOutputWriter(outputWriter)
                .Given(s.Given.a_completed_test_run)
                .And(s.Given.an_empty_test_results_database)
                .When(s.When.SaveChanges_is_called_on_the_test_run)
                .Then(s.Then.all_test_run_results_should_be_saved_to_a_new_database)
                .Run();
        }

        [ScenarioFact]
        public void ToExistingDatabase()
        {
            xBDD.CurrentRun
                .AddScenario()
                .SetOutputWriter(outputWriter)
                .Skip();
        }

        [ScenarioFact]
        public void ToExistingDatabaseFails()
        {
            xBDD.CurrentRun
                .AddScenario()
                .SetOutputWriter(outputWriter)
                .Skip();
        }

        [ScenarioFact]
        public void GetTestResults()
        {
            xBDD.CurrentRun
                .AddScenario()
                .SetOutputWriter(outputWriter)
                .Skip();
        }
    }
}
