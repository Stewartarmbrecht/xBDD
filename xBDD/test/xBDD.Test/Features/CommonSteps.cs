using System;
using System.Threading.Tasks;
using xBDD.Test.Sample;

namespace xBDD.Test.Features
{
    public class CommonSteps
    {
        public ISimpleTestRun SimpleTestRun { get; set; }
        public Action ScenarioToRun { get; set; }
        public Func<Task> ScenarioToRunAsync { get; private set; }
        public Exception CaughtException { get; set; }

        public void a_simple_passing_scenario_is_run(IStep step)
        {
            SimpleTestRun = new SimpleTestRunUsingDynamicState();
            SimpleTestRun.PassingScenario();
        }
        public async Task a_simple_passing_async_scenario_is_run(IStep step)
        {
            SimpleTestRun = new SimpleTestRunUsingDynamicState();
            await SimpleTestRun.PassingScenarioAsync();
        }
        public void a_simple_passing_scenario_with_typed_state_is_run(IStep obj)
        {
            SimpleTestRun = new SimpleTestRunUsingTypedState();
            SimpleTestRun.PassingScenario();
        }

        public void a_simple_failing_scenario_is_run_and_the_exception_caught(IStep step)
        {
            SimpleTestRun = new SimpleTestRunUsingDynamicState();
            try
            {
                SimpleTestRun.FailingScenario();
            }
            catch (Exception ex)
            {
                CaughtException = ex;
            }
        }
        public async Task a_simple_failing_async_scenario_is_run_and_the_exception_caught(IStep step)
        {
            SimpleTestRun = new SimpleTestRunUsingDynamicState();
            try
            {
                await SimpleTestRun.FailingScenarioAsync();
            }
            catch (Exception ex)
            {
                CaughtException = ex;
            }
        }
        public void a_simple_failing_scenario_with_a_failing_time_capturing_step_is_run_and_the_exception_caught(IStep obj)
        {
            SimpleTestRun = new SimpleTestRunUsingDynamicState();
            try
            {
                SimpleTestRun.FailingScenarioWithFailingTimeCapturingStep();
            }
            catch (Exception ex)
            {
                CaughtException = ex;
            }
        }
        public void a_simple_passing_scenario_with_a_time_capturing_step_is_run(IStep step)
        {
            SimpleTestRun = new SimpleTestRunUsingDynamicState();
            SimpleTestRun.PassingScenarioWithTimeCapturingStep();
        }

        internal void a_simple_scenario_with_a_skipped_step_is_run_and_the_exception_is_caught(IStep step)
        {
            SimpleTestRun = new SimpleTestRunUsingTypedState();
            try
            {
                SimpleTestRun.SkippedScenario();
            }
            catch (Exception ex)
            {
                CaughtException = ex;
            }
        }

    }
}
