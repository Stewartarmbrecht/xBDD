using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace xBDD.Test.Features.RunTests
{
    public class FailAStep
    {
        [ScenarioFact]
        public void PassSync()
        {
            var s = new Steps();
            s.CapturedStartTime = new DateTime();
            s.CapturedEndTime = new DateTime();
            s.ExpectedOutcome = Outcome.Passed;
            s.ExpectedException = null;
            s.ExpectedReason = null;
            xBDD.CurrentRun.AddScenario()
                .Given(s.a_scenario)
                .And(s.a_step_that_does_not_thwow_an_exception)
                .And(s.the_current_time_is_captured_as_CapturedStartTime)
                .When(s.the_parent_scenario_is_run)
                .And(s.the_current_time_is_captured_as_CapturedEndTime)
                .Then(s.the_step_outcome_should_be_ExpectedOutcome)
                .And(s.the_start_time_should_be_after_the_CapturedStartTime_and_before_the_step_end_time)
                .And(s.the_end_time_should_be_before_the_CapturedEndTime_and_after_the_start_time)
                .And(s.the_step_reason_should_be_ExpectedReason)
                .And(s.the_step_exception_should_be_ExpectedException)
                .Run();
        }

        [ScenarioFact]
        public void PassAsync()
        {
            var s = new Steps();
            s.CapturedStartTime = new DateTime();
            s.CapturedEndTime = new DateTime();
            s.ExpectedOutcome = Outcome.Passed;
            s.ExpectedException = null;
            s.ExpectedReason = null;
            xBDD.CurrentRun.AddScenario()
                .Given(s.a_scenario)
                .And(s.an_async_step_that_does_not_thwow_an_exception)
                .And(s.the_current_time_is_captured_as_CapturedStartTime)
                .WhenAsync(s.the_parent_scenario_is_run_async)
                .And(s.the_current_time_is_captured_as_CapturedEndTime)
                .Then(s.the_step_outcome_should_be_ExpectedOutcome)
                .And(s.the_start_time_should_be_after_the_CapturedStartTime_and_before_the_step_end_time)
                .And(s.the_end_time_should_be_before_the_CapturedEndTime_and_after_the_start_time)
                .And(s.the_step_reason_should_be_ExpectedReason)
                .And(s.the_step_exception_should_be_ExpectedException)
                .RunAsync();
        }
        [ScenarioFact]
        public void FailSync()
        {
            var s = new Steps();
            s.CapturedStartTime = new DateTime();
            s.CapturedEndTime = new DateTime();
            s.ExpectedOutcome = Outcome.Failed;
            s.ExpectedException = new Exception("My Exception");
            s.ExpectedReason = "My Exception";
            xBDD.CurrentRun.AddScenario()
                .Given(s.a_scenario)
                .And(s.a_step_that_throws_an_exception)
                .And(s.the_current_time_is_captured_as_CapturedStartTime)
                .When(s.the_parent_scenario_is_run_and_the_exception_caught)
                .And(s.the_current_time_is_captured_as_CapturedEndTime)
                .Then(s.the_step_outcome_should_be_ExpectedOutcome)
                .And(s.the_start_time_should_be_after_the_CapturedStartTime_and_before_the_step_end_time)
                .And(s.the_end_time_should_be_before_the_CapturedEndTime_and_after_the_start_time)
                .And(s.the_step_reason_should_be_ExpectedReason)
                .And(s.the_step_exception_should_be_ExpectedException)
                .Run();
        }
        [ScenarioFact]
        public void FailAsync()
        {
            var s = new Steps();
            s.CapturedStartTime = new DateTime();
            s.CapturedEndTime = new DateTime();
            s.ExpectedOutcome = Outcome.Failed;
            s.ExpectedException = new Exception("My Exception");
            s.ExpectedReason = "My Exception";
            xBDD.CurrentRun.AddScenario()
                .Given(s.a_scenario)
                .And(s.an_async_step_that_throws_an_exception)
                .And(s.the_current_time_is_captured_as_CapturedStartTime)
                .WhenAsync(s.the_parent_scenario_is_run_async_and_the_exception_caught)
                .And(s.the_current_time_is_captured_as_CapturedEndTime)
                .Then(s.the_step_outcome_should_be_ExpectedOutcome)
                .And(s.the_start_time_should_be_after_the_CapturedStartTime_and_before_the_step_end_time)
                .And(s.the_end_time_should_be_before_the_CapturedEndTime_and_after_the_start_time)
                .And(s.the_step_reason_should_be_ExpectedReason)
                .And(s.the_step_exception_should_be_ExpectedException)
                .RunAsync();
        }

        [ScenarioFact]
        public void SkipSync()
        {
            var s = new Steps();
            s.CapturedStartTime = new DateTime();
            s.CapturedEndTime = new DateTime();
            s.ExpectedOutcome = Outcome.Skipped;
            s.ExpectedException = new SkipStepException("Just Because");
            s.ExpectedReason = "Just Because";
            xBDD.CurrentRun.AddScenario()
                .Given(s.a_scenario)
                .And(s.a_step_that_throws_a_skip_exception)
                .And(s.the_current_time_is_captured_as_CapturedStartTime)
                .When(s.the_parent_scenario_is_run_and_the_exception_caught)
                .And(s.the_current_time_is_captured_as_CapturedEndTime)
                .Then(s.the_step_outcome_should_be_ExpectedOutcome)
                .And(s.the_start_time_should_be_after_the_CapturedStartTime_and_before_the_step_end_time)
                .And(s.the_end_time_should_be_before_the_CapturedEndTime_and_after_the_start_time)
                .And(s.the_step_reason_should_be_ExpectedReason)
                .And(s.the_step_exception_should_be_ExpectedException)
                .Run();
        }
        [ScenarioFact]
        public void SkipAsync()
        {
            var s = new Steps();
            xBDD.CurrentRun.AddScenario().Skip();
        }

        [ScenarioFact]
        public void SkipBecauseOfPreviousSkipSync()
        {
            var s = new Steps();
            xBDD.CurrentRun.AddScenario()
                .Given(s.a_scenario_with_one_skipped_step)
                .And(s.the_last_step_includes_ReturnIfPreviousError_line)
                .When(s.the_scenario_is_run)
                .Then(s.code_in_the_last_step_after_the_ReturnIfPreviousError_line_should_not_execute)
                .And(s.code_in_the_last_step_before_the_ReturnIfPreviousError_line_should_execute)
                .And(s.the_last_step_should_have_a_skipped_outcome)
                .Run();
        }
        [ScenarioFact]
        public void SkipBecauseOfPreviousSkipAsync()
        {
            var s = new Steps();
            xBDD.CurrentRun.AddScenario().Skip();
        }

    }
}
