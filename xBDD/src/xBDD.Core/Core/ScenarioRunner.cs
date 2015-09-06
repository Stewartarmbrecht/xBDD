using System;
using System.Linq;
using System.Threading.Tasks;

namespace xBDD.Core
{
    internal class ScenarioRunner : IScenarioRunner
    {
        IScenarioInternal scenario;
        ICoreFactory factory;
        IStepExecutor stepExecutor;
        internal ScenarioRunner(IScenarioInternal scenario, ICoreFactory factory)
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
            if (scenario.FirstStepException != null)
                throw scenario.FirstStepException;
        }

        public void Skip()
        {
            scenario.Outcome = Outcome.Skipped;
            scenario.FirstStepException = new SkipScenarioException("Scenario Skipped", new SkipStepException("Scenario Skipped"));
            Run();
        }
        public async Task SkipAsync()
        {
            scenario.Outcome = Outcome.Skipped;
            scenario.FirstStepException = new SkipScenarioException("Scenario Skipped", new SkipStepException("Scenario Skipped"));
            await RunAsync();
        }
    }
}
