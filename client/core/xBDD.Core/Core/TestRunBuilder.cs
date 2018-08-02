using System.Runtime.CompilerServices;
using xBDD.Model;
using xBDD.Utility;
namespace xBDD.Core
{
    public class TestRunBuilder
    {
        CoreFactory factory;
        AreaCache areaCache;
        FeatureCache featureCache;
        TestRunInitializer testRunInitializer;
        public TestRun TestRun { get; private set; }

        public TestRunBuilder(CoreFactory factory, TestRun testRun)
        {
            this.factory = factory;
            areaCache = factory.CreateAreaCache();
            featureCache = factory.CreateFeatureCache();
            testRunInitializer = factory.CreateTestRunInitializer();
            TestRun = testRun;
        }

        /// <summary>
        /// This method should be called from within the test method.
        /// It uses reflection to get the calling method name and it expects
        /// to recieve a reference of the test class to get the name of the 
        /// feature and namespace.
        /// </summary>
        /// <param name="featureClass"></param>
        /// <param name="methodName"></param>
        /// <returns></returns>
        public ScenarioBuilder AddScenario(object featureClass, [CallerMemberName]string methodName = "")
        {
            testRunInitializer.InitializeTestRun(featureClass, TestRun);
            Method method = factory.UtilityFactory.GetMethodRetriever().GetScenarioMethod(featureClass, methodName);
            return AddScenario(method, null, null, null);
        }
        public ScenarioBuilder AddScenario(string scenarioName, 
            object featureClass, [CallerMemberName]string methodName = "")
        {
            Method method = factory.UtilityFactory.GetMethodRetriever().GetScenarioMethod(featureClass, methodName);
            return AddScenario(method, scenarioName, null, null);
        }
        public ScenarioBuilder AddScenario(string scenarioName, string featureName, 
            object featureClass, [CallerMemberName]string methodName = "")
        {
            Method method = factory.UtilityFactory.GetMethodRetriever().GetScenarioMethod(featureName, methodName);
            return AddScenario(method, scenarioName, featureName, null);
        }
        public ScenarioBuilder AddScenario(string scenarioName, string featureName, string areaPath)
        {
            return AddScenario(null, scenarioName, featureName, areaPath);
        }
        private ScenarioBuilder AddScenario(Method method, string scenarioName, string featureName, string areaName)
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