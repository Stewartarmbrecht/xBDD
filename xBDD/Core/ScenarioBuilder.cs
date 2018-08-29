using System;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using xBDD.Model;

namespace xBDD.Core
{
    /// <summary>
    /// Provides methods for building scenarios by adding 
    /// steps for specific types of actions/staements.
    /// </summary>
    public class ScenarioBuilder
    {
        CoreFactory factory;
        Utility.OutcomeAggregator outcomeAggregator;
        ScenarioRunner runner;
        Scenario scenario;

        /// <summary>
        /// Gets the Scenario that the builder
        /// is creating.
        /// </summary>
        /// <value>Returns the scenario. <see cref="Scenario"/></value>
        public Scenario Scenario { get { return scenario; } }

        internal ScenarioBuilder(string scenarioName, Feature feature, CoreFactory factory, string methodName, int sortOrder)
        {
            this.factory = factory;
            outcomeAggregator = factory.UtilityFactory.CreateOutcomeAggregator();
            scenario = factory.CreateScenario(scenarioName, feature, methodName, sortOrder);
            runner = factory.CreateScenarioRunner(scenario);
        }

        /// <summary>
        /// Given synchronous step.
        /// </summary>
        /// <param name="step">The step to execute.</param>
        /// <returns>The scenario builder.</returns>
        public ScenarioBuilder Given(Step step)
        {
            step.ActionType = ActionType.Given;
            step.Scenario = scenario;
            scenario.Steps.Add(step);
            return this;
        }

        /// <summary>
        /// When synchronous step.
        /// </summary>
        /// <param name="step">The step to execute.</param>
        /// <returns>The scenario builder.</returns>
        public ScenarioBuilder When(Step step)
        {
            step.ActionType = ActionType.When;
            step.Scenario = scenario;
            scenario.Steps.Add(step);
            return this;
        }

        /// <summary>
        /// Then synchronous step.
        /// </summary>
        /// <param name="step">The step to execute.</param>
        /// <returns>The scenario builder.</returns>
        public ScenarioBuilder Then(Step step)
        {
            step.ActionType = ActionType.Then;
            step.Scenario = scenario;
            scenario.Steps.Add(step);
            return this;
        }

        /// <summary>
        /// And synchronous step.
        /// </summary>
        /// <param name="step">The step to execute.</param>
        /// <returns>The scenario builder.</returns>
        public ScenarioBuilder And(Step step)
        {
            step.ActionType = ActionType.And;
            step.Scenario = scenario;
            scenario.Steps.Add(step);
            return this;
        }

        /// <summary>
        /// Only used when defining a step to generate code.
		/// Do not use in a test method to define a scenario.
        /// </summary>
        /// <param name="step">The step to generate code whose name represents code that 
		/// will be written to the feature file.</param>
        /// <returns>The scenario builder.</returns>
        internal ScenarioBuilder Code(Step step)
        {
            step.ActionType = ActionType.Code;
            step.Scenario = scenario;
            scenario.Steps.Add(step);
            return this;
        }

        /// <summary>
        /// Given synchronous step.
        /// Creates a step from the required parts.
        /// </summary>
        /// <param name="stepName">The displayed text for the step.</param>
        /// <param name="action">The synchronous action to excute for the step.</param>
        /// <param name="multilineParameter">Optional paramter to add multi-line text under the step name.</param>
        /// <param name="multilineParameterFormat">Format to use when displaying the multiline text.null <see cref="TextFormat"/></param>
        /// <returns>The scenario builder for a fluent form.</returns>
        public ScenarioBuilder Given(
            string stepName, 
            Action<Step> action = null, 
            string multilineParameter = "",
            TextFormat multilineParameterFormat = TextFormat.text)
        {
            var step = factory.CreateStep(stepName, action, multilineParameter, multilineParameterFormat);
            return Given(step);
        }

        /// <summary>
        /// Given asynchronous step.
        /// Creates a step from the required parts.
        /// </summary>
        /// <param name="stepName">The displayed text for the step.</param>
        /// <param name="action">The asynchronous action to excute for the step.</param>
        /// <param name="multilineParameter">Optional paramter to add multi-line text under the step name.</param>
        /// <param name="multilineParameterFormat">Format to use when displaying the multiline text.null <see cref="TextFormat"/></param>
        /// <returns>The scenario builder for a fluent form.</returns>
        public ScenarioBuilder GivenAsync(
            string stepName, 
            Func<Step, Task> action = null, 
            string multilineParameter = "",
            TextFormat multilineParameterFormat = TextFormat.text)
        {
            var step = factory.CreateStep(stepName, action, multilineParameter, multilineParameterFormat);
            return Given(step);
        }

        /// <summary>
        /// When synchronous step.
        /// Creates a step from the required parts.
        /// </summary>
        /// <param name="stepName">The displayed text for the step.</param>
        /// <param name="action">The synchronous action to excute for the step.</param>
        /// <param name="multilineParameter">Optional paramter to add multi-line text under the step name.</param>
        /// <param name="multilineParameterFormat">Format to use when displaying the multiline text.null <see cref="TextFormat"/></param>
        /// <returns>The scenario builder for a fluent form.</returns>
        public ScenarioBuilder When(
            string stepName, 
            Action<Step> action = null, 
            string multilineParameter = "",
            TextFormat multilineParameterFormat = TextFormat.text)
        {
            var step = factory.CreateStep(stepName, action, multilineParameter, multilineParameterFormat);
            return When(step);
        }

