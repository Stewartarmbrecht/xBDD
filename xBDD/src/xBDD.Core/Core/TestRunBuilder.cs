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
        public TestRun TestRun { get; private set; }

        public TestRunBuilder(CoreFactory factory, TestRun testRun)
        {
            this.factory = factory;
            areaCache = factory.CreateAreaCache();
            featureCache = factory.CreateFeatureCache();
            TestRun = testRun;
        }

        public ScenarioBuilder AddScenario(object featureClass, [CallerMemberName]string methodName = "")
        {
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
        private ScenarioBuilder AddScenario(Method method, string scenarioName, string featureName, string areaPath)
        {
            if (scenarioName == null && method != null)
                scenarioName = method.Name.AddSpacesToSentence(true);

            if (featureName == null && method != null)
                featureName = method.GetClassName().AddSpacesToSentence(true);

            if (areaPath == null && method != null)
                areaPath = method.GetNameSpace();
            
            var area = areaCache.GetOrCreate(TestRun, areaPath);
            var feature = featureCache.GetOrCreate(area, featureName);
            return factory.CreateScenarioBuilder(scenarioName, feature);
        }
    }
}