using xb = xBDD.Model;
namespace xBDD.Reporting.Database.Core
{
    public class DatabaseFactory
    {
        public Scenario CreateScenario(xb.Scenario scenario, TestRun testRun)
        {
            return new Scenario()
            {
                AreaPath = scenario.Feature.Area.Name,
                FeatureName = scenario.Feature.Name,
                Name = scenario.Name,
                Outcome = scenario.Outcome,
                Reason = scenario.Reason,
                EndTime = scenario.EndTime,
                TestRun = testRun,
                StartTime = scenario.StartTime
            };
        }

        public Step CreateStep(xb.Step step, Scenario scenario)
        {
            return new Step()
            {
                EndTime = step.EndTime,
                Exception = step.Exception == null ? null : step.Exception.Message + "\n" + step.Exception.StackTrace,
                Name = step.Name,
                Outcome = step.Outcome,
                Reason = step.Reason,
                Scenario = scenario,
                StartTime = step.StartTime,
                MultilineParameter = step.MultilineParameter
            };
        }

        public TestRun CreateTestRun(xb.TestRun testRun)
        {
            return new TestRun()
            {
                Name = testRun.Name
            };
        }
        public DatabaseContext CreatexBDDDbContext(string connectionName)
        {
            return new DatabaseContext(connectionName);
        }

        public DatabaseObjectBuilder CreateDatabaseObjectBuilder(DatabaseContext dbContext)
        {
            DatabaseFactory dbFactory = CreateDatabaseFactory();
            return new DatabaseObjectBuilder(dbContext, dbFactory);
        }

        public DatabaseFactory CreateDatabaseFactory()
        {
            return new DatabaseFactory();
        }

        public TestRunDatabaseSaver CreateTestRunDatabaseSaver(string connectionName)
        {
            return new TestRunDatabaseSaver(this, connectionName);
        }
    }
}