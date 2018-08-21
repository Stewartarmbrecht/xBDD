namespace xBDD.Test
{
    using xBDD;
    using xBDD.Utility;
    using xBDD.Model;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    public static class TestRunSetup
    {
        public static async Task<TestRun> BuildTestRun(List<string> failingStepIds = null)
        {
            for(int areaCount = 1; areaCount <= 3; areaCount++)
            {
                for(int featureCount = 1; featureCount <= 3; featureCount++)
                {
                    for(int scenarioCount = 1; scenarioCount <= 3; scenarioCount++)
                    {
                        var codeDetails = new CodeDetails(
                            $"area_{areaCount}",
                            $"feature_{areaCount}_{featureCount}",
                            $"scenario_{areaCount}_{featureCount}_{scenarioCount}",
                            $"As a user",
                            $"You can get some value",
                            $"By performing some action"
                        );
                        var scenario = xB.CurrentRun.AddScenario(codeDetails, scenarioCount);
                        for(int stepCount = 1; stepCount <= 3; stepCount++)
                        {
                            var stepId = $"{areaCount}-{featureCount}-{scenarioCount}-{stepCount}";
                            var fail = false;
                            if(failingStepIds != null) {
                                fail = failingStepIds.Contains(stepId);
                            }
                            Step step = xB.CreateAsyncStep(
                                $"step-{stepId}",
                                null
                            );
                            if(fail) {
                                step.ActionAsync = async (s) => { await Task.Run(() => {throw new System.Exception("My exception");}); };
                            } else {
                                step.ActionAsync = async (s) => { await Task.Run(() => { }); };
                            }
                            switch(stepCount) {
                                case 1:
                                    scenario.Given(step);
                                break;
                                case 2:
                                    scenario.When(step);
                                break;
                                case 3:
                                    scenario.Then(step);
                                break;
                            }
                        }
                        try {
                            await scenario.Run();
                        } catch {
                            
                        }
                    }
                }
            }

            return xB.CurrentRun.TestRun;
        }
    }
}