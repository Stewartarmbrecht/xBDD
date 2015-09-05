namespace xBDD.Database.Core
{
    public interface IDatabaseObjectBuilder
    {
        TestRun BuildTestRun(ITestRun testRun);
    }
}