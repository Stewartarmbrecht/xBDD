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
        }

        public void Run(bool passWhenNoAction)
        {
            if (outputWriter != null)
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
                        if (step.Action == null && !passWhenNoAction)
                        {
                            if(step.ActionAsync != null)
                            {
                                var ex = new AsyncStepInSyncScenarioException(step.Name);
                                step.Outcome = Outcome.Failed;
                                step.Exception = ex;
                                step.Reason = "Async Step in Sync Scenario";
                                statsCascader.CascadeStats(step);
                                throw ex; 
                            }
                            else
                            {
                                var notImplementedException = new NotImplementedException();
                                var ex = new StepNotImplementedException(step.Name, notImplementedException);
                                step.Outcome = Outcome.Failed;
                                step.Exception = ex;
                                step.Reason = "No Action";
                                statsCascader.CascadeStats(step);
                                throw ex; 
                            }
                        }
                        if(passWhenNoAction)
                        {
                            step.Outcome = Outcome.Passed;
                            statsCascader.CascadeStats(step);
                        }
                        else
                        {
                            stepExecutor.ExecuteStep(step);
                        }
                    }
                }
                catch(Exception ex)
                {
                    var t = ex;
                    foreach(var step in scenario.Steps)
                    {
                        if(step.Outcome == Outcome.NotRun)
                        {
                            step.Outcome = Outcome.Skipped;
                            step.Reason = "Previous Error";
                        }
                    }
                    throw;
                }
            }
        }

        private void ProcessScenarioWhenThereAreNoSteps()
        {
            scenario.StartTime = DateTime.Now;
            scenario.EndTime = scenario.StartTime;
            if (scenario.Outcome == Outcome.NotRun)
                scenario.Outcome = Outcome.Passed;
            statsCascader.CascadeStats(scenario);
        }

        public async Task RunAsync()
        {
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
                        await stepExecutor.ExecuteStepAsync(step);
                    }
                }
                catch(Exception ex)
                {
                    var t = ex;
                    foreach(var step in scenario.Steps)
                    {
                        if(step.Outcome == Outcome.NotRun)
                        {
                            step.Outcome = Outcome.Skipped;
                            step.Reason = "Previous Error";
                        }
                        throw;
                    }
                }
            }
        }

        public void Skip(string reason)
        {
            if (reason == null)
                throw new ArgumentNullException("reason");
            scenario.Outcome = Outcome.Skipped;
            scenario.Reason = reason;
            if(scenario.Steps.Count > 0)
                SkipSteps();
            else
                statsCascader.CascadeStats(scenario);
        }

        private void SkipSteps()
        {
            foreach (var step in scenario.Steps)
            {
                step.Outcome = Outcome.Skipped;
                step.Reason = "Scenario Skipped";
                statsCascader.CascadeStats(step);
            }
        }

        public async Task SkipAsync(string reason)
        {
            if (reason == null)
                throw new ArgumentNullException("reason");
            scenario.Outcome = Outcome.Skipped;
            scenario.Reason = reason;
            if(scenario.Steps.Count > 0)
                SkipSteps();
            else
                statsCascader.CascadeStats(scenario);
            await Task.Run(() => {});
        }

        public void SetOutputWriter(IOutputWriter outputWriter)
        {
            this.outputWriter = factory.CreateScenarioOutputWriter(scenario, outputWriter);
        }
    }
}
