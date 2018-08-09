using System.Runtime.CompilerServices;
using xBDD.Model;
using xBDD.Utility;
namespace xBDD.Core
{
    /// <summary>
    /// Provides methods for building a test run by adding scenarios.
    /// </summary>
    public class TestRunBuilder
    {
        CoreFactory factory;
        AreaCache areaCache;
        FeatureCache featureCache;
        internal TestRunInitializer TestRunInitializer { get; private set; }

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
            this.TestRunInitializer = factory.CreateTestRunInitializer();
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
        /// <returns>The scenario build for a fluent syntax.</returns>
        public ScenarioBuilder AddScenario(object featureClass, [CallerMemberName]string methodName = "")
        {
            this.TestRunInitializer.InitializeTestRun(featureClass, TestRun);
            Method method = factory.UtilityFactory.GetMethodRetriever().GetScenarioMethod(featureClass, methodName);
            return AddScenario(method, null, null, null);
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
        /// <returns>The scenario build for a fluent syntax.</returns>
        public ScenarioBuilder AddScenario(string scenarioName, 
            object featureClass, [CallerMemberName]string methodName = "")
        {
            Method method = factory.UtilityFactory.GetMethodRetriever().GetScenarioMethod(featureClass, methodName);
            return AddScenario(method, scenarioName, null, null);
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
        /// <returns>The scenario build for a fluent syntax.</returns>
        public ScenarioBuilder AddScenario(string scenarioName, string featureName, 
            object featureClass, [CallerMemberName]string methodName = "")
        {
            Method method = factory.UtilityFactory.GetMethodRetriever().GetScenarioMethod(featureName, methodName);
            return AddScenario(method, scenarioName, featureName, null);
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
        /// <returns>The scenario build for a fluent syntax.</returns>
        public ScenarioBuilder AddScenario(string scenarioName, string featureName, string areaPath)
        {
            return AddScenario(null, scenarioName, featureName, areaPath);
        }

        internal ScenarioBuilder AddScenario(Method method, string scenarioName, string featureName, string areaName)
        {
            if (scenarioName == null && method != null)
                scenarioName = method.Name.AddSpacesToSentence();

            if (featureName == null && method != null)
                featureName = method.GetClassName().AddSpacesToSentence();

            if (areaName == null && method != null)
                areaName = method.GetNameSpace();
            
            var area = areaCache.GetOrCreate(TestRun, areaName);
            var feature = featureCache.GetOrCreate(area, featureName, method);
            return factory.CreateScenarioBuilder(scenarioName, feature);
        }
    }
}