namespace xBDD.Reporting.Database.Core
{
    public class DatabaseFactory : IDatabaseFactory
    {
        public Scenario CreateScenario(IScenario scenario, TestRun testRun)
        {
            return new Scenario()
            {
                AreaPath = scenario.AreaPath,
                FeatureName = scenario.FeatureName,
                Name = scenario.Name,
                Outcome = scenario.Outcome,
                Reason = scenario.Reason,
                EndTime = scenario.EndTime,
                TestRun = testRun,
                StartTime = scenario.StartTime
            };
        }

        public Step CreateStep(IStep step, Scenario scenario)
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

        public TestRun CreateTestRun(ITestRun testRun)
        {
            return new TestRun()
            {
                Name = testRun.Name
            };
        }
        public IDatabaseContext CreatexBDDDbContext(string connectionName)
        {
            return new DatabaseContext(connectionName);
        }

        public IDatabaseObjectBuilder CreateDatabaseObjectBuilder(IDatabaseContext dbContext)
        {
            IDatabaseFactory dbFactory = CreateDatabaseFactory();
            return new DabaseObjectBuilder(dbContext, dbFactory);
        }

        public IDatabaseFactory CreateDatabaseFactory()
        {
            return new DatabaseFactory();
        }

        public ITestRunDatabaseSaver CreateTestRunDatabaseSaver(string connectionName)
        {
            return new TestRunDatabaseSaver(this, connectionName);
        }
    }
}