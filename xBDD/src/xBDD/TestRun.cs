using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace xBDD
{
    public class TestRun : ITestRun
    {
        static ITestRun testRun;
        public static ITestRun Current
        {
            get
            {
                if (testRun == null)
                {
                    IFactory factory = new Factory();
                    testRun = new TestRun(factory);
                }
                return testRun;
            }
        }

        IFactory factory;
        TestRun(IFactory factory)
        {
            this.factory = factory;
        }

        public IScenario AddScenario()
        {
            IMethod method = factory.GetMethodRetriever().GetScenarioMethod();
            return AddScenario(method, null, null, null);
        }

        public IScenario AddScenario(string scenarioName)
        {
            IMethod method = factory.GetMethodRetriever().GetScenarioMethod();
            return AddScenario(method, scenarioName, null, null);
        }

        public IScenario AddScenario(string scenarioName, string featureName)
        {
            IMethod method = factory.GetMethodRetriever().GetScenarioMethod();
            return AddScenario(method, scenarioName, featureName, null);
        }

        public IScenario AddScenario(string scenarioName, string featureName, string areaPath)
        {
            IMethod method = factory.GetMethodRetriever().GetScenarioMethod();
            return AddScenario(method, scenarioName, featureName, areaPath);
        }

        public IScenario AddScenario(IMethod method, string scenarioName, string featureName, string areaPath)
        {
            var test = factory.CreateFeature();
            test.Name = factory.GetScenarioNameReader().ReadScenarioName(scenarioName, method);
            test.FeatureName = factory.GetFeatureNameReader().ReadFeatureName(featureName, method);
            test.AreaPath = factory.GetAreaPathReader().ReadAreaPath(areaPath, method);
            return test;
        }
    }
}
