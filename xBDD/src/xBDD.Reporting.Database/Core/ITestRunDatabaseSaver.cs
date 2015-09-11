namespace xBDD.Reporting.Database.Core
{
    public interface ITestRunDatabaseSaver
    {
        int SaveTestRun(ITestRun testRun);
    }
}