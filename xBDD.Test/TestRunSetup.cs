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
                            $"Area{areaCount.ToString().PadLeft(2,'0')}",
                            $"Feature{areaCount.ToString().PadLeft(2,'0')}{featureCount.ToString().PadLeft(2,'0')}",
                            $"Scenario{areaCount.ToString().PadLeft(2,'0')}{featureCount.ToString().PadLeft(2,'0')}{scenarioCount.ToString().PadLeft(2,'0')}",
                            $"As a user",
                            $"You can get some value",
                            $"By performing some action"
                        );
                        var scenario = xB.CurrentRun.AddScenario(codeDetails, scenarioCount);
                        for(int stepCount = 1; stepCount <= 3; stepCount++)
                        {
                            var stepId = $"{areaCount.ToString().PadLeft(2,'0')}{featureCount.ToString().PadLeft(2,'0')}{scenarioCount.ToString().PadLeft(2,'0')}{stepCount.ToString().PadLeft(2,'0')}";
                            var fail = false;
                            if(failingStepIds != null) {
                                fail = failingStepIds.Contains(stepId);
                            }
                            Step step = xB.CreateAsyncStep(
                                $"Step{stepId}",
                                null,
                                @"This 
is 
multiline 
text.",
                                TextFormat.text
                            );
                            if(fail) {
                                step.ActionAsync = async (s) => { await Task.Run(() => {throw new System.Exception("My exception");}); };
                            } else {
                                step.ActionAsync = async (s) => { await Task.Run(() => { 
                                    step.Output = @"This
is
multiline
output";
                                    step.OutputFormat = TextFormat.sh;
                                }); };
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