using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Threading.Tasks;
using xBDD.Core;
using xBDD.Utility;

namespace xBDD
{
    public class Scenario
    {
        CoreFactory factory;
        OutcomeAggregator outcomeAggregator;
        ScenarioRunner runner;
        ScenarioBuilder builder;
        internal Scenario(CoreFactory factory, TestRun testRun)
        {
            this.factory = factory;
            TestRun = testRun;
            outcomeAggregator = factory.UtilityFactory.CreateOutcomeAggregator();
            runner = factory.CreateScenarioRunner(this);
            builder = factory.CreateScenarioBuilder(this);
            State = new ExpandoObject();
            Steps = new List<Step>();
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
        public TestRun TestRun { get; set; }

        public List<Step> Steps { get; private set; }

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
        public Scenario GivenAsync(string stepName, Func<Step, Task> stepAction)
        {
            return builder.GivenAsync(stepName, stepAction);
        }
        public Scenario GivenAsync(Func<Step, Task> stepAction)
        {
            return builder.GivenAsync(stepAction);
        }
        public Scenario Given(Action<Step> stepAction)
        {
            return builder.Given(stepAction);
        }
        public Scenario Given(string name, Action<Step> stepAction)
        {
            return builder.Given(name, stepAction);
        }
        #endregion Given
        #region When
        public Scenario WhenAsync(string name, Func<Step, Task> stepAction)
        {
            return builder.WhenAsync(name, stepAction);
        }
        public Scenario WhenAsync(Func<Step, Task> stepAction)
        {
            return builder.WhenAsync(stepAction);
        }
        public Scenario When(Action<Step> stepAction)
        {
            return builder.When(stepAction);
        }
        public Scenario When(string name, Action<Step> stepAction)
        {
            return builder.When(name, stepAction);
        }
        #endregion When
        #region Then
        public Scenario ThenAsync(string name, Func<Step, Task> stepAction)
        {
            return builder.ThenAsync(name, stepAction);
        }
        public Scenario ThenAsync(Func<Step, Task> stepAction)
        {
            return builder.ThenAsync(stepAction);
        }
        public Scenario Then(Action<Step> stepAction)
        {
            return builder.Then(stepAction);
        }
        public Scenario Then(string name, Action<Step> stepAction)
        {
            return builder.Then(name, stepAction);
        }
        #endregion Then
        #region And
        public Scenario AndAsync(string name, Func<Step, Task> stepAction)
        {
            return builder.AndAsync(name, stepAction);
        }
        public Scenario AndAsync(Func<Step, Task> stepAction)
        {
            return builder.AndAsync(stepAction);
        }
        public Scenario And(Action<Step> stepAction)
        {
            return builder.And(stepAction);
        }
        public Scenario And(string name, Action<Step> stepAction)
        {
            return builder.And(name, stepAction);
        }
        #endregion And

        public Scenario SetOutputWriter(IOutputWriter outputWriter)
        {
            runner.SetOutputWriter(outputWriter);
            return this;
        }
    }
}