namespace xBDD.Database
{
    public interface IDatabaseObjectBuilder
    {
        TestRun BuildTestRun(ITestRun testRun);
    }
}