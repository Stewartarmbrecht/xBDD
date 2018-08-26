using System;
using xBDD.Model;

namespace xBDD.Core
{
    internal class StepExceptionHandler
    {
        Scenario scenario;
        StatsCascader statsCascader;

        public StepExceptionHandler(Scenario scenario, CoreFactory factory)
        {
            this.scenario = scenario;
            statsCascader = factory.UtilityFactory.CreateStatsCascader();
        }

        public void HandleException(StepExecutor stepExecutor, Step step, Exception ex)
        {
            if (ex is NotImplementedException)
            {
                ProcessNotImplementedException(stepExecutor, step, ex as NotImplementedException);
            }
            else
            {
                ProcessException(stepExecutor, step, ex);
            }
        }
        void ProcessNotImplementedException(StepExecutor stepExecutor, Step step, NotImplementedException ex)
        {
            step.EndTime = DateTime.Now;
            step.Outcome = Outcome.Failed;
            step.Reason = "Failed - Not Implemented";
            step.Exception = ex;
            if (scenario.Reason == null)
                scenario.Reason = "Failed";
            statsCascader.CascadeStepStats(step, false);
            throw new StepNotImplementedException(step.Name, ex);
        }
        void ProcessException(StepExecutor stepExecutor, Step step, Exception ex)
        {
            step.EndTime = DateTime.Now;
            step.Outcome = Outcome.Failed;
            step.Reason = "Failed";
            step.Exception = ex;
            if (scenario.Reason == null)
                scenario.Reason = "Failed";
            statsCascader.CascadeStepStats(step, false);
            throw new StepException(step.Name, ex);
        }
    }
}