using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Reflection;
using xBDD.Utility;
using xBDD.Core;

namespace xBDD
{
    public class TestRun
    {
        CoreFactory factory;
        List<Scenario> scenarios;
        List<Step> steps;

        public TestRun(CoreFactory factory)
        {
            this.factory = factory;
            scenarios = new List<Scenario>();
            steps = new List<Step>();
        }

        public string Name { get; set; }

        public ICollection<Scenario> Scenarios
        {
            get
            {
                return scenarios;
            }
        }
        public ICollection<Step> Steps
        {
            get
            {
                return steps;
            }
        }

        public Scenario AddScenario(object featureClass, [CallerMemberName]string name = "")
        {
            Method method = factory.UtilityFactory.GetMethodRetriever().GetScenarioMethod(featureClass, name);
            return AddScenario(method, null, null, null);
        }
        public Scenario AddScenario(string scenarioName, 
            object featureClass, [CallerMemberName]string methodName = "")
        {
            Method method = factory.UtilityFactory.GetMethodRetriever().GetScenarioMethod(featureClass, methodName);
            return AddScenario(method, scenarioName, null, null);
        }
        public Scenario AddScenario(string scenarioName, string featureName, 
            object featureClass, [CallerMemberName]string methodName = "")
        {
            Method method = factory.UtilityFactory.GetMethodRetriever().GetScenarioMethod(featureName, methodName);
            return AddScenario(method, scenarioName, featureName, null);
        }
        public Scenario AddScenario(string scenarioName, string featureName, string areaPath,
            object featureClass, [CallerMemberName]string methodName = "")
        {
            Method method = factory.UtilityFactory.GetMethodRetriever().GetScenarioMethod(featureClass, methodName);
            return AddScenario(method, scenarioName, featureName, areaPath);
        }
        internal Scenario AddScenario(Method method, string scenarioName, string featureName, string areaPath)
        {
            var test = factory.CreateScenario(this);
            if (scenarioName == null && method != null)
                test.Name = factory.UtilityFactory.GetScenarioNameReader().ReadScenarioName(scenarioName, method);
            else
                test.Name = scenarioName;

            if (featureName == null && method != null)
                test.FeatureName = factory.UtilityFactory.GetFeatureNameReader().ReadFeatureName(featureName, method);
            else
                test.FeatureName = featureName;

            if (areaPath == null && method != null)
                test.AreaPath = factory.UtilityFactory.GetAreaPathReader().ReadAreaPath(areaPath, method);
            else
                test.AreaPath = areaPath;
            return test;
        }
    }
}
