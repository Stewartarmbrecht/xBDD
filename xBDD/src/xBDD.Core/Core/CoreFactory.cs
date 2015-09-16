using System.Runtime.CompilerServices;
using xBDD.Utility;

[assembly: InternalsVisibleTo("xBDD.Test")]

namespace xBDD.Core
{
    public class CoreFactory
    {
        internal CoreFactory()
        {
            UtilityFactory = new UtilityFactory();
        }
        internal UtilityFactory UtilityFactory { get; private set; }
        internal Scenario CreateScenario(TestRun testRun)
        {
            UtilityFactory = new UtilityFactory();
            var scenario = new Scenario(this, testRun);
            testRun.Scenarios.Add(scenario);
            return scenario;
        }

        internal Step CreateStep(Scenario scenario)
        {
            var step = new Step(scenario, this);
            scenario.TestRun.Steps.Add(step);
            return step;
        }

        internal TestRun CreateTestRun()
        {
            return new TestRun(this);
        }

        internal ScenarioRunner CreateScenarioRunner(Scenario scenario)
        {
            return new ScenarioRunner(scenario, this);
        }

        internal ScenarioBuilder CreateScenarioBuilder(Scenario scenario)
        {
            return new ScenarioBuilder(scenario, this);
        }

        internal StepExceptionHandler CreateStepExceptionHandler(Scenario scenario)
        {
            return new StepExceptionHandler(scenario, this);
        }

        internal StepExecutor CreateStepExecutor(Scenario scenario)
        {
            return new StepExecutor(scenario, this);
        }

        internal ScenarioOutputWriter CreateScenarioOutputWriter(Scenario scenario, IOutputWriter outputWriter)
        {
            return new ScenarioOutputWriter(scenario, outputWriter);
        }
    }
}
