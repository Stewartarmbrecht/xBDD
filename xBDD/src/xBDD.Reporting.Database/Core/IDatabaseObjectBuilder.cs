namespace xBDD.Reporting.Database.Core
{
    public interface IDatabaseObjectBuilder
    {
        TestRun BuildTestRun(ITestRun testRun);
    }
}