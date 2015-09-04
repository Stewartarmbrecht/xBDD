using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace xBDD.Core
{
    public class ScenarioBuilder : IScenarioBuilder
    {
        IFactory factory;
        IScenarioInternal scenario;
        public ScenarioBuilder(IScenarioInternal scenario, IFactory factory)
        {
            this.factory = factory;
            this.scenario = scenario;
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
            var step = factory.CreateStep(scenario);
            var method = factory.GetMethodRetriever().GetStepMethod(stepAction);
            step.ActionType = type;
            step.Action = stepAction;
            step.SetName(factory.GetStepNameReader().ReadStepName(step, name, method));
            scenario.Steps.Add(step);
            return scenario;
        }

        IScenario Action(string name, Func<IStep, Task> stepAction, ActionType type)
        {
            var step = factory.CreateStep(scenario);
            var method = factory.GetMethodRetriever().GetStepMethod(stepAction);
            step.ActionType = type;
            step.ActionAsync = stepAction;
            step.SetName(factory.GetStepNameReader().ReadStepName(step, name, method));
            scenario.Steps.Add(step);
            return scenario;
        }

    }
}
