using System;

namespace xBDD.Reporting.Database.Core
{
    public class TestRunDatabaseSaver
    {
        string connectionName;
        DatabaseFactory factory;
        public TestRunDatabaseSaver(DatabaseFactory factory, string connectionName)
        {
            this.factory = factory;
            this.connectionName = connectionName;
        }
        public int SaveTestRun(xBDD.Model.TestRun testRun)
        {
            DatabaseContext dbContext = factory.CreatexBDDDbContext(connectionName);
            DatabaseObjectBuilder dbObjectBuilder = factory.CreateDatabaseObjectBuilder(dbContext);
            TestRun testRunDb = dbObjectBuilder.BuildTestRun(testRun);
            dbContext.EnsureDatabase();
            var count = dbContext.SaveChanges();
            System.Diagnostics.Trace.WriteLine("There were " + count + " entries written to the '" + dbContext.DatabaseName + "' database on the '" + dbContext.ServerName + "' server.");
            return count;

        }
    }
}
