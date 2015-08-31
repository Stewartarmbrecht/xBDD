using System;
using System.Collections.Generic;

namespace xBDD
{
    public class TestCase
    {
        private List<TestStep> steps;

        public string Name { get; internal set; }
        public List<TestStep> Steps { get { return steps; } }

        public TestCase()
        {
            steps = new List<TestStep>();
        }

        public TestCase Given(string name, Action<TestStep> stepAction)
        {
            return Action(name, stepAction, ActionType.Given);
        }
        public TestCase Given(Action<TestStep> stepAction)
        {
            return Action(stepAction, ActionType.Given);
        }
        public TestCase When(string name, Action<TestStep> stepAction)
        {
            return Action(name, stepAction, ActionType.When);
        }
        public TestCase When(Action<TestStep> stepAction)
        {
            return Action(stepAction, ActionType.When);
        }
        public TestCase Then(string name, Action<TestStep> stepAction)
        {
            return Action(name, stepAction, ActionType.Then);
        }
        public TestCase Then(Action<TestStep> stepAction)
        {
            return Action(stepAction, ActionType.Then);
        }
        public TestCase And(string name, Action<TestStep> stepAction)
        {
            return Action(name, stepAction, ActionType.And);
        }
        public TestCase And(Action<TestStep> stepAction)
        {
            return Action(stepAction, ActionType.And);
        }
        public TestCase Action(Action<TestStep> stepAction, ActionType type)
        {
            return Action(null, stepAction, type);
        }
        public TestCase Action(string name, Action<TestStep> stepAction, ActionType type)
        {
            TestStep step = new TestStep();
            step.Name = name;
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