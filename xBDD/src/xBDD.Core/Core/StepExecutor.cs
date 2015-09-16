using System;
using System.Threading.Tasks;
using xBDD.Utility;

namespace xBDD.Core
{
    public class StepExecutor
    {
        StepExceptionHandler stepExceptionHandler;
        Scenario scenario;
        OutcomeAggregator outcomeAggregator;
        public StepExecutor(Scenario scenario, CoreFactory factory)
        {
            stepExceptionHandler = factory.CreateStepExceptionHandler(scenario);
            outcomeAggregator = factory.UtilityFactory.CreateOutcomeAggregator();
            this.scenario = scenario;
        }
        public async Task ExecuteStepAsync(Step step)
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

        public void ExecuteStep(Step step)
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
        private void PreExecution(Step step)
        {
            step.StartTime = DateTime.Now;
            if (step == scenario.Steps[0])
                scenario.StartTime = step.StartTime;
        }

        void PostExecution(Step step)
        {
            SetEndTimes(step);
            step.Outcome = Outcome.Passed;
            scenario.Outcome = outcomeAggregator.GetNewParentOutcome(scenario.Outcome, step.Outcome);
        }
        public void SetEndTimes(Step step)
        {
            step.EndTime = DateTime.Now;
            scenario.Time = scenario.Time.Add(step.EndTime.Subtract(step.StartTime));
            if (step == scenario.Steps[scenario.Steps.Count - 1])
                scenario.EndTime = step.EndTime;
        }

    }
}
