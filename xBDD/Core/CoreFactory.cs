using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using xBDD.Model;
using xBDD.Utility;

namespace xBDD.Core
{
    /// <summary>
    /// Factory used to create all objects for the core.
    /// </summary>
    public class CoreFactory
    {
        /// <summary>
        /// Creates a new <see cref="CoreFactory"/>
        /// </summary>
        public CoreFactory()
        {
            UtilityFactory = new UtilityFactory();
        }
        internal UtilityFactory UtilityFactory { get; private set; }
        internal TestRunGroup CreateTestRunGroup(string name)
        {
            return new TestRunGroup()
            {
                Name = name,
                TestRunStats = new OutcomeStats(),
                CapabilityStats = new OutcomeStats(),
                FeatureStats = new OutcomeStats(),
                ScenarioStats = new OutcomeStats(),
                StepStats = new OutcomeStats(),
                TestRunReasonStats = new Dictionary<string, int>(),
                CapabilityReasonStats = new Dictionary<string, int>(),
                FeatureReasonStats = new Dictionary<string, int>(),
                ScenarioReasonStats = new Dictionary<string, int>(),
            };
        }

        internal TestRun CreateTestRun(string name)
        {
            return new TestRun()
            {
                Name = name,
                CapabilityStats = new OutcomeStats(),
                FeatureStats = new OutcomeStats(),
                ScenarioStats = new OutcomeStats(),
                StepStats = new OutcomeStats(),
                CapabilityReasonStats = new Dictionary<string, int>(),
                FeatureReasonStats = new Dictionary<string, int>(),
                ScenarioReasonStats = new Dictionary<string, int>(),
            };
        }

        internal Capability CreateCapability(string name, TestRun testRun)
        {
            var capability = new Capability()
            {
                Name = name,
                TestRun = testRun,
                FeatureStats = new OutcomeStats(),
                ScenarioStats = new OutcomeStats(),
                StepStats = new OutcomeStats(),
                FeatureReasonStats = new Dictionary<string, int>(),
                ScenarioReasonStats = new Dictionary<string, int>(),
            };
            testRun.Capabilities.Add(capability);
            return capability;
        }
        internal Feature CreateFeature(string name, Capability capability)
        {
            var feature = new Feature()
            {
                Name = name, 
                Capability = capability,
                ScenarioStats = new OutcomeStats(),
                StepStats = new OutcomeStats(),
                ScenarioReasonStats = new Dictionary<string, int>(),
            };
            capability.Features.Add(feature);
            return feature;
        }

        internal Scenario CreateScenario(
			string name, 
			Feature feature, 
			string methodName, 
			string explanation, 
			TextFormat explanationFormat,
			string[] assignments, 
			string[] tags, 
			int sortOrder)
        {
            var scenario = new Scenario()
            {
                Name = name,
                MethodName = methodName,
				Explanation = explanation,
				ExplanationFormat = explanationFormat,
				Assignments = assignments,
				Tags = tags,
                Sort = sortOrder,
                Feature = feature,
                StepStats = new OutcomeStats()
            };
            feature.Scenarios.Add(scenario);
            return scenario;
        }

        internal Step CreateStep(string stepName, Action<Step> action, string input, TextFormat intputFormat, string explanation, TextFormat explanationFormat)
        {
            return new Step()
            {
                Name = stepName,
                Action = action,
                Input = input,
                InputFormat = intputFormat,
				Explanation = explanation,
				ExplanationFormat = explanationFormat
            };
        }

        internal Step CreateStep(string stepName, Func<Step, Task> action, string input, TextFormat inputFormat, string explanation, TextFormat explanationFormat)
        {
            return new Step()
            {
                Name = stepName,
                ActionAsync = action,
                Input = input,
                InputFormat = inputFormat,
				Explanation = explanation,
				ExplanationFormat = explanationFormat
            };
        }

        /// <summary>
        /// Creates a Test Run builder that can be used to build and run scenarios.
        /// </summary>
        /// <param name="testRunName">The name of the test run that is executing.</param>
        /// <returns>A new <see cref="TestRunBuilder"/></returns>
        public TestRunBuilder CreateTestRunBuilder(string testRunName)
        {
            return new TestRunBuilder(this, CreateTestRun(testRunName));
        }

        internal ScenarioBuilder CreateScenarioBuilder(
			string scenarioName, 
			Feature feature, 
			string methodName, 
			string explanation, 
			TextFormat explanationFormat,
			string[] assignments,
			string[] tags,
			int sortOrder)
        {
            return new ScenarioBuilder(scenarioName, feature, this, methodName, explanation, explanationFormat, assignments, tags, sortOrder);
        }

        internal CapabilityCache CreateCapabilityCache()
        {
            return new CapabilityCache(this);
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
