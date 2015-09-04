using System;
using System.Reflection;
using xBDD.Database;
using xBDD.Reporting;
using xBDD.Stats;
using xBDD.Utility;

namespace xBDD.Core
{
    public class Factory : IFactory
    {
        public IScenario CreateScenario(ITestRun testRun)
        {
            var scenario = new Scenario(this, testRun);
            testRun.Scenarios.Add(scenario);
            return scenario;
        }

        public IStep CreateStep(IScenarioInternal scenario)
        {
            var step = new Step(scenario, this);
            scenario.TestRun.Steps.Add(step);
            return step;
        }

        public IScenarioNameReader GetScenarioNameReader()
        {
            return new ScenarioNameReader();
        }

        public IStepNameReader GetStepNameReader()
        {
            return new StepNameReader();
        }

        public IMethodRetriever GetMethodRetriever()
        {
            return new MethodRetriever(this);
        }

        public IMethod CreateMethod(MethodBase methodBase)
        {
            return new Method(methodBase, this);
        }

        public IAttribute CreateAttribute(CustomAttributeData data)
        {
            return new AttributeWrapper(data);
        }

        public IFeatureNameReader GetFeatureNameReader()
        {
            return new FeatureNameReader();
        }

        public IAreaPathReader GetAreaPathReader()
        {
            return new AreaPathReader();
        }

        public ITestRun CreateTestRun()
        {
            return new TestRun(this);
        }

        public IReportFactory CreateReportFactory()
        {
            return new ReportFactory();
        }

        public IStatsCompiler CreateStatsCompiler()
        {
            return new StatsCompiler();
        }

        public IxBDDDbContext CreatexBDDDbContext(string connectionName)
        {
            return new xBDDDbContext(connectionName);
        }

        public IDatabaseObjectBuilder CreateDatabaseObjectBuilder(IxBDDDbContext dbContext)
        {
            IDatabaseFactory dbFactory = CreateDatabaseFactory();
            return new DabaseObjectBuilder(dbContext, dbFactory);
        }

        public IDatabaseFactory CreateDatabaseFactory()
        {
            return new DatabaseFactory();
        }

        public ITestRunDatabaseSaver CreateTestRunDatabaseSaver(string connectionName)
        {
            return new TestRunDatabaseSaver(this, connectionName);
        }

        public IOutcomeAggregator CreateOutcomeAggregator()
        {
            return new OutcomeAggregator();
        }

        public IScenarioRunner CreateScenarioRunner(IScenarioInternal scenario)
        {
            return new ScenarioRunner(scenario, this);
        }

        public IScenarioBuilder CreateScenarioBuilder(IScenarioInternal scenario)
        {
            return new ScenarioBuilder(scenario, this);
        }
    }
}
