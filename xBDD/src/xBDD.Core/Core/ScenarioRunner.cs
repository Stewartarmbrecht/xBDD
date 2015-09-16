using System;
using System.Linq;
using System.Threading.Tasks;

namespace xBDD.Core
{
    internal class ScenarioRunner
    {
        Scenario scenario;
        CoreFactory factory;
        StepExecutor stepExecutor;
        ScenarioOutputWriter outputWriter;
        internal ScenarioRunner(Scenario scenario, CoreFactory factory)
        {
            this.scenario = scenario;
            this.factory = factory;
            stepExecutor = factory.CreateStepExecutor(scenario);
        }

        public void Run()
        {
            if (scenario.Steps.Count() == 0)
            {
                ProcessScenarioWhenThereAreNoSteps();
            }
            else
            {
                foreach (var step in scenario.Steps)
                {
                    if (step.Action == null)
                        throw new AsyncStepInSyncScenarioException(step.Name);
                    stepExecutor.ExecuteStep(step);
                }
            }
            if (outputWriter != null)
                outputWriter.WriteOutput();
            if (scenario.FirstStepException != null)
                throw scenario.FirstStepException;
        }

        private void ProcessScenarioWhenThereAreNoSteps()
        {
            scenario.StartTime = DateTime.Now;
            scenario.EndTime = scenario.StartTime;
            scenario.Time = new TimeSpan();
            if (scenario.Outcome == Outcome.NotRun)
                scenario.Outcome = Outcome.Passed;
        }

        public async Task RunAsync()
        {
            if (scenario.Steps.Count() == 0)
            {
                ProcessScenarioWhenThereAreNoSteps();
            }
            else
            {
                foreach (var step in scenario.Steps)
                {
                    await stepExecutor.ExecuteStepAsync(step);
                }
            }
            if(outputWriter != null)
                outputWriter.WriteOutput();
            if (scenario.FirstStepException != null)
                throw scenario.FirstStepException;
        }

        public void Skip(string reason)
        {
            if (reason == null)
                throw new ArgumentNullException("reason");
            scenario.Outcome = Outcome.Skipped;
            scenario.Reason = reason;
            scenario.FirstStepException = new SkipScenarioException(reason);
            Run();
        }
        public async Task SkipAsync(string reason)
        {
            if (reason == null)
                throw new ArgumentNullException("reason");
            scenario.Outcome = Outcome.Skipped;
            scenario.Reason = reason;
            scenario.FirstStepException = new SkipScenarioException(reason);
            await RunAsync();
        }

        public void SetOutputWriter(IOutputWriter outputWriter)
        {
            this.outputWriter = factory.CreateScenarioOutputWriter(scenario, outputWriter);
        }
    }
}
