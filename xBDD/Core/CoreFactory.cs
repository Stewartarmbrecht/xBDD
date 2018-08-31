﻿using System;
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
        internal TestRun CreateTestRun(string name)
        {
            return new TestRun()
            {
                Name = name,
                AreaStats = new OutcomeStats(),
                FeatureStats = new OutcomeStats(),
                ScenarioStats = new OutcomeStats(),
                StepStats = new OutcomeStats(),
                AreaReasonStats = new Dictionary<string, int>(),
                FeatureReasonStats = new Dictionary<string, int>(),
                ScenarioReasonStats = new Dictionary<string, int>(),
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
                StepStats = new OutcomeStats(),
                FeatureReasonStats = new Dictionary<string, int>(),
                ScenarioReasonStats = new Dictionary<string, int>(),
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
                StepStats = new OutcomeStats(),
                ScenarioReasonStats = new Dictionary<string, int>(),
            };
            area.Features.Add(feature);
            return feature;
        }

        internal Scenario CreateScenario(
			string name, 
			Feature feature, 
			string methodName, 
			string explanation, 
			string[] assignments, 
			string[] tags, 
			int sortOrder)
        {
            var scenario = new Scenario()
            {
                Name = name,
                MethodName = methodName,
				Explanation = explanation,
				Assignments = assignments,
				Tags = tags,
                Sort = sortOrder,
                Feature = feature,
                StepStats = new OutcomeStats()
            };
            feature.Scenarios.Add(scenario);
            return scenario;
        }

        internal Step CreateStep(string stepName, Action<Step> action, string multilineParameter, TextFormat multilineParameterFormat, string explanation)
        {
            return new Step()
            {
                Name = stepName,
                Action = action,
                Input = multilineParameter,
                InputFormat = multilineParameterFormat,
				Explanation = explanation
            };
        }

        internal Step CreateStep(string stepName, Func<Step, Task> action, string multilineParameter, TextFormat multilineParameterFormat, string explanation)
        {
            return new Step()
            {
                Name = stepName,
                ActionAsync = action,
                Input = multilineParameter,
                InputFormat = multilineParameterFormat,
				Explanation = explanation
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
			string[] assignments,
			string[] tags,
			int sortOrder)
        {
            return new ScenarioBuilder(scenarioName, feature, this, methodName, explanation, assignments, tags, sortOrder);
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
