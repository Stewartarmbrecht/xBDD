namespace xBDD.Utility
{
    public interface IScenarioNameReader
    {
        string ReadScenarioName(string scenarioName, IMethod method);
    }
}