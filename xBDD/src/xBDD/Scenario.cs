using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace xBDD
{
    public class Scenario : IScenario
    {
        IFactory factory;

        private List<IStep> steps;

        public string Name { get; set; }

        public List<IStep> Steps { get { return steps; } }

        public string FeatureName { get; set; }
        public string AreaPath { get; set; }

        public Scenario(IFactory factory)
        {
            this.factory = factory;
            steps = new List<IStep>();
        }


        public IScenario Given(string name, Action<IStep> stepAction)
        {
            return Action(name, stepAction, ActionType.Given);
        }
        public IScenario Given(Action<IStep> stepAction)
        {
            return Action(stepAction, ActionType.Given);
        }
        public IScenario When(string name, Action<IStep> stepAction)
        {
            return Action(name, stepAction, ActionType.When);
        }
        public IScenario When(Action<IStep> stepAction)
        {
            return Action(stepAction, ActionType.When);
        }
        public IScenario Then(string name, Action<IStep> stepAction)
        {
            return Action(name, stepAction, ActionType.Then);
        }
        public IScenario Then(Action<IStep> stepAction)
        {
            return Action(stepAction, ActionType.Then);
        }
        public IScenario And(string name, Action<IStep> stepAction)
        {
            return Action(name, stepAction, ActionType.And);
        }
        public IScenario And(Action<IStep> stepAction)
        {
            return Action(stepAction, ActionType.And);
        }
        IScenario Action(Action<IStep> stepAction, ActionType type)
        {
            return Action(null, stepAction, type);
        }
        IScenario Action(string name, Action<IStep> stepAction, ActionType type)
        {
            var step = factory.CreateStep();
            var method = factory.GetMethodRetriever().GetStepMethod(stepAction);
            step.Name = factory.GetStepNameReader().ReadStepName(name, method);
            step.ActionType = type;
            step.Action = stepAction;
            this.steps.Add(step);
            return this;
        }

        public void Run()
        {
            foreach(var step in Steps)
            {
                step.Action(step);
            }
        }
    }
}