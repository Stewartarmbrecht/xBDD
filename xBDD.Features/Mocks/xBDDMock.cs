using System;
using System.Linq;
using System.Threading.Tasks;
using xBDD.Core;
using xBDD.Model;

namespace xBDD
{
    public class xBDDMock
    {
        CoreFactory factory;
        TestRunBuilder testRun;
        public TestRunBuilder CurrentRun
        {
            get
            {
                EnsureFactory();
                if (testRun == null)
                {
                    testRun = factory.CreateTestRunBuilder("My Test Run");
                }
                return testRun;
            }
        }

        void EnsureFactory()
        {
            if (factory == null)
                factory = new CoreFactory();
        }

        public Step CreateStep(string stepName, Action<Step> action = null, string multilineParameter = null, TextFormat format = TextFormat.text)
        {
            return xB.CreateStep(stepName, action, multilineParameter, format);
        }
        public Step CreateAsyncStep(string stepName, Func<Step, Task> action = null, string multilineParameter = null, TextFormat format = TextFormat.text)
        {
            return xB.CreateAsyncStep(stepName, action, multilineParameter, format);
        }

        internal async Task RunATestRunWithAFullTestRunWithAllOutcomes()
        {
            int stepCounter = 0;
            int scenarioCounter = 0;
            int featureCounter = 0;
            int[] skippedScenarios = new int[] { 10, 11, 13, 14, 20, 22, 23 };
            int failedSetp = 56;
            this.CurrentRun.TestRun.Name = "My Test Run";
            for(int ia = 0; ia < 3; ia++)
            {
                var areaName = "My Area " + (ia + 1);
                for(int ife = 0; ife < 3; ife++ )
                {
                    featureCounter++;
                    var featureName = "My Feature " + featureCounter;
                    for(int isc = 0; isc < 3; isc++ )
                    {
                        scenarioCounter++;
                        var scenarioName = "My Scenario " + scenarioCounter;
                        var scenario = this.CurrentRun.AddScenario(scenarioName, featureName, areaName);
                        stepCounter++;
                        scenario.Given("my step " + stepCounter, (s2) => { });
                        stepCounter++;
                        if(stepCounter == failedSetp)
                            scenario.When("my failed step " + stepCounter, (s2) => { throw new Exception("My Error"); });
                        else
                            scenario.When("my step 2", (s2) => { });
                        stepCounter++;
                        scenario.Then("my step 3", (s2) => { });
                        try
                        {
                            if(skippedScenarios.Contains(scenarioCounter))
                                await scenario.Skip("Deferred", reason => { } );
                            else
                                await scenario.Run();
                        }
                        catch { }
                    }                            
                }
            }
        }
    }
}
