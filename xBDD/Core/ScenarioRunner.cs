using System;
using System.Linq;
using System.Threading.Tasks;
using xBDD.Model;

namespace xBDD.Core
{
    internal class ScenarioRunner
    {
        Scenario scenario;
        CoreFactory factory;
        StepExecutor stepExecutor;
        ScenarioOutputWriter outputWriter;
        StatsCascader statsCascader;
        internal ScenarioRunner(Scenario scenario, CoreFactory factory)
        {
            this.scenario = scenario;
            this.factory = factory;
            stepExecutor = factory.CreateStepExecutor(scenario);
            statsCascader = factory.UtilityFactory.CreateStatsCascader();
            this.SetOutputWriter(new OutputWriter());
        }

        private void ProcessScenarioWhenThereAreNoSteps()
        {
            scenario.StartTime = DateTime.Now;
            scenario.EndTime = scenario.StartTime;
            if (scenario.Outcome == Outcome.NotRun) {
                scenario.Outcome = Outcome.Passed;
				scenario.Reason = "Passed";
			}
            statsCascader.CascadeSkippedOrNotRunScenarioStats(scenario);
        }

        public async Task RunAsync(bool passWhenNoAction)
        {
            scenario.StartTime = DateTime.Now;
            if(outputWriter != null)
                outputWriter.WriteOutput();

            if (scenario.Steps.Count() == 0)
            {
                ProcessScenarioWhenThereAreNoSteps();
            }
            else
            {
                try 
                {
                    foreach (var step in scenario.Steps)
                    {
                        if(passWhenNoAction)
                        {
                            step.Outcome = Outcome.Passed;
							step.Reason = "Passed";
                            step.StartTime = DateTime.Now;
                            step.EndTime = step.StartTime;
                            statsCascader.CascadeStepStats(step, false);
                        }
                        else
                        {
                            if (step.ActionAsync == null && step.Action == null)
                            {
                                var notImplementedException = new NotImplementedException();
                                var ex = new StepNotImplementedException(step.Name, notImplementedException);
                                step.StartTime = DateTime.Now;
                                step.EndTime = step.StartTime;
                                step.Outcome = Outcome.Failed;
                                step.Exception = ex;
                                step.Reason = "Failed";
                                statsCascader.CascadeStepStats(step, false);
                                throw ex; 
                            }
                            await stepExecutor.ExecuteStepAsync(step);
                        }
                    }
                }
                catch
                {
                    foreach(var step in scenario.Steps)
                    {
                        if(step.Outcome == Outcome.NotRun)
                        {
                            step.StartTime = DateTime.Now;
                            step.EndTime = step.StartTime;
                            step.Outcome = Outcome.Skipped;
                            step.Reason = "Previous Error";
                            statsCascader.CascadeStepStats(step, false);
                        }
                    }
                    scenario.EndTime = DateTime.Now;
                    throw;
                }
            }
            scenario.EndTime = DateTime.Now;
        }

        private void SkipSteps()
        {
            scenario.StartTime = DateTime.Now;
            foreach (var step in scenario.Steps)
            {
                step.StartTime = DateTime.Now;
                step.EndTime = step.StartTime;
                step.Outcome = Outcome.Skipped;
                step.Reason = "Scenario Skipped";
                statsCascader.CascadeStepStats(step, true);
            }
            scenario.EndTime = DateTime.Now;
        }

        public async Task Skip(string reason)
        {
            scenario.StartTime = DateTime.Now;
            if (reason == null)
                throw new ArgumentNullException("reason");
            if(scenario.Steps.Count > 0)
            {
                SkipSteps();
                scenario.Reason = reason;
            }
            else
            {
                scenario.Outcome = Outcome.Skipped;
                scenario.Reason = reason;
                statsCascader.CascadeSkippedOrNotRunScenarioStats(scenario);
            }
            await Task.Run(() => {});
            scenario.EndTime = DateTime.Now;
        }

        public void SetOutputWriter(IOutputWriter outputWriter)
        {
            this.outputWriter = factory.CreateScenarioOutputWriter(scenario, outputWriter);
        }
    }
}
