using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace xBDD.Test.Features.SaveResults
{
    [Collection("TestRunCollection")]
    public class SaveToDatabase
    {
        [ScenarioFact]
        public void SaveTestResultsToNewDatabase()
        {
            var s = new Steps();
            xBDD.CurrentRun.AddScenario()
                .Given(s.Given.a_completed_test_run)
                .And(s.Given.an_empty_test_results_database)
                .When(s.When.SaveChanges_is_called_on_the_test_run)
                .Then(s.Then.all_test_run_results_should_be_saved_to_a_new_database)
                .Run();
        }

        [ScenarioFact]
        public void SaveTestResultsToExistingDatabase()
        {
            xBDD.CurrentRun.AddScenario().Skip();
        }

        [ScenarioFact]
        public void GetTestResults()
        {
            xBDD.CurrentRun.AddScenario().Skip();
        }
    }
}
