namespace xBDD.Test
{
    using xBDD;
    using xBDD.Utility;
    using xBDD.Model;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public static class TestRunSetup
    {
        public static async Task<TestRun> BuildTestRun(
            List<string> failingStepIds = null, 
            Dictionary<string, string> skippedScenarioIdsAndReasons = null)
        {
            for(int capabilityCount = 1; capabilityCount <= 3; capabilityCount++)
            {
                for(int featureCount = 1; featureCount <= 3; featureCount++)
                {
                    for(int scenarioCount = 1; scenarioCount <= 3; scenarioCount++)
                    {
                        var scenarioId = $"{capabilityCount.ToString().PadLeft(2,'0')}{featureCount.ToString().PadLeft(2,'0')}{scenarioCount.ToString().PadLeft(2,'0')}";
                        var codeDetails = new CodeDetails(
                            $"Capability{capabilityCount.ToString().PadLeft(2,'0')}",
                            $"Feature{capabilityCount.ToString().PadLeft(2,'0')}{featureCount.ToString().PadLeft(2,'0')}",
                            $"Scenario{scenarioId}",
                            $"As a user",
                            $"So that you get some value",
                            $"You can perform some action",
							null,
                            TextFormat.text,
							null,
                            TextFormat.text,
							null,
							null,
							null,
							null
                        );
                        var scenario = xB.CurrentRun.AddScenario(codeDetails, scenarioCount);
                        string skipReason = null;
                        if(skippedScenarioIdsAndReasons != null && skippedScenarioIdsAndReasons.ContainsKey(scenarioId)) {
                            skipReason = skippedScenarioIdsAndReasons[scenarioId];
                        }
                        for(int stepCount = 1; stepCount <= 3; stepCount++)
                        {
                            var stepId = $"{capabilityCount.ToString().PadLeft(2,'0')}{featureCount.ToString().PadLeft(2,'0')}{scenarioCount.ToString().PadLeft(2,'0')}{stepCount.ToString().PadLeft(2,'0')}";
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
                            if(skipReason != null) {
                                await scenario.Skip(skipReason, Assert.Inconclusive);
                            }
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