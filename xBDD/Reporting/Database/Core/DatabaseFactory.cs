using xb = xBDD.Model;
namespace xBDD.Reporting.Database.Core
{
    internal class DatabaseFactory
    {
        internal Scenario CreateScenario(xb.Scenario scenario, TestRun testRun)
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

        internal Step CreateStep(xb.Step step, Scenario scenario)
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
                MultilineParameter = step.Input
            };
        }

        internal TestRun CreateTestRun(xb.TestRun testRun)
        {
            return new TestRun()
            {
                Name = testRun.Name
            };
        }
        internal DatabaseContext CreatexBDDDbContext(string connectionName)
        {
            return new DatabaseContext(connectionName);
        }

        internal DatabaseObjectBuilder CreateDatabaseObjectBuilder(DatabaseContext dbContext)
        {
            DatabaseFactory dbFactory = CreateDatabaseFactory();
            return new DatabaseObjectBuilder(dbContext, dbFactory);
        }

        internal DatabaseFactory CreateDatabaseFactory()
        {
            return new DatabaseFactory();
        }

        internal TestRunDatabaseSaver CreateTestRunDatabaseSaver(string connectionName)
        {
            return new TestRunDatabaseSaver(this, connectionName);
        }
    }
}