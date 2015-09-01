using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using xBDD.Core;

namespace xBDD.Test.Utilities
{
    public class TestRunBuilder
    {
        public ITestRun BuildPassingTestRun()
        {
            IFactory factory = new Factory();
            ITestRun testRun = new TestRun(factory);

            for (int i = 0; i < 3; i++)
            {
                var area = "Sample.Area" + (i + 1).ToString();
                BuildFeatures(testRun, area);
            }

            return testRun;
        }

        private void BuildFeatures(ITestRun testRun, string area)
        {
            for (int i = 0; i < 3; i++)
            {
                var feature = "Feature " + (i + 1).ToString();
                BuildScenarios(testRun, area, feature);
            }
        }

        private void BuildScenarios(ITestRun testRun, string area, string feature)
        {
            for (int i = 0; i < 3; i++)
            {
                var scenario = testRun.AddScenario(area, feature, "Scenario " + (i + 1).ToString());
                scenario.Given("Condition 1", step => { });
                scenario.And("Condition 2", step => { });
                scenario.When("Action 1", step => { });
                scenario.Then("Validation 1", step => { });
                scenario.Run();
            }
        }
    }
}
