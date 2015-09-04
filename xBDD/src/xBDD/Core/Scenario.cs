using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Threading.Tasks;
using xBDD.Utility;

namespace xBDD.Core
{
    public class Scenario : IScenarioInternal
    {
        IFactory factory;
        IOutcomeAggregator outcomeAggregator;
        IScenarioRunner runner;
        IScenarioBuilder builder;

        private List<IStep> steps;

        public string Name { get; set; }
        public ITestRun TestRun { get; set; }

        public List<IStep> Steps { get { return steps; } }

        public string FeatureName { get; set; }
        public string AreaPath { get; set; }

        public dynamic State { get; private set; }

        public Outcome Outcome { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public TimeSpan Time { get; set; }
        public StepException FirstStepException { get; set; }

        public Scenario(IFactory factory, ITestRun testRun)
        {
            this.factory = factory;
            TestRun = testRun;
            outcomeAggregator = factory.CreateOutcomeAggregator();
            runner = factory.CreateScenarioRunner(this);
            builder = factory.CreateScenarioBuilder(this);
            State = new ExpandoObject();
            steps = new List<IStep>();
        }

        public void Run()
        {
            runner.Run();
        }

        public async Task RunAsync()
        {
            await runner.RunAsync();
        }

        public IScenario GivenAsync(string stepName, Func<IStep, Task> stepAction)
        {
            return builder.GivenAsync(stepName, stepAction);
        }

        public IScenario GivenAsync(Func<IStep, Task> stepAction)
        {
            return builder.GivenAsync(stepAction);
        }

        public IScenario Given(Action<IStep> stepAction)
        {
            return builder.Given(stepAction);
        }

        public IScenario Given(string name, Action<IStep> stepAction)
        {
            return builder.Given(stepAction);
        }

        public IScenario WhenAsync(string name, Func<IStep, Task> stepAction)
        {
            return builder.WhenAsync(name, stepAction);
        }

        public IScenario WhenAsync(Func<IStep, Task> stepAction)
        {
            return builder.WhenAsync(stepAction);
        }

        public IScenario When(Action<IStep> stepAction)
        {
            return builder.When(stepAction);
        }

        public IScenario When(string name, Action<IStep> stepAction)
        {
            return builder.When(name, stepAction);
        }

        public IScenario ThenAsync(string name, Func<IStep, Task> stepAction)
        {
            return builder.ThenAsync(name, stepAction);
        }

        public IScenario ThenAsync(Func<IStep, Task> stepAction)
        {
            return builder.ThenAsync(stepAction);
        }

        public IScenario Then(Action<IStep> stepAction)
        {
            return builder.Then(stepAction);
        }

        public IScenario Then(string name, Action<IStep> stepAction)
        {
            return builder.Then(name, stepAction);
        }

        public IScenario AndAsync(string name, Func<IStep, Task> stepAction)
        {
            return builder.AndAsync(name, stepAction);
        }

        public IScenario AndAsync(Func<IStep, Task> stepAction)
        {
            return builder.AndAsync(stepAction);
        }

        public IScenario And(Action<IStep> stepAction)
        {
            return builder.And(stepAction);
        }

        public IScenario And(string name, Action<IStep> stepAction)
        {
            return builder.And(name, stepAction);
        }
    }
}