using System;
using System.Threading.Tasks;
using xBDD.Model;

namespace xBDD.Core
{
    public class StepExecutor
    {
        StepExceptionHandler stepExceptionHandler;
        Scenario scenario;
        StatsCascader statsCascader;
        public StepExecutor(Scenario scenario, CoreFactory factory)
        {
            stepExceptionHandler = factory.CreateStepExceptionHandler(scenario);
            statsCascader = factory.UtilityFactory.CreateStatsCascader();
            this.scenario = scenario;
        }
        public async Task ExecuteStepAsync(Step step)
        {
            try
            {
                PreExecution(step);
                if (step.ActionAsync == null && step.Action != null)
                {
                    await Task.Run(() => { step.Action(); });
                }
                else
                {
                    await step.ActionAsync();
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
                step.Action();
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

        void PostExecution(Step step)
        {
            step.EndTime = DateTime.Now;
            step.Outcome = Outcome.Passed;
            statsCascader.CascadeStats(step);
        }
    }
}
