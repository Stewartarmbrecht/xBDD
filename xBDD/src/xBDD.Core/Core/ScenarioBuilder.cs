using System;
using System.Threading.Tasks;
using xBDD.Model;

namespace xBDD.Core
{
    public class ScenarioBuilder
    {
        CoreFactory factory;
        Utility.OutcomeAggregator outcomeAggregator;
        ScenarioRunner runner;
        Scenario scenario;

        public Scenario Scenario { get { return scenario; } }

        internal ScenarioBuilder(string scenarioName, Feature feature, CoreFactory factory)
        {
            this.factory = factory;
            outcomeAggregator = factory.UtilityFactory.CreateOutcomeAggregator();
            scenario = factory.CreateScenario(scenarioName, feature);
            runner = factory.CreateScenarioRunner(scenario);
        }

        public ScenarioBuilder Given(Step step)
        {
            step.ActionType = ActionType.Given;
            step.Scenario = scenario;
            scenario.Steps.Add(step);
            return this;
        }
        public ScenarioBuilder When(Step step)
        {
            step.ActionType = ActionType.When;
            step.Scenario = scenario;
            scenario.Steps.Add(step);
            return this;
        }
        public ScenarioBuilder Then(Step step)
        {
            step.ActionType = ActionType.Then;
            step.Scenario = scenario;
            scenario.Steps.Add(step);
            return this;
        }

        public ScenarioBuilder And(Step step)
        {
            step.ActionType = ActionType.And;
            step.Scenario = scenario;
            scenario.Steps.Add(step);
            return this;
        }

        public ScenarioBuilder Given(
            string stepName, 
            Action action = null, 
            string multilineParameter = "",
            MultilineParameterFormat multilineParameterFormat = MultilineParameterFormat.literal)
        {
            var step = factory.CreateStep(stepName, action, multilineParameter, multilineParameterFormat);
            return Given(step);
        }

        public ScenarioBuilder GivenAsync(
            string stepName, 
            Func<Task> action = null, 
            string multilineParameter = "",
            MultilineParameterFormat multilineParameterFormat = MultilineParameterFormat.literal)
        {
            var step = factory.CreateStep(stepName, action, multilineParameter, multilineParameterFormat);
            return Given(step);
        }

        public ScenarioBuilder When(
            string stepName, 
            Action action = null, 
            string multilineParameter = "",
            MultilineParameterFormat multilineParameterFormat = MultilineParameterFormat.literal)
        {
            var step = factory.CreateStep(stepName, action, multilineParameter, multilineParameterFormat);
            return When(step);
        }

        public ScenarioBuilder WhenAsync(
            string stepName, 
            Func<Task> action = null, 
            string multilineParameter = "",
            MultilineParameterFormat multilineParameterFormat = MultilineParameterFormat.literal)
        {
            var step = factory.CreateStep(stepName, action, multilineParameter, multilineParameterFormat);
            return When(step);
        }

        public ScenarioBuilder Then(
            string stepName, 
            Action action = null, 
            string multilineParameter = "",
            MultilineParameterFormat multilineParameterFormat = MultilineParameterFormat.literal)
        {
            var step = factory.CreateStep(stepName, action, multilineParameter, multilineParameterFormat);
            return Then(step);
        }

        public ScenarioBuilder ThenAsync(
            string stepName, 
            Func<Task> action = null, 
            string multilineParameter = "",
            MultilineParameterFormat multilineParameterFormat = MultilineParameterFormat.literal)
        {
            var step = factory.CreateStep(stepName, action, multilineParameter, multilineParameterFormat);
            return Then(step);
        }

        public ScenarioBuilder And(
            string stepName, 
            Action action = null, 
            string multilineParameter = "",
            MultilineParameterFormat multilineParameterFormat = MultilineParameterFormat.literal)
        {
            var step = factory.CreateStep(stepName, action, multilineParameter, multilineParameterFormat);
            return And(step);
        }

        public ScenarioBuilder AndAsync(
            string stepName, 
            Func<Task> action = null, 
            string multilineParameter = "",
            MultilineParameterFormat multilineParameterFormat = MultilineParameterFormat.literal)
        {
            var step = factory.CreateStep(stepName, action, multilineParameter, multilineParameterFormat);
            return And(step);
        }

        public ScenarioBuilder SetOutputWriter(IOutputWriter outputWriter)
        {
            runner.SetOutputWriter(outputWriter);
            return this;
        }
        public void Run()
        {
            runner.Run(false);
        }
        public void Document()
        {
            runner.Run(true);
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

    }
}