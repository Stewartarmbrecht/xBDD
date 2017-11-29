using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace xBDD.Test.Features.SaveResults
{
    [TestClass]
    public class WriteToDatabase
    {
        private readonly TestContextWriter outputWriter;

        public WriteToDatabase()
        {
            outputWriter = new TestContextWriter();
        }

        [TestMethod]
        public async void ToNewDatabase()
        {
            await xB.CurrentRun
                .AddScenario(this)
                .SetOutputWriter(outputWriter)
                .Skip("Re-writing");
            //var s = new Steps();
            //xBDD.CurrentRun
            //    .AddScenario(this)
            //    .SetOutputWriter(outputWriter)
            //    .Given(s.Given.a_completed_test_run)
            //    .And(s.Given.an_empty_test_results_database)
            //    .When(s.When.SaveChanges_is_called_on_the_test_run)
            //    .Then(s.Then.all_test_run_results_should_be_saved_to_a_new_database)
            //    .Run();
        }

        [TestMethod]
        public async void ToExistingDatabase()
        {
            await xB.CurrentRun
                .AddScenario(this)
                .SetOutputWriter(outputWriter)
                .Skip("Not Started");
        }

        [TestMethod]
        public async void ToExistingDatabaseFails()
        {
            await xB.CurrentRun
                .AddScenario(this)
                .SetOutputWriter(outputWriter)
                .Skip("Not Started");
        }

        [TestMethod]
        public async void GetTestResults()
        {
            await xB.CurrentRun
                .AddScenario(this)
                .SetOutputWriter(outputWriter)
                .Skip("Not Started");
        }
    }
}
