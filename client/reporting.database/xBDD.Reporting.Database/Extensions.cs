using xBDD.Reporting.Database.Core;
using xb = xBDD.Model;

namespace xBDD
{
    public static class xBDDExtensions
    {
        public static int SaveToDatabase(this xb.TestRun testRun, string connectionName)
        {
            DatabaseFactory factory = new DatabaseFactory();
            TestRunDatabaseSaver saver = factory.CreateTestRunDatabaseSaver(connectionName);
            return saver.SaveTestRun(testRun);
        }
    }
}
