using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace xBDD.Database
{
    public class TestRunDatabaseSaver : ITestRunDatabaseSaver
    {
        string connectionName;
        Core.IFactory factory;
        public TestRunDatabaseSaver(Core.IFactory factory, string connectionName)
        {
            this.factory = factory;
            this.connectionName = connectionName;
        }
        public int SaveTestRun(ITestRun testRun)
        {
            IxBDDDbContext dbContext = factory.CreatexBDDDbContext(connectionName);
            IDatabaseObjectBuilder dbObjectBuilder = factory.CreateDatabaseObjectBuilder(dbContext);
            TestRun testRunDb = dbObjectBuilder.BuildTestRun(testRun);
            dbContext.EnsureDatabase();
            return dbContext.SaveChanges();

        }
    }
}
