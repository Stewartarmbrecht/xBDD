using System.Reflection;
using xBDD.Stats;
using xBDD.Utility;

namespace xBDD.Core
{
    public interface IFactory
    {
        IScenarioNameReader GetScenarioNameReader();
        IStepNameReader GetStepNameReader();
        IMethodRetriever GetMethodRetriever();
        IScenario CreateScenario(ITestRun testRun);
        IStep CreateStep(ITestRun testRun, IScenario scenario);

        IMethod CreateMethod(MethodBase methodBase);
        IAttribute CreateAttribute(CustomAttributeData data);
        ITestRun CreateTestRun();
        IFeatureNameReader GetFeatureNameReader();
        IAreaPathReader GetAreaPathReader();
        IReportFactory CreateReportFactory();
        IStatsCompiler CreateStatsCompiler();
    }
}
