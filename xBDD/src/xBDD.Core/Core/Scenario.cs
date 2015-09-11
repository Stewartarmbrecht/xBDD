using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Threading.Tasks;
using xBDD.Utility;

namespace xBDD.Core
{
    public class Scenario : IScenarioInternal
    {
        ICoreFactory factory;
        IOutcomeAggregator outcomeAggregator;
        IScenarioRunner runner;
        IScenarioBuilder builder;
        public Scenario(ICoreFactory factory, ITestRun testRun)
        {
            this.factory = factory;
            TestRun = testRun;
            outcomeAggregator = factory.UtilityFactory.CreateOutcomeAggregator();
            runner = factory.CreateScenarioRunner(this);
            builder = factory.CreateScenarioBuilder(this);
            State = new ExpandoObject();
            Steps = new List<IStep>();
        }

        public string AreaPath { get; set; }
        public string FeatureName { get; set; }
        public string Name { get; set; }
        public Outcome Outcome { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public TimeSpan Time { get; set; }
        public Exception FirstStepException { get; set; }

        public dynamic State { get; private set; }
        public ITestRun TestRun { get; set; }

        public List<IStep> Steps { get; private set; }

        public string Reason { get; set; }

        public void Run()
        {
            runner.Run();
        }
        public async Task RunAsync()
        {
            await runner.RunAsync();
        }
        public void Skip(string reason)
        {
            runner.Skip(reason);
        }
        public async Task SkipAsync(string reason)
        {
            await runner.SkipAsync(reason);
        }

        #region Given
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
            return builder.Given(name, stepAction);
        }
        #endregion Given
        #region When
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
        #endregion When
        #region Then
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
        #endregion Then
        #region And
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
        #endregion And

        public IScenario SetOutputWriter(IOutputWriter outputWriter)
        {
            runner.SetOutputWriter(outputWriter);
            return this;
        }
    }
}