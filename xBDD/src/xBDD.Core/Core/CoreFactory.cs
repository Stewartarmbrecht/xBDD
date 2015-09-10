using System;
using System.Reflection;
using xBDD.Utility;

namespace xBDD.Core
{
    public class CoreFactory : ICoreFactory
    {
        public CoreFactory()
        {
            UtilityFactory = new UtilityFactory();
        }
        public IUtilityFactory UtilityFactory { get; private set; }
        public IScenario CreateScenario(ITestRun testRun)
        {
            UtilityFactory = new UtilityFactory();
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

        public ITestRun CreateTestRun()
        {
            return new TestRun(this);
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

        public IScenarioOutputWriter CreateScenarioOutputWriter(IScenarioInternal scenario, IOutputWriter outputWriter)
        {
            return new ScenarioOutputWriter(scenario, outputWriter);
        }
    }
}
