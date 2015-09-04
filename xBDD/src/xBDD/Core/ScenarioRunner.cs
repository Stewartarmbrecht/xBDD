﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using xBDD.Utility;

namespace xBDD.Core
{
    internal class ScenarioRunner : IScenarioRunner
    {
        IScenarioInternal scenario;
        IFactory factory;
        IOutcomeAggregator outcomeAggregator;
        internal ScenarioRunner(IScenarioInternal scenario, IFactory factory)
        {
            this.scenario = scenario;
            this.factory = factory;
            outcomeAggregator = factory.CreateOutcomeAggregator();
        }

        public void Run()
        {
            foreach (var step in scenario.Steps)
            {
                step.StartTime = DateTime.Now;
                if (step == scenario.Steps[0])
                    scenario.StartTime = step.StartTime;
                try
                {
                    step.Action(step);
                    PostExecution(step);
                }
                catch (SkipStepException ssex)
                {
                    ProcessSkipException(step, ssex);
                }
                catch (NotImplementedException niex)
                {
                    ProcessNotImplementedException(step, niex);
                }
                catch (Exception ex)
                {
                    ProcessException(step, ex);
                }
            }
            if (scenario.FirstStepException != null)
                throw scenario.FirstStepException;
        }
        public async Task RunAsync()
        {
            foreach (var step in scenario.Steps)
            {
                step.StartTime = DateTime.Now;
                try
                {
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
                catch (SkipStepException ssex)
                {
                    ProcessSkipException(step, ssex);
                }
                catch (NotImplementedException niex)
                {
                    ProcessNotImplementedException(step, niex);
                }
                catch (Exception ex)
                {
                    ProcessException(step, ex);
                }
            }
            if (scenario.FirstStepException != null)
                throw scenario.FirstStepException;
        }

        void PostExecution(IStep step)
        {
            SetEndTimes(step);
            step.Outcome = Outcome.Passed;
            scenario.Outcome = outcomeAggregator.GetNewParentOutcome(scenario.Outcome, step.Outcome);
        }
        void ProcessSkipException(IStep step, SkipStepException ex)
        {
            if (scenario.FirstStepException == null)
            {
                scenario.FirstStepException = new StepException(ex, step.Name);
            }
            SetEndTimes(step);
            step.Outcome = Outcome.Skipped;
            step.Reason = ex.Message;
            step.Exception = ex;
            scenario.Outcome = outcomeAggregator.GetNewParentOutcome(scenario.Outcome, step.Outcome);
        }
        void ProcessNotImplementedException(IStep step, NotImplementedException ex)
        {
            if (scenario.FirstStepException == null)
            {
                scenario.FirstStepException = new StepException(ex, step.Name);
            }
            SetEndTimes(step);
            step.Outcome = Outcome.Skipped;
            step.Reason = "Not Implemented";
            step.Exception = ex;
            scenario.Outcome = outcomeAggregator.GetNewParentOutcome(scenario.Outcome, step.Outcome);
        }
        void ProcessException(IStep step, Exception ex)
        {
            if (scenario.FirstStepException == null)
            {
                scenario.FirstStepException = new StepException(ex, step.Name);
            }
            SetEndTimes(step);
            step.Outcome = Outcome.Failed;
            step.Reason = ex.Message;
            step.Exception = ex;
            scenario.Outcome = outcomeAggregator.GetNewParentOutcome(scenario.Outcome, step.Outcome);
        }
        void SetEndTimes(IStep step)
        {
            step.EndTime = DateTime.Now;
            scenario.Time = scenario.Time.Add(step.EndTime.Subtract(step.StartTime));
            if (step == scenario.Steps[scenario.Steps.Count - 1])
                scenario.EndTime = step.EndTime;
        }

    }
}
