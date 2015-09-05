namespace xBDD.Database.Core
{
    public class TestRunDatabaseSaver : ITestRunDatabaseSaver
    {
        string connectionName;
        IDatabaseFactory factory;
        public TestRunDatabaseSaver(IDatabaseFactory factory, string connectionName)
        {
            this.factory = factory;
            this.connectionName = connectionName;
        }
        public int SaveTestRun(ITestRun testRun)
        {
            IDatabaseContext dbContext = factory.CreatexBDDDbContext(connectionName);
            IDatabaseObjectBuilder dbObjectBuilder = factory.CreateDatabaseObjectBuilder(dbContext);
            TestRun testRunDb = dbObjectBuilder.BuildTestRun(testRun);
            dbContext.EnsureDatabase();
            return dbContext.SaveChanges();

        }
    }
}
