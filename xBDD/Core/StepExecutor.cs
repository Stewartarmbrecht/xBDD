using System;
using System.Threading.Tasks;
using xBDD.Model;

namespace xBDD.Core
{
    internal class StepExecutor
    {
        StepExceptionHandler stepExceptionHandler;
        Scenario scenario;
        StatsCascader statsCascader;
        internal StepExecutor(Scenario scenario, CoreFactory factory)
        {
            stepExceptionHandler = factory.CreateStepExceptionHandler(scenario);
            statsCascader = factory.UtilityFactory.CreateStatsCascader();
            this.scenario = scenario;
        }
        internal async Task ExecuteStepAsync(Step step)
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

        private void PreExecution(Step step)
        {
            step.StartTime = DateTime.Now;
        }

        private void PostExecution(Step step)
        {
            step.EndTime = DateTime.Now;
            step.Outcome = Outcome.Passed;
			step.Reason = "Passed";
            statsCascader.CascadeStepStats(step, false);
        }
    }
}
