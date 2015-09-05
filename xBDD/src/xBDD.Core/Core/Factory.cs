using System;
using System.Reflection;
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

        public IAttributeWrapper CreateAttribute(CustomAttributeData data)
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

        public IStatsCompiler CreateStatsCompiler()
        {
            return new StatsCompiler();
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

        public IStepExceptionHandler CreateStepExceptionHandler(IScenarioInternal scenario)
        {
            return new StepExceptionHandler(scenario, this);
        }

        public IStepExecutor CreateStepExecutor(IScenarioInternal scenario)
        {
            return new StepExecutor(scenario, this);
        }
    }
}
