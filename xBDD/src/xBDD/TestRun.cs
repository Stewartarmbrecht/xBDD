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
            return AddScenario(null, method);
        }

        public IScenario AddScenario(string testName)
        {
            IMethod method = factory.GetMethodRetriever().GetScenarioMethod();
            return AddScenario(testName, method);
        }

        public IScenario AddScenario(string testName, IMethod method)
        {
            var test = factory.CreateFeature();
            test.Name = factory.GetScenarioNameReader().ReadScenarioName(testName, method);
            test.FeatureName = factory.GetFeatureNameReader().ReadFeatureName(method);
            test.AreaPath = method.GetNameSpace();
            return test;
        }
    }
}
