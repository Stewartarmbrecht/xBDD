using System.Reflection;
using xBDD.Database;
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
        IxBDDDbContext CreatexBDDDbContext(string connectionName);
        IDatabaseObjectBuilder CreateDatabaseObjectBuilder(IxBDDDbContext dbContext);
        IDatabaseFactory CreateDatabaseFactory();
        IAttribute CreateAttribute(CustomAttributeData data);
        ITestRun CreateTestRun();
        IFeatureNameReader GetFeatureNameReader();
        IAreaPathReader GetAreaPathReader();
        IReportFactory CreateReportFactory();
        IStatsCompiler CreateStatsCompiler();
        ITestRunDatabaseSaver CreateTestRunDatabaseSaver(string connectionName);
        IOutcomeAggregator CreateOutcomeAggregator();
        IScenarioRunner CreateScenarioRunner(IScenarioInternal scenario);
        IScenarioBuilder CreateScenarioBuilder(IScenarioInternal scenario);
    }
}
