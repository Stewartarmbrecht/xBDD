using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace xBDD
{
    public class TestCase : ITestCase
    {
        IFactory factory;

        private List<ITestStep> steps;

        public string Name { get; set; }

        public List<ITestStep> Steps { get { return steps; } }

        public string ClassName { get; set; }
        public string Namespace { get; set; }

        public TestCase(IFactory factory)
        {
            this.factory = factory;
            steps = new List<ITestStep>();
        }


        public ITestCase Given(string name, Action<ITestStep> stepAction)
        {
            return Action(name, stepAction, ActionType.Given);
        }
        public ITestCase Given(Action<ITestStep> stepAction)
        {
            return Action(stepAction, ActionType.Given);
        }
        public ITestCase When(string name, Action<ITestStep> stepAction)
        {
            return Action(name, stepAction, ActionType.When);
        }
        public ITestCase When(Action<ITestStep> stepAction)
        {
            return Action(stepAction, ActionType.When);
        }
        public ITestCase Then(string name, Action<ITestStep> stepAction)
        {
            return Action(name, stepAction, ActionType.Then);
        }
        public ITestCase Then(Action<ITestStep> stepAction)
        {
            return Action(stepAction, ActionType.Then);
        }
        public ITestCase And(string name, Action<ITestStep> stepAction)
        {
            return Action(name, stepAction, ActionType.And);
        }
        public ITestCase And(Action<ITestStep> stepAction)
        {
            return Action(stepAction, ActionType.And);
        }
        ITestCase Action(Action<ITestStep> stepAction, ActionType type)
        {
            return Action(null, stepAction, type);
        }
        ITestCase Action(string name, Action<ITestStep> stepAction, ActionType type)
        {
            var step = factory.CreateTestStep();
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