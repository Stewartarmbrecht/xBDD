namespace xBDD.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using xBDD.Model;
    using xBDD.Utility;

    /// <summary>
    /// Provides methods for building a test run by adding scenarios.
    /// </summary>
    public class TestRunBuilder
    {
        CoreFactory factory;
        AreaCache areaCache;
        FeatureCache featureCache;

        /// <summary>
        /// Provides access the test run being built.
        /// </summary>
        /// <value>Test Run being build. <see cref="TestRun"/></value>
        public TestRun TestRun { get; private set; }

        /// <summary>
        /// Creates a new test run builder.
        /// </summary>
        /// <param name="factory"></param>
        /// <param name="testRun"></param>
        internal TestRunBuilder(CoreFactory factory, TestRun testRun)
        {
            this.factory = factory;
            this.areaCache = factory.CreateAreaCache();
            this.featureCache = factory.CreateFeatureCache();
            this.TestRun = testRun;
        }

        /// <summary>
        /// This method should be called from within the test method.
        /// It uses reflection to get the calling method name and it expects
        /// to recieve a reference of the test class to get the name of the 
        /// feature and namespace.
        /// </summary>
        /// <param name="featureClass">
        /// A reference to the parent class for the scenario.  
        /// Usually just pass in 'this'.  The test class represents the feature.
        /// </param>
        /// <param name="methodName">Optional. The system will attempt to get the method name of the scenario through reflection.</param>
        /// <param name="sortOrder">Optional. Used by the test run when sorting the results
        /// if you call SortTestRunResults on the test run. Default value is 1,000,000.</param>
        /// <returns>The scenario build for a fluent syntax.</returns>
        public ScenarioBuilder AddScenario(object featureClass, int sortOrder = 1000000, [CallerMemberName]string methodName = "")
        {
            CodeDetails codeDetails = factory.UtilityFactory.GetMethodRetriever().GetScenarioMethod(featureClass, methodName);
            return AddScenario(codeDetails, null, null, null, sortOrder);
        }

        /// <summary>
        /// This method should be called from within the test method.
        /// This signature allows you to set properties of the scenario
        /// that would otherwise be set by the code.
        /// </summary>
        /// <param name="codeDetails">
        /// Provides ability to set details that would otherwise be pulled
        /// from the feature class code.
        /// </param>
        /// <param name="sortOrder">Optional. Used by the test run when sorting the results
        /// if you call SortTestRunResults on the test run. Default value is 1,000,000.</param>
        /// <returns>The scenario build for a fluent syntax.</returns>
        public ScenarioBuilder AddScenario(CodeDetails codeDetails, int sortOrder = 100000)
        {
            return AddScenario(codeDetails, null, null, null, sortOrder);
        }

        /// <summary>
        /// This method should be called from within the test method.
        /// It uses reflection to get the calling method name and it expects
        /// to recieve a reference of the test class to get the name of the 
        /// feature and namespace.
        /// </summary>
        /// <param name="scenarioName">
        /// The name of the scenario to create.  Use this to override the method
        /// name from becoming the scenario name.
        /// </param>
        /// <param name="featureClass">
        /// A reference to the parent class for the scenario.  
        /// Usually just pass in 'this'.  The test class represents the feature.
        /// </param>
        /// <param name="methodName">Optional. The system will attempt to get the method name of the scenario through reflection.</param>
        /// <param name="sortOrder">Optional. Used by the test run when sorting the results
        /// if you call SortTestRunResults on the test run. Default value is 1,000,000</param>
        /// <returns>The scenario build for a fluent syntax.</returns>
        public ScenarioBuilder AddScenario(string scenarioName, 
            object featureClass, int sortOrder = 1000000, [CallerMemberName]string methodName = "")
        {
            CodeDetails codeDetails = factory.UtilityFactory.GetMethodRetriever().GetScenarioMethod(featureClass, methodName);
            return AddScenario(codeDetails, scenarioName, null, null, sortOrder);
        }

        /// <summary>
        /// This method should be called from within the test method.
        /// It uses reflection to get the calling method name and it expects
        /// to recieve a reference of the test class to get the name of the 
        /// feature and namespace.
        /// </summary>
        /// <param name="scenarioName">
        /// The name of the scenario to create.  Use this to override the method
        /// name from becoming the scenario name.
        /// </param>
        /// <param name="featureName">
        /// The name of the feature to create.  Use this to override the class 
        /// name from becoming the scenario name.
        /// </param>
        /// <param name="featureClass">
        /// A reference to the parent class for the scenario.  
        /// Usually just pass in 'this'.  The test class represents the feature.
        /// </param>
        /// <param name="methodName">
        /// Optional. The system will attempt to get the method name of the scenario through reflection.
        /// </param>
        /// <param name="sortOrder">Optional. Used by the test run when sorting the results
        /// if you call SortTestRunResults on the test run. Default value is 1,000,000.</param>
        /// <returns>The scenario build for a fluent syntax.</returns>
        public ScenarioBuilder AddScenario(string scenarioName, string featureName, 
            object featureClass, int sortOrder = 1000000, [CallerMemberName]string methodName = "")
        {
            CodeDetails codeDetails = factory.UtilityFactory.GetMethodRetriever().GetScenarioMethod(featureName, methodName);
            return AddScenario(codeDetails, scenarioName, featureName, null, sortOrder);
        }

        /// <summary>
        /// This method should be called from within the test method.
        /// It uses reflection to get the calling method name and it expects
        /// to recieve a reference of the test class to get the name of the 
        /// feature and namespace.
        /// </summary>
        /// <param name="scenarioName">
        /// The name of the scenario to create.  Use this to override the method
        /// name from becoming the scenario name.
        /// </param>
        /// <param name="featureName">
        /// The name of the feature to create.  Use this to override the class 
        /// name from becoming the feature name.
        /// </param>
        /// <param name="areaPath">
        /// The name of the area to add the feature to.  Use this to override the namespace 
        /// from becoming the area name.
        /// </param>
        /// <param name="sortOrder">Optional. Used by the test run when sorting the results
        /// if you call SortTestRunResults on the test run. Default value is 1,000,000.</param>
        /// <returns>The scenario build for a fluent syntax.</returns>
        public ScenarioBuilder AddScenario(string scenarioName, string featureName, string areaPath, int sortOrder = 1000000)
        {
            return AddScenario(null, scenarioName, featureName, areaPath, sortOrder);
        }

        /// <summary>
        /// Cascades the scenario skipped reasons up the hierarchy.
        /// Also calculates the count of children for each skipped reason.
        /// </summary>
        /// <param name="sortedReasons">The list of reasons sorted from least to highest precedent.
        /// A parent that has both reasons will assume the reason with the highest precedent.</param>
        public void UpdateParentReasonsAndStats(List<string> sortedReasons)
        {
            if(!sortedReasons.Contains("Failed"))
                sortedReasons.Add("Failed");

            var additionalReasons = TestRun.Scenarios
                .Select(scenario => scenario.Reason)
                .Distinct()
                .Where(reason => !sortedReasons.Contains(reason) && reason != null)
                .OrderBy(reason => reason)
                .ToList();

            sortedReasons.InsertRange(0,additionalReasons);

            sortedReasons.ForEach(reason => {
                TestRun.Scenarios
                    .Where(scenario => scenario.Reason == reason)
                    .ToList().ForEach(scenario => {
                        scenario.Feature.Reason = reason;
                        if(scenario.Feature.ScenarioReasonStats.Keys.Contains(reason)) {
                            scenario.Feature.ScenarioReasonStats[reason] = scenario.Feature.ScenarioReasonStats[reason] + 1;
                        } else {
                            scenario.Feature.ScenarioReasonStats.Add(reason, 1);
                        }
                        scenario.Feature.Area.Reason = reason;
                        if(scenario.Feature.Area.ScenarioReasonStats.Keys.Contains(reason)) {
                            scenario.Feature.Area.ScenarioReasonStats[reason] = scenario.Feature.Area.ScenarioReasonStats[reason] + 1;
                        } else {
                            scenario.Feature.Area.ScenarioReasonStats.Add(reason, 1);
                        }
                        this.TestRun.Reason = reason;
                        if(this.TestRun.ScenarioReasonStats.Keys.Contains(reason)) {
                            this.TestRun.ScenarioReasonStats[reason] = this.TestRun.ScenarioReasonStats[reason] + 1;
                        } else {
                            this.TestRun.ScenarioReasonStats.Add(reason, 1);
                        }
                    });
                
            });

            sortedReasons.ForEach(reason => {
                TestRun.Scenarios.
                    Select(scenario => scenario.Feature)
                    .ToList()
                    .Where(feature => feature.Reason == reason)
                    .ToList().ForEach(feature => {
                        if(feature.Area.FeatureReasonStats.Keys.Contains(reason)) {
                            feature.Area.FeatureReasonStats[reason] = feature.Area.FeatureReasonStats[reason] + 1;
                        } else {
                            feature.Area.FeatureReasonStats.Add(reason, 1);
                        }
                        if(this.TestRun.FeatureReasonStats.Keys.Contains(reason)) {
                            this.TestRun.FeatureReasonStats[reason] = this.TestRun.FeatureReasonStats[reason] + 1;
                        } else {
                            this.TestRun.FeatureReasonStats.Add(reason, 1);
                        }
                    });
                
            });

            sortedReasons.ForEach(reason => {
                TestRun.Areas
                    .Where(area => area.Reason == reason)
                    .ToList().ForEach(area => {
                        if(this.TestRun.AreaReasonStats.Keys.Contains(reason)) {
                            this.TestRun.AreaReasonStats[reason] = this.TestRun.AreaReasonStats[reason] + 1;
                        } else {
                            this.TestRun.AreaReasonStats.Add(reason, 1);
                        }
                    });
                
            });
        }

        private void UpdateOutcomeStats(OutcomeStats stats, Outcome outcome) {
            switch(outcome) {
                case Outcome.Failed:
                    stats.Failed = stats.Failed + 1;
                    stats.Total = stats.Total + 1;
                break;
                case Outcome.Skipped:
                    stats.Skipped = stats.Skipped + 1;
                    stats.Total = stats.Total + 1;
                break;
                case Outcome.Passed:
                    stats.Passed = stats.Passed + 1;
                    stats.Total = stats.Total + 1;
                break;
            }
        }

        private void ClearStats(OutcomeStats stats) {
            stats.Total = 0;
            stats.Failed = 0;
            stats.Passed = 0;
            stats.Skipped = 0;
        }

        /// <summary>
        /// Updates the feature, area, and test outcomes and stats based on the scenario outcomes.
        /// </summary>
        public void UpdateStats()
        {
            List<Outcome> outcomes = new List<Outcome>() {
                Outcome.NotRun,
                Outcome.Passed,
                Outcome.Skipped,
                Outcome.Failed
            };
            TestRun.Scenarios.ToList().ForEach(scenario => {
                scenario.Feature.Outcome = Outcome.NotRun;
                scenario.Feature.Area.Outcome = Outcome.NotRun;
                scenario.Feature.Area.TestRun.Outcome = Outcome.NotRun;
                this.ClearStats(scenario.Feature.ScenarioStats);
                this.ClearStats(scenario.Feature.Area.ScenarioStats);
                this.ClearStats(scenario.Feature.Area.FeatureStats);
                this.ClearStats(scenario.Feature.Area.TestRun.ScenarioStats);
                this.ClearStats(scenario.Feature.Area.TestRun.FeatureStats);
                this.ClearStats(scenario.Feature.Area.TestRun.AreaStats);
            });
            outcomes.ForEach(outcome => {
                TestRun.Scenarios
                    .Where(scenario => scenario.Outcome == outcome)
                    .ToList().ForEach(scenario => {
                        scenario.Feature.Outcome = outcome;
                        this.UpdateOutcomeStats(scenario.Feature.ScenarioStats, outcome);
                        scenario.Feature.Area.Outcome = outcome;
                        this.UpdateOutcomeStats(scenario.Feature.Area.ScenarioStats, outcome);
                        TestRun.Outcome = outcome;
                        this.UpdateOutcomeStats(TestRun.ScenarioStats, outcome);
                    });
                TestRun.Scenarios.Select(x => x.Feature).ToList()
                    .Where(feature => feature.Outcome == outcome)
                    .ToList().ForEach(feature => {
                        this.UpdateOutcomeStats(feature.Area.FeatureStats, outcome);
                        this.UpdateOutcomeStats(TestRun.FeatureStats, outcome);
                    });
                TestRun.Scenarios.Select(x => x.Feature.Area).ToList()
                    .Where(area => area.Outcome == outcome)
                    .ToList().ForEach(area => {
                        this.UpdateOutcomeStats(TestRun.AreaStats, outcome);
                    });
                
            });
        }

        /// <summary>
        /// Updates the features sort property.  Features are sorted based on the 
        /// list of feature names you provide.  Scenarios are sorted based on thier 
        /// sort order that you can provide when creating the scenario xB.AddScenario(this, 1 [sortOrder])
        /// </summary>
        /// <param name="sortedFeatureFullNames">The sorted list of full feature names to use for sorting features. 
        /// Each feature name should be the full name with the namespace included.</param>
        public void SortTestRunResults(System.String[] sortedFeatureFullNames)
        {
            List<string> featureNames = new List<string>(sortedFeatureFullNames);
            var featureIndex = 0;
            featureNames.ForEach(featureFullName => {
                
                var feature = this.featureCache.GetByFullClassName(featureFullName);

                if(feature != null)
                {
                    featureIndex++;
                
                    feature.Sort = featureIndex;
                }

            });

            this.featureCache.GetAllFeatures().Where(x => x.Sort == 0).ToList().ForEach(feature => {
                feature.Sort = 1000000;
            });

            this.TestRun.Sorted = true;
        }

        internal ScenarioBuilder AddScenario(CodeDetails codeDetails, string scenarioName, string featureName, string areaName, int sortOrder)
        {

            if (scenarioName == null && codeDetails != null)
                scenarioName = codeDetails.Name.AddSpacesToSentence();

            if (featureName == null && codeDetails != null)
                featureName = codeDetails.GetClassName().AddSpacesToSentence();

            if (areaName == null && codeDetails != null)
                areaName = codeDetails.GetNameSpace().AddSpacesToSentence();
            
            var methodName = scenarioName;
            if(codeDetails != null)
                methodName = codeDetails.Name;

            var area = areaCache.GetOrCreate(TestRun, areaName);
            var feature = featureCache.GetOrCreate(area, featureName, codeDetails);
            return factory.CreateScenarioBuilder(scenarioName, feature, methodName, sortOrder);
        }
    }
}