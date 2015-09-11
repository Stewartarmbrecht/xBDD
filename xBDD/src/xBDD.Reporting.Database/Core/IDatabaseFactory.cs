namespace xBDD.Reporting.Database.Core
{
    public interface IDatabaseFactory
    {
        TestRun CreateTestRun(ITestRun testRun);
        Scenario CreateScenario(IScenario scenario, TestRun testRun);
        Step CreateStep(IStep step, Scenario scenario);
        IDatabaseContext CreatexBDDDbContext(string connectionName);
        IDatabaseObjectBuilder CreateDatabaseObjectBuilder(IDatabaseContext dbContext);
        IDatabaseFactory CreateDatabaseFactory();
        ITestRunDatabaseSaver CreateTestRunDatabaseSaver(string connectionName);
    }
}
