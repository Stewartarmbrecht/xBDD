using System;
using xBDD.Utility;

namespace xBDD.Core
{
    internal class StepExceptionHandler : IStepExceptionHandler
    {
        IScenarioInternal scenario;
        IOutcomeAggregator outcomeAggregator;
        public StepExceptionHandler(IScenarioInternal scenario, IFactory factory)
        {
            this.scenario = scenario;
            outcomeAggregator = factory.CreateOutcomeAggregator();
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
            if (scenario.FirstStepException == null)
            {
                scenario.FirstStepException = new SkipScenarioException(step.Name, ex);
            }
            stepExecutor.SetEndTimes(step);
            step.Outcome = Outcome.Skipped;
            step.Reason = ex.Message;
            step.Exception = ex;
            scenario.Outcome = outcomeAggregator.GetNewParentOutcome(scenario.Outcome, step.Outcome);
        }
        void ProcessNotImplementedException(IStepExecutor stepExecutor, IStep step, NotImplementedException ex)
        {
            if (scenario.FirstStepException == null)
            {
                scenario.FirstStepException = new SkipScenarioException(step.Name, ex);
            }
            stepExecutor.SetEndTimes(step);
            step.Outcome = Outcome.Skipped;
            step.Reason = "Not Implemented";
            step.Exception = ex;
            scenario.Outcome = outcomeAggregator.GetNewParentOutcome(scenario.Outcome, step.Outcome);
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
        }
    }
}