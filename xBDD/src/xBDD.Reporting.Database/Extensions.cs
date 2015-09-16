using xBDD.Reporting.Database.Core;

namespace xBDD
{
    public static class xBDDExtensions
    {
        public static int SaveToDatabase(this TestRun testRun, string connectionName)
        {
            DatabaseFactory factory = new DatabaseFactory();
            TestRunDatabaseSaver saver = factory.CreateTestRunDatabaseSaver(connectionName);
            return saver.SaveTestRun(testRun);
        }
    }
}