        /// <summary>
        /// When asynchronous step.
        /// Creates a step from the required parts.
        /// </summary>
        /// <param name="stepName">The displayed text for the step.</param>
        /// <param name="action">The asynchronous action to excute for the step.</param>
        /// <param name="multilineParameter">Optional paramter to add multi-line text under the step name.</param>
        /// <param name="multilineParameterFormat">Format to use when displaying the multiline text.null <see cref="TextFormat"/></param>
        /// <returns>The scenario builder for a fluent form.</returns>
        public ScenarioBuilder WhenAsync(
            string stepName, 
            Func<Step, Task> action = null, 
            string multilineParameter = "",
            TextFormat multilineParameterFormat = TextFormat.text)
        {
            var step = factory.CreateStep(stepName, action, multilineParameter, multilineParameterFormat);
            return When(step);
        }

        /// <summary>
        /// Then synchronous step.
        /// Creates a step from the required parts.
        /// </summary>
        /// <param name="stepName">The displayed text for the step.</param>
        /// <param name="action">The synchronous action to excute for the step.</param>
        /// <param name="multilineParameter">Optional paramter to add multi-line text under the step name.</param>
        /// <param name="multilineParameterFormat">Format to use when displaying the multiline text.null <see cref="TextFormat"/></param>
        /// <returns>The scenario builder for a fluent form.</returns>
        public ScenarioBuilder Then(
            string stepName, 
            Action<Step> action = null, 
            string multilineParameter = "",
            TextFormat multilineParameterFormat = TextFormat.text)
        {
            var step = factory.CreateStep(stepName, action, multilineParameter, multilineParameterFormat);
            return Then(step);
        }

        /// <summary>
        /// Then asynchronous step.
        /// Creates a step from the required parts.
        /// </summary>
        /// <param name="stepName">The displayed text for the step.</param>
        /// <param name="action">The asynchronous action to excute for the step.</param>
        /// <param name="multilineParameter">Optional paramter to add multi-line text under the step name.</param>
        /// <param name="multilineParameterFormat">Format to use when displaying the multiline text.null <see cref="TextFormat"/></param>
        /// <returns>The scenario builder for a fluent form.</returns>
        public ScenarioBuilder ThenAsync(
            string stepName, 
            Func<Step, Task> action = null, 
            string multilineParameter = "",
            TextFormat multilineParameterFormat = TextFormat.text)
        {
            var step = factory.CreateStep(stepName, action, multilineParameter, multilineParameterFormat);
            return Then(step);
        }

        /// <summary>
        /// And synchronous step.
        /// Creates a step from the required parts.
        /// </summary>
        /// <param name="stepName">The displayed text for the step.</param>
        /// <param name="action">The synchronous action to excute for the step.</param>
        /// <param name="multilineParameter">Optional paramter to add multi-line text under the step name.</param>
        /// <param name="multilineParameterFormat">Format to use when displaying the multiline text.null <see cref="TextFormat"/></param>
        /// <returns>The scenario builder for a fluent form.</returns>
        public ScenarioBuilder And(
            string stepName, 
            Action<Step> action = null, 
            string multilineParameter = "",
            TextFormat multilineParameterFormat = TextFormat.text)
        {
            if(action.Method.IsDefined(typeof(AsyncStateMachineAttribute),false))
            {
                throw new AsyncStepInSyncScenarioException(stepName);
            }
            var step = factory.CreateStep(stepName, action, multilineParameter, multilineParameterFormat);
            return And(step);
        }

        /// <summary>
        /// And asynchronous step.
        /// Creates a step from the required parts.
        /// </summary>
        /// <param name="stepName">The displayed text for the step.</param>
        /// <param name="action">The asynchronous action to excute for the step.</param>
        /// <param name="multilineParameter">Optional paramter to add multi-line text under the step name.</param>
        /// <param name="multilineParameterFormat">Format to use when displaying the multiline text.null <see cref="TextFormat"/></param>
        /// <returns>The scenario builder for a fluent form.</returns>
        public ScenarioBuilder AndAsync(
            string stepName, 
            Func<Step, Task> action = null, 
            string multilineParameter = "",
            TextFormat multilineParameterFormat = TextFormat.text)
        {
            var step = factory.CreateStep(stepName, action, multilineParameter, multilineParameterFormat);
            return And(step);
        }

        /// <summary>
        /// Sets the output writer for the scenario.
        /// This controls how the framework outputs the information
        /// about the executing scenario.
        /// </summary>
        /// <param name="outputWriter">The output writer to use when executing the scenario.</param>
        /// <returns>The scenario builder for a fluent form.</returns>
        public ScenarioBuilder SetOutputWriter(IOutputWriter outputWriter)
        {
            runner.SetOutputWriter(outputWriter);
            return this;
        }

        /// <summary>
        /// Passes the scenario without running any steps and 
        /// instead just documents the scenario.
        /// Use this for scenarios that are purely for documentation
        /// and do not exeucte any code.
        /// </summary>
        /// <returns>Task for running the scenario.</returns>
        public async Task Document()
        {
            await runner.RunAsync(true);
        }

        /// <summary>
        /// Executes the scenario.
        /// </summary>
        /// <returns>Returns a task.</returns>
        public async Task Run()
        {
            await runner.RunAsync(false);
        }

        /// <summary>
        /// Skips the scenario and does not execute it.
        /// Marks the scenario as skipped.
        /// </summary>
        /// <param name="reason">The reason the scenario is being skipped.</param>
        /// <param name="testFrameworkSkipAction">The final action to take after skipping the scenario.null
        /// This action will be called with the reason passed to it. 
        /// It is designed for passing in MSTest's Assert.Inconcolusive so that the 
        /// Test method will be marked as skipped.</param>
        /// <returns>A task for async execution.</returns>
        public async Task Skip(string reason, Action<string> testFrameworkSkipAction)
        {
            await runner.Skip(reason);
            testFrameworkSkipAction(reason);
        }

    }
}