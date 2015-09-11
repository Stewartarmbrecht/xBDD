using System;
using xBDD.Utility;

namespace xBDD.Core
{
    internal class StepExceptionHandler : IStepExceptionHandler
    {
        IScenarioInternal scenario;
        IOutcomeAggregator outcomeAggregator;

        public StepExceptionHandler(IScenarioInternal scenario, ICoreFactory factory)
        {
            this.scenario = scenario;
            outcomeAggregator = factory.UtilityFactory.CreateOutcomeAggregator();
        }

        public void HandleException(IStepExecutor stepExecutor, IStep step, Exception ex)
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
        void ProcessSkipException(IStepExecutor stepExecutor, IStep step, SkipStepException ex)
        {
            stepExecutor.SetEndTimes(step);
            step.Outcome = Outcome.Skipped;
            step.Reason = ex.Message;
            scenario.Outcome = outcomeAggregator.GetNewParentOutcome(scenario.Outcome, step.Outcome);
            if(scenario.Reason == null)
                scenario.Reason = "Step Skipped";
            if (scenario.FirstStepException == null)
                scenario.FirstStepException = new StepException(step.Name, ex);
            step.Exception = ex;
        }
        void ProcessNotImplementedException(IStepExecutor stepExecutor, IStep step, NotImplementedException ex)
        {
            if (scenario.FirstStepException == null)
            {
                scenario.FirstStepException = new StepNotImplementedException(step.Name, ex);
            }
            stepExecutor.SetEndTimes(step);
            step.Outcome = Outcome.Skipped;
            step.Reason = "Not Implemented";
            step.Exception = ex;
            scenario.Outcome = outcomeAggregator.GetNewParentOutcome(scenario.Outcome, step.Outcome);
            if (scenario.Reason == null)
                scenario.Reason = "Step Not Implemented";
        }
        void ProcessException(IStepExecutor stepExecutor, IStep step, Exception ex)
        {
            if (scenario.FirstStepException == null)
            {
                scenario.FirstStepException = new StepException(step.Name, ex);
            }
            stepExecutor.SetEndTimes(step);
            step.Outcome = Outcome.Failed;
            step.Reason = ex.Message;
            step.Exception = ex;
            scenario.Outcome = outcomeAggregator.GetNewParentOutcome(scenario.Outcome, step.Outcome);
            if (scenario.Reason == null)
                scenario.Reason = "Failed Step";
        }
    }
}