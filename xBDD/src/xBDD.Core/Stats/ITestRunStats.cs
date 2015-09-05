namespace xBDD.Stats
{
    public interface ITestRunStats
    {
        ITestRun TestRun { get; }
        IAreaStats RootArea { get; }
    }
}