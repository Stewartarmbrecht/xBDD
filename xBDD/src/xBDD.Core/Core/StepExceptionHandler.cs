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
            if (ex is SkipStepException)
            {
                ProcessSkipException(stepExecutor, step, ex as SkipStepException);
            }
            else if (ex is NotImplementedException)
            {
                ProcessNotImplementedException(stepExecutor, step, ex as NotImplementedException);
            }
            else
            {
                ProcessException(stepExecutor, step, ex);
            }
        }
        void ProcessSkipException(StepExecutor stepExecutor, Step step, SkipStepException ex)
        {
            step.EndTime = DateTime.Now;
            step.Outcome = Outcome.Skipped;
            step.Reason = ex.Message;
            if(scenario.Reason == null)
                scenario.Reason = "Step Skipped";
            step.Exception = ex;
            statsCascader.CascadeStats(step);
            throw new StepException(step.Name, ex);
        }
        void ProcessNotImplementedException(StepExecutor stepExecutor, Step step, NotImplementedException ex)
        {
            step.EndTime = DateTime.Now;
            step.Outcome = Outcome.Failed;
            step.Reason = "Not Implemented";
            step.Exception = ex;
            if (scenario.Reason == null)
                scenario.Reason = "Step Not Implemented";
            statsCascader.CascadeStats(step);
            throw new StepNotImplementedException(step.Name, ex);
        }
        void ProcessException(StepExecutor stepExecutor, Step step, Exception ex)
        {
            step.EndTime = DateTime.Now;
            step.Outcome = Outcome.Failed;
            step.Reason = ex.Message;
            step.Exception = ex;
            if (scenario.Reason == null)
                scenario.Reason = "Failed Step";
            statsCascader.CascadeStats(step);
            throw new StepException(step.Name, ex);
        }
    }
}