using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using xBDD.Test.Sample;
using Xunit;

namespace xBDD.Test.Features.RunningScenarios
{
    [StepLibrary]
    public class RunningScenariosSteps
    {
        public ISimpleTestRun SimpleTestRun { get; set; }
        public ISimpleTestRun SimpleTestRunWithTypedState { get; private set; }
        public string ExpectedScenarioName { get; set; }
        public string ExpectedFeatureName { get; set; }
        public string ExpectedAreaPath { get; set; }
        public string ExpectedStep1Name { get; set; }
        public string ExpectedStep2Name { get; set; }
        public string ExpectedStep3Name { get; set; }
        public Action ScenarioToRun { get; set; }
        public string ExpectedExceptionMessage { get; set; }

        public Func<Task> ScenarioToRunAsync { get; private set; }

        public void a_simple_passing_scenario(IStep step)
        {
            SimpleTestRun = new SimpleTestRunUsingDynamicState();
            ScenarioToRun = SimpleTestRun.PassingScenario;
        }

        internal void a_simple_passing_scenario_with_typed_state(IStep obj)
        {
            SimpleTestRunWithTypedState = new SimpleTestRunUsingTypedState();
            ScenarioToRun = SimpleTestRunWithTypedState.PassingScenario;
        }

        internal void a_simple_failing_scenario_with_a_failing_time_capturing_step(IStep obj)
        {
            SimpleTestRun = new SimpleTestRunUsingDynamicState();
            ScenarioToRun = SimpleTestRun.FailingScenarioWithFailingTimeCapturingStep;
        }

        internal void a_simple_passing_scenario_with_a_time_capturing_step(IStep step)
        {
            SimpleTestRun = new SimpleTestRunUsingDynamicState();
            ScenarioToRun = SimpleTestRun.PassingScenarioWithTimeCapturingStep;
        }

        public void the_scenario_is_run(IStep step)
        {
            ScenarioToRun();
        }

        public void the_scenario_name_should_come_from_the_fact_method_name(IStep step)
        {
            Assert.Equal(ExpectedScenarioName, SimpleTestRun.Scenario.Name);
        }

        public void the_feature_name_should_come_from_the_class_name(IStep step)
        {
            Assert.Equal(ExpectedFeatureName, SimpleTestRun.Scenario.FeatureName);
        }

        public void the_step_name_should_come_from_the_method_name(IStep step)
        {
            Assert.Equal(ExpectedStep1Name, SimpleTestRun.Scenario.Steps[0].Name);
            Assert.Equal(ExpectedStep2Name, SimpleTestRun.Scenario.Steps[1].Name);
            Assert.Equal(ExpectedStep3Name, SimpleTestRun.Scenario.Steps[2].Name);
        }

        internal void the_scenario_is_run_and_the_exception_caught(IStep step)
        {
            try
            {
                ScenarioToRun();
            }
            catch(Exception ex)
            {
                step.State.Exception = ex;
            }
        }

        internal void the_step_exception_have_a_message_of_x(IStep step)
        {
            Assert.Equal(ExpectedExceptionMessage, step.State.Exception.Message);
        }

        internal void a_simple_failing_scenario(IStep obj)
        {
            SimpleTestRun = new SimpleTestRunUsingDynamicState();
            ScenarioToRun = SimpleTestRun.FailingScenario;
        }

        public void the_area_path_should_come_from_the_namespace(IStep step)
        {
            Assert.Equal(ExpectedAreaPath, SimpleTestRun.Scenario.AreaPath);
        }

        internal void a_simple_passing_async_scenario(IStep step)
        {
            SimpleTestRun = new SimpleTestRunUsingDynamicState();
            ScenarioToRunAsync = SimpleTestRun.PassingScenarioAsync;
        }

        internal async Task the_async_scenario_is_run(IStep step)
        {
            await ScenarioToRunAsync();
        }

        internal void a_simple_failing_async_scenario(IStep step)
        {
            SimpleTestRun = new SimpleTestRunUsingDynamicState();
            ScenarioToRunAsync = SimpleTestRun.FailingScenarioAsync;
        }

        internal async Task the_scenario_is_run_async_and_the_exception_caught(IStep step)
        {
            try
            {
                await ScenarioToRunAsync();
            }
            catch (Exception ex)
            {
                step.State.Exception = ex;
            }
        }
        internal void the_step_outcome_should_show_failed(IStep step)
        {
            Assert.Equal(Outcome.Failed, SimpleTestRun.Scenario.Steps[1].Outcome);
        }

        internal void the_step_outcome_should_show_passed(IStep step)
        {
            Assert.Equal(Outcome.Passed, SimpleTestRun.Scenario.Steps[0].Outcome);
        }


        internal void the_step_start_date_should_be_before_the_step_captured_time(IStep step)
        {
            Assert.True(SimpleTestRun.Scenario.State.CapturedTime > SimpleTestRun.Scenario.Steps[2].StartTime);
        }

        internal void the_step_end_date_should_be_after_the_step_captured_time(IStep step)
        {
            Assert.True(SimpleTestRun.Scenario.State.CapturedTime < SimpleTestRun.Scenario.Steps[2].EndTime);
        }

    }
}
