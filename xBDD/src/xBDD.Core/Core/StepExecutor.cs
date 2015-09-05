using System;
using System.Threading.Tasks;
using xBDD.Utility;

namespace xBDD.Core
{
    public class StepExecutor : IStepExecutor
    {
        IStepExceptionHandler stepExceptionHandler;
        IScenarioInternal scenario;
        IOutcomeAggregator outcomeAggregator;
        public StepExecutor(IScenarioInternal scenario, IFactory factory)
        {
            stepExceptionHandler = factory.CreateStepExceptionHandler(scenario);
            outcomeAggregator = factory.CreateOutcomeAggregator();
            this.scenario = scenario;
        }
        public async Task ExecuteStepAsync(IStep step)
        {
            try
            {
                PreExecution(step);
                if (step.ActionAsync == null && step.Action != null)
                {
                    await Task.Run(() => { step.Action(step); });
                }
                else
                {
                    await step.ActionAsync(step);
                }
                PostExecution(step);
            }
            catch (Exception ex)
            {
                stepExceptionHandler.HandleException(this, step, ex);
            }
        }

        public void ExecuteStep(IStep step)
        {
            try
            {
                PreExecution(step);
                step.Action(step);
                PostExecution(step);
            }
            catch (Exception ex)
            {
                stepExceptionHandler.HandleException(this, step, ex);
            }
        }
        private void PreExecution(IStep step)
        {
            step.StartTime = DateTime.Now;
            if (step == scenario.Steps[0])
                scenario.StartTime = step.StartTime;
        }

        void PostExecution(IStep step)
        {
            SetEndTimes(step);
            step.Outcome = Outcome.Passed;
            scenario.Outcome = outcomeAggregator.GetNewParentOutcome(scenario.Outcome, step.Outcome);
        }
        public void SetEndTimes(IStep step)
        {
            step.EndTime = DateTime.Now;
            scenario.Time = scenario.Time.Add(step.EndTime.Subtract(step.StartTime));
            if (step == scenario.Steps[scenario.Steps.Count - 1])
                scenario.EndTime = step.EndTime;
        }

    }
}
