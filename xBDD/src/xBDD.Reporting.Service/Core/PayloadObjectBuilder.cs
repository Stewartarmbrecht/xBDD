using System.Linq;
using xb = xBDD.Model;

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

        private void BuildScenarios(xb.TestRun testRun, TestRun testRunPayload)
        {
            var scenarios = from area in testRun.Areas
                            from feature in area.Features
                            from scenario in feature.Scenarios
                            select scenario; 
            foreach(xb.Scenario scenario in scenarios)
            {
                Scenario scenarioPayload = factory.CreateScenario(scenario, testRunPayload);
                testRunPayload.Scenarios.Add(scenarioPayload);
                BuildSteps(scenario, scenarioPayload);
            }
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