using System;
using System.Collections.Generic;
using xBDD.Utility;

namespace xBDD.Core
{
    public class TestRun : ITestRun
    {
        ICoreFactory factory;
        List<IScenario> scenarios;
        List<IStep> steps;

        public TestRun(ICoreFactory factory)
        {
            this.factory = factory;
            scenarios = new List<IScenario>();
            steps = new List<IStep>();
        }

        public string Name { get; set; }

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
            IMethod method = factory.UtilityFactory.GetMethodRetriever().GetScenarioMethod();
            return AddScenario(method, null, null, null);
        }
        public IScenario AddScenario(string scenarioName)
        {
            IMethod method = factory.UtilityFactory.GetMethodRetriever().GetScenarioMethod();
            return AddScenario(method, scenarioName, null, null);
        }
        public IScenario AddScenario(string scenarioName, string featureName)
        {
            IMethod method = factory.UtilityFactory.GetMethodRetriever().GetScenarioMethod();
            return AddScenario(method, scenarioName, featureName, null);
        }
        public IScenario AddScenario(string scenarioName, string featureName, string areaPath)
        {
            IMethod method = factory.UtilityFactory.GetMethodRetriever().GetScenarioMethod();
            return AddScenario(method, scenarioName, featureName, areaPath);
        }
        public IScenario AddScenario(IMethod method, string scenarioName, string featureName, string areaPath)
        {
            var test = factory.CreateScenario(this);
            test.Name = factory.UtilityFactory.GetScenarioNameReader().ReadScenarioName(scenarioName, method);
            test.FeatureName = factory.UtilityFactory.GetFeatureNameReader().ReadFeatureName(featureName, method);
            test.AreaPath = factory.UtilityFactory.GetAreaPathReader().ReadAreaPath(areaPath, method);
            return test;
        }

    }
}
