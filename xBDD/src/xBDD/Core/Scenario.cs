using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Threading.Tasks;

namespace xBDD.Core
{
    public class Scenario : IScenario
    {
        IFactory factory;
        ITestRun testRun;

        private List<IStep> steps;

        public string Name { get; set; }

        public List<IStep> Steps { get { return steps; } }

        public string FeatureName { get; set; }
        public string AreaPath { get; set; }

        public dynamic State { get; private set; }

        public Outcome Outcome { get; private set; }
        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }
        public TimeSpan Time { get; private set; }

        public Scenario(IFactory factory, ITestRun testRun)
        {
            this.factory = factory;
            this.testRun = testRun;
            State = new ExpandoObject();
            steps = new List<IStep>();
        }


        #region Given
        public IScenario Given(string name, Action<IStep> stepAction)
        {
            return Action(name, stepAction, ActionType.Given);
        }
        public IScenario Given(Action<IStep> stepAction)
        {
            return Action(stepAction, ActionType.Given);
        }
        public IScenario GivenAsync(Func<IStep, Task> stepAction)
        {
            return Action(stepAction, ActionType.Given);
        }
        public IScenario GivenAsync(string name, Func<IStep, Task> stepAction)
        {
            return Action(name, stepAction, ActionType.Given);
        }
        #endregion Given
        #region When
        public IScenario When(string name, Action<IStep> stepAction)
        {
            return Action(name, stepAction, ActionType.When);
        }
        public IScenario When(Action<IStep> stepAction)
        {
            return Action(stepAction, ActionType.When);
        }
        public IScenario WhenAsync(Func<IStep, Task> stepAction)
        {
            return Action(stepAction, ActionType.When);
        }
        public IScenario WhenAsync(string name, Func<IStep, Task> stepAction)
        {
            return Action(name, stepAction, ActionType.When);
        }
        #endregion When
        #region Then
        public IScenario Then(string name, Action<IStep> stepAction)
        {
            return Action(name, stepAction, ActionType.Then);
        }
        public IScenario Then(Action<IStep> stepAction)
        {
            return Action(stepAction, ActionType.Then);
        }
        public IScenario ThenAsync(Func<IStep, Task> stepAction)
        {
            return Action(stepAction, ActionType.Then);
        }
        public IScenario ThenAsync(string name, Func<IStep, Task> stepAction)
        {
            return Action(name, stepAction, ActionType.Then);
        }
        #endregion Then
        #region And
        public IScenario And(string name, Action<IStep> stepAction)
        {
            return Action(name, stepAction, ActionType.And);
        }
        public IScenario And(Action<IStep> stepAction)
        {
            return Action(stepAction, ActionType.And);
        }
        public IScenario AndAsync(Func<IStep, Task> stepAction)
        {
            return Action(stepAction, ActionType.And);
        }
        public IScenario AndAsync(string name, Func<IStep, Task> stepAction)
        {
            return Action(name, stepAction, ActionType.And);
        }
        #endregion And
        IScenario Action(Action<IStep> stepAction, ActionType type)
        {
            return Action(null, stepAction, type);
        }
        IScenario Action(Func<IStep, Task> stepAction, ActionType type)
        {
            return Action(null, stepAction, type);
        }
        IScenario Action(string name, Action<IStep> stepAction, ActionType type)
        {
            var step = factory.CreateStep(testRun, this);
            var method = factory.GetMethodRetriever().GetStepMethod(stepAction);
            step.ActionType = type;
            step.Action = stepAction;
            step.SetName(factory.GetStepNameReader().ReadStepName(step, name, method));
            this.steps.Add(step);
            return this;
        }

        IScenario Action(string name, Func<IStep, Task> stepAction, ActionType type)
        {
            var step = factory.CreateStep(testRun, this);
            var method = factory.GetMethodRetriever().GetStepMethod(stepAction);
            step.ActionType = type;
            step.ActionAsync = stepAction;
            step.SetName(factory.GetStepNameReader().ReadStepName(step, name, method));
            this.steps.Add(step);
            return this;
        }

        public void Run()
        {
            foreach(var step in Steps)
            {
                step.StartTime = DateTime.Now;
                try
                {
                    step.Action(step);
                    PostExecution(step);
                }
                catch(SkipStepException ssex)
                {
                    ProcessSkipException(step, ssex);
                    throw;
                }
                catch (NotImplementedException niex)
                {
                    ProcessNotImplementedException(step, niex);
                    throw;
                }
                catch (Exception ex)
                {
                    ProcessException(step, ex);
                    throw;
                }
            }
        }

        public async Task RunAsync()
        {
            foreach (var step in Steps)
            {
                step.StartTime = DateTime.Now;
                try
                {
                    if(step.ActionAsync == null && step.Action != null)
                    {
                        await Task.Run(() => { step.Action(step); });
                    }
                    else
                    {
                        await step.ActionAsync(step);
                    }
                    PostExecution(step);
                }
                catch(SkipStepException ssex)
                {
                    ProcessSkipException(step, ssex);
                }
                catch (NotImplementedException niex)
                {
                    ProcessNotImplementedException(step, niex);
                    throw;
                }
                catch (Exception ex)
                {
                    ProcessException(step, ex);
                    throw;
                }
            }
        }

        private static void PostExecution(IStep step)
        {
            step.EndTime = DateTime.Now;
            step.Outcome = Outcome.Passed;
        }
        private static void ProcessSkipException(IStep step, SkipStepException ssex)
        {
            step.EndTime = DateTime.Now;
            step.Outcome = Outcome.Skipped;
            step.Reason = ssex.Message;
            step.Exception = ssex;
        }
        private static void ProcessNotImplementedException(IStep step, NotImplementedException niex)
        {
            step.EndTime = DateTime.Now;
            step.Outcome = Outcome.Skipped;
            step.Reason = "Not Implemented";
            step.Exception = niex;
        }
        private static void ProcessException(IStep step, Exception ex)
        {
            step.EndTime = DateTime.Now;
            step.Outcome = Outcome.Failed;
            step.Reason = ex.Message;
            step.Exception = ex;
        }

    }
}