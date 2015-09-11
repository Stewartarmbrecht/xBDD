using xBDD.Reporting.Database.Core;

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
