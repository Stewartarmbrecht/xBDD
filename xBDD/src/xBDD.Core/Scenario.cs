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

        public Scenario Given(Step step)
        {
            return builder.Given(step);
        }
        public Scenario When(Step step)
        {
            return builder.When(step);
        }
        public Scenario Then(Step step)
        {
            return builder.Then(step);
        }

        public Scenario And(Step step)
        {
            return builder.And(step);
        }

        public Scenario SetOutputWriter(IOutputWriter outputWriter)
        {
            runner.SetOutputWriter(outputWriter);
            return this;
        }
    }
}