using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using xBDD.Database.Core;

namespace xBDD
{
    public static class xBDDExtensions
    {
        public static int SaveToDatabase(this ITestRun testRun, string connectionName)
        {
            IDatabaseFactory factory = new DatabaseFactory();
            ITestRunDatabaseSaver saver = factory.CreateTestRunDatabaseSaver(connectionName);
            return saver.SaveTestRun(testRun);
        }
    }
}
