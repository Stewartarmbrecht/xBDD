using System;
using System.Threading.Tasks;

namespace xBDD.Core
{
    public class ScenarioBuilder
    {
        CoreFactory factory;
        Scenario scenario;

        public ScenarioBuilder(Scenario scenario, CoreFactory factory)
        {
            this.factory = factory;
            this.scenario = scenario;
        }

        #region Given
        public Scenario Given(string name, Action<Step> stepAction)
        {
            return Action(name, stepAction, ActionType.Given);
        }
        public Scenario Given(Action<Step> stepAction)
        {
            return Action(stepAction, ActionType.Given);
        }
        public Scenario GivenAsync(Func<Step, Task> stepAction)
        {
            return Action(stepAction, ActionType.Given);
        }
        public Scenario GivenAsync(string name, Func<Step, Task> stepAction)
        {
            return Action(name, stepAction, ActionType.Given);
        }
        #endregion Given
        #region When
        public Scenario When(string name, Action<Step> stepAction)
        {
            return Action(name, stepAction, ActionType.When);
        }
        public Scenario When(Action<Step> stepAction)
        {
            return Action(stepAction, ActionType.When);
        }
        public Scenario WhenAsync(Func<Step, Task> stepAction)
        {
            return Action(stepAction, ActionType.When);
        }
        public Scenario WhenAsync(string name, Func<Step, Task> stepAction)
        {
            return Action(name, stepAction, ActionType.When);
        }
        #endregion When
        #region Then
        public Scenario Then(string name, Action<Step> stepAction)
        {
            return Action(name, stepAction, ActionType.Then);
        }
        public Scenario Then(Action<Step> stepAction)
        {
            return Action(stepAction, ActionType.Then);
        }
        public Scenario ThenAsync(Func<Step, Task> stepAction)
        {
            return Action(stepAction, ActionType.Then);
        }
        public Scenario ThenAsync(string name, Func<Step, Task> stepAction)
        {
            return Action(name, stepAction, ActionType.Then);
        }
        #endregion Then
        #region And
        public Scenario And(string name, Action<Step> stepAction)
        {
            return Action(name, stepAction, ActionType.And);
        }
        public Scenario And(Action<Step> stepAction)
        {
            return Action(stepAction, ActionType.And);
        }
        public Scenario AndAsync(Func<Step, Task> stepAction)
        {
            return Action(stepAction, ActionType.And);
        }
        public Scenario AndAsync(string name, Func<Step, Task> stepAction)
        {
            return Action(name, stepAction, ActionType.And);
        }
        #endregion And
        #region Action
        Scenario Action(Action<Step> stepAction, ActionType type)
        {
            return Action(null, stepAction, type);
        }
        Scenario Action(Func<Step, Task> stepAction, ActionType type)
        {
            return Action(null, stepAction, type);
        }
        Scenario Action(string name, Action<Step> stepAction, ActionType type)
        {
            var step = factory.CreateStep(scenario);
            var method = factory.UtilityFactory.GetMethodRetriever().GetStepMethod(stepAction);
            step.ActionType = type;
            step.Action = stepAction;
            if (name != null)
                step.SetName(name);
            else
                step.SetName(factory.UtilityFactory.GetStepNameReader().ReadStepName(method));
            scenario.Steps.Add(step);
            return scenario;
        }
        Scenario Action(string name, Func<Step, Task> stepAction, ActionType type)
        {
            var step = factory.CreateStep(scenario);
            var method = factory.UtilityFactory.GetMethodRetriever().GetStepMethod(stepAction);
            step.ActionType = type;
            step.ActionAsync = stepAction;
            if (name != null)
                step.SetName(name);
            else
                step.SetName(factory.UtilityFactory.GetStepNameReader().ReadStepName(method));
            scenario.Steps.Add(step);
            return scenario;
        }
        #endregion Action

    }
}
