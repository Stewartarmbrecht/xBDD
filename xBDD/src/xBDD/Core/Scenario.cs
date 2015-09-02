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
                    step.EndTime = DateTime.Now;
                    step.Outcome = Outcome.Passed;
                }
                catch
                {
                    step.EndTime = DateTime.Now;
                    step.Outcome = Outcome.Failed;
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
                    step.EndTime = DateTime.Now;
                    step.Outcome = Outcome.Passed;
                }
                catch
                {
                    step.EndTime = DateTime.Now;
                    step.Outcome = Outcome.Failed;
                    throw;
                }
            }
        }
    }
}