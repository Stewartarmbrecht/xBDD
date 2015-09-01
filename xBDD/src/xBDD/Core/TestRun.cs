using System;
using System.Collections.Generic;

namespace xBDD.Core
{
    public class TestRun : ITestRun
    {
        IFactory factory;
        List<IScenario> scenarios;
        List<IStep> steps;
        public TestRun(IFactory factory)
        {
            this.factory = factory;
            this.scenarios = new List<IScenario>();
            this.steps = new List<IStep>();
        }

        public ICollection<IScenario> Scenarios
        {
            get
            {
                return scenarios;
            }
        }

        public ICollection<IStep> Steps
        {
            get
            {
                return steps;
            }
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
            var test = factory.CreateScenario(this);
            test.Name = factory.GetScenarioNameReader().ReadScenarioName(scenarioName, method);
            test.FeatureName = factory.GetFeatureNameReader().ReadFeatureName(featureName, method);
            test.AreaPath = factory.GetAreaPathReader().ReadAreaPath(areaPath, method);
            return test;
        }
    }
}
