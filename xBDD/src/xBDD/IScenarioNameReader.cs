using System.Reflection;

namespace xBDD
{
    public interface IScenarioNameReader
    {
        string ReadScenarioName(string scenarioName, IMethod method);
    }
}