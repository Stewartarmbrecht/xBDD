using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using xBDD.Database;
using xBDD.Test.Sample;
using Xunit;

namespace xBDD.Test.Features.SaveResults
{
    [StepLibrary]
    public class Steps
    {
        string connectionName = "Data:TestingConnection:ConnectionString";
        int saveChangesCount;
        ISimpleTestRun testRun;
        internal void a_completed_test_run(IStep step)
        {
            testRun = new SimpleTestRunUsingTypedState();
            testRun.PassingScenario();
        }

        internal void an_empty_test_results_database(IStep step)
        {
            xBDDDbContext context = new xBDDDbContext(connectionName);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }

        internal void SaveChanges_is_called_on_the_test_run(IStep step)
        {
            saveChangesCount = testRun.SaveToDatabase(connectionName); 
        }

        internal void all_test_run_results_should_be_saved_to_a_new_database(IStep step)
        {
            Assert.Equal(5, saveChangesCount);
        }
    }
}
