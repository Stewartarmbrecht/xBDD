using System;
using System.Threading.Tasks;
using xBDD.Model;
using xBDD.Utility;

namespace xBDD.Core
{
    public class CoreFactory
    {
        public CoreFactory()
        {
            UtilityFactory = new UtilityFactory();
        }
        internal UtilityFactory UtilityFactory { get; private set; }
        internal TestRun CreateTestRun(string name)
        {
            return new TestRun()
            {
                Name = name,
                AreaStats = new OutcomeStats(),
                FeatureStats = new OutcomeStats(),
                ScenarioStats = new OutcomeStats(),
                StepStats = new OutcomeStats(),
            };
        }

        internal Area CreateArea(string name, TestRun testRun)
        {
            var area = new Area()
            {
                Name = name,
                TestRun = testRun,
                FeatureStats = new OutcomeStats(),
                ScenarioStats = new OutcomeStats(),
                StepStats = new OutcomeStats()
            };
            testRun.Areas.Add(area);
            return area;
        }
        internal Feature CreateFeature(string name, Area area)
        {
            var feature = new Feature()
            {
                Name = name, 
                Area = area,
                ScenarioStats = new OutcomeStats(),
                StepStats = new OutcomeStats()
            };
            area.Features.Add(feature);
            return feature;
        }

        internal Scenario CreateScenario(string name, Feature feature)
        {
            var scenario = new Scenario()
            {
                Name = name,
                Feature = feature,
                StepStats = new OutcomeStats()
            };
            feature.Scenarios.Add(scenario);
            return scenario;
        }

        internal Step CreateStep(string stepName, Action<Step> action, string multilineParameter, TextFormat multilineParameterFormat)
        {
            return new Step()
            {
                Name = stepName,
                Action = action,
                MultilineParameter = multilineParameter,
                MultilineParameterFormat = multilineParameterFormat
            };
        }

        internal Step CreateStep(string stepName, Func<Step, Task> action, string multilineParameter, TextFormat multilineParameterFormat)
        {
            return new Step()
            {
                Name = stepName,
                ActionAsync = action,
                MultilineParameter = multilineParameter,
                MultilineParameterFormat = multilineParameterFormat
            };
        }

        public TestRunBuilder CreateTestRunBuilder(string testRunName)
        {
            return new TestRunBuilder(this, CreateTestRun(testRunName));
        }

        internal ScenarioBuilder CreateScenarioBuilder(string scenarioName, Feature feature)
        {
            return new ScenarioBuilder(scenarioName, feature, this);
        }

        internal AreaCache CreateAreaCache()
        {
            return new AreaCache(this);
        }

        internal FeatureCache CreateFeatureCache()
        {
            return new FeatureCache(this);
        }

        internal ScenarioRunner CreateScenarioRunner(Scenario scenario)
        {
            return new ScenarioRunner(scenario, this);
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
