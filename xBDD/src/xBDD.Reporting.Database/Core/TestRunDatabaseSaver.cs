using System;
using xb = xBDD;

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
        public int SaveTestRun(xb.TestRun testRun)
        {
            DatabaseContext dbContext = factory.CreatexBDDDbContext(connectionName);
            DatabaseObjectBuilder dbObjectBuilder = factory.CreateDatabaseObjectBuilder(dbContext);
            TestRun testRunDb = dbObjectBuilder.BuildTestRun(testRun);
            dbContext.EnsureDatabase();
            var count = dbContext.SaveChanges();
            Console.WriteLine("There were " + count + " entries written to the " + dbContext.DatabaseName + " on the " + dbContext.ServerName);
            return count;

        }
    }
}
