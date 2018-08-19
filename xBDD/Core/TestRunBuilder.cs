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
        /// Updates the features sort property.  Features are sorted based on the 
        /// list of feature names you provide.  Scenarios are sorted based on thier 
        /// sort order that you can provide when creating the scenario xB.AddScenario(this, 1 [sortOrder])
        /// </summary>
        /// <param name="sortedFeatureNames">The sorted list of feature names to use for sorting features.</param>
        public void SortTestRunResults(System.String[] sortedFeatureNames)
        {
            List<string> featureNames = new List<string>(sortedFeatureNames);
            var featureIndex = 0;
            featureNames.ForEach(featureName => {
                
                var feature = this.featureCache.GetByClassName(featureName);

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
                areaName = codeDetails.GetNameSpace();
            
            var methodName = scenarioName;
            if(codeDetails != null)
                methodName = codeDetails.Name;

            var area = areaCache.GetOrCreate(TestRun, areaName);
            var feature = featureCache.GetOrCreate(area, featureName, codeDetails);
            return factory.CreateScenarioBuilder(scenarioName, feature, methodName, sortOrder);
        }
    }
}