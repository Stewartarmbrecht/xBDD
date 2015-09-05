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
        IStep CreateStep(IScenarioInternal scenario);
        IMethod CreateMethod(MethodBase methodBase);
        IAttributeWrapper CreateAttribute(CustomAttributeData data);
        ITestRun CreateTestRun();
        IStepExecutor CreateStepExecutor(IScenarioInternal scenario);
        IFeatureNameReader GetFeatureNameReader();
        IAreaPathReader GetAreaPathReader();
        IStatsCompiler CreateStatsCompiler();
        IStepExceptionHandler CreateStepExceptionHandler(IScenarioInternal scenario);
        IOutcomeAggregator CreateOutcomeAggregator();
        IScenarioRunner CreateScenarioRunner(IScenarioInternal scenario);
        IScenarioBuilder CreateScenarioBuilder(IScenarioInternal scenario);
    }
}
