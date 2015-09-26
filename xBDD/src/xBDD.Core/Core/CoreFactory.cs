using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using xBDD.Utility;

[assembly: InternalsVisibleTo("xBDD.Test")]
[assembly: InternalsVisibleTo("xBDD.Core.Test")]
[assembly: InternalsVisibleTo("xBDD.Reporting.Test")]
[assembly: InternalsVisibleTo("xBDD.Reporting.Database.Test")]

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

        internal Step CreateStep(string stepName, Action action, string multilineParameter = null, MultilineParameterFormat multilineParameterFormat = MultilineParameterFormat.literal)
        {
            var step = new Step()
            {
                Name = stepName,
                Action = action,
                MultilineParameter = multilineParameter,
                MultilineParameterFormat = multilineParameterFormat
            };
            return step;
        }

        internal Step CreateStep(string stepName, Func<Task> action, string multilineParameter = null, MultilineParameterFormat multilineParameterFormat = MultilineParameterFormat.literal)
        {
            var step = new Step()
            {
                Name = stepName,
                ActionAsync = action,
                MultilineParameter = multilineParameter,
                MultilineParameterFormat = multilineParameterFormat
            };
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
