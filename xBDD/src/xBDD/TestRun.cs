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
            return AddScenario(null, null, null, method);
        }

        public IScenario AddScenario(string scenarioName)
        {
            IMethod method = factory.GetMethodRetriever().GetScenarioMethod();
            return AddScenario(null, null, scenarioName, method);
        }

        public IScenario AddScenario(string scenarioName, string featureName)
        {
            IMethod method = factory.GetMethodRetriever().GetScenarioMethod();
            return AddScenario(null, featureName, scenarioName, method);
        }

        public IScenario AddScenario(string scenarioName, string featureName, string areaPath)
        {
            IMethod method = factory.GetMethodRetriever().GetScenarioMethod();
            return AddScenario(areaPath, featureName, scenarioName, method);
        }

        public IScenario AddScenario(string areaPath, string featureName, string scenarioName, IMethod method)
        {
            var test = factory.CreateFeature();
            test.Name = factory.GetScenarioNameReader().ReadScenarioName(scenarioName, method);
            test.FeatureName = factory.GetFeatureNameReader().ReadFeatureName(featureName, method);
            test.AreaPath = method.GetNameSpace();
            return test;
        }
    }
}
