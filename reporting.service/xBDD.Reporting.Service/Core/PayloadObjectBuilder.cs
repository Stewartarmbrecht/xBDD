using System.Linq;
using System.Collections.Generic;
using xb = xBDD.Model;
using xBDD.API.Model;
using xBDD.API.Model.Entities;
using xBDD.API.Model.Messages;

namespace xBDD.Reporting.Service.Core
{
    public class PayloadObjectBuilder
    {
        private PayloadFactory factory;

        public PayloadObjectBuilder(PayloadFactory factory)
        {
            this.factory = factory;
        }

        public TestRun BuildTestRun(xb.TestRun testRun)
        {
            var testRunPayload = factory.CreateTestRun(testRun);
            BuildScenarios(testRun, testRunPayload);
            return testRunPayload;
        }

        public List<Scenario> BuildScenarios(xb.TestRun testRun, TestRun testRunPayload)
        {
            var list = new List<Scenario>();
            var scenarios = from area in testRun.Areas
                            from feature in area.Features
                            from scenario in feature.Scenarios
                            select scenario; 
            foreach(xb.Scenario scenario in scenarios)
            {
                Scenario scenarioPayload = factory.CreateScenario(scenario, testRunPayload);
                list.Add(scenarioPayload);
                BuildSteps(scenario, scenarioPayload);
            }
            return list;
        }

        private void BuildSteps(xb.Scenario scenario, Scenario scenarioPayload)
        {
            foreach(var step in scenario.Steps)
            {
                Step stepPayload = factory.CreateStep(step, scenarioPayload);
                scenarioPayload.Steps.Add(stepPayload);
            }
        }
    }
}