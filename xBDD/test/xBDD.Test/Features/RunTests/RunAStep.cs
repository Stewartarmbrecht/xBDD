using System;
using System.Threading.Tasks;
using xBDD.xUnit;
using Xunit.Abstractions;

namespace xBDD.Test.Features.RunTests
{
    public class RunAStep
    {
        private readonly IOutputWriter outputWriter;

        public RunAStep(ITestOutputHelper output)
        {
            outputWriter = new OutputWriter(output);
        }

        [ScenarioFact]
        public void PassSync()
        {
            var s = new Steps();
            s.State.CapturedStartTime = new DateTime();
            s.State.CapturedEndTime = new DateTime();
            s.State.StepOutcome = Outcome.Passed;
            s.State.StepReason = null;
            s.State.StepException = null;
            s.State.StepName = "my action";
            xBDD.CurrentRun.AddScenario()
                .SetOutputWriter(outputWriter)
                .Given(s.Given.a_scenario)
                .And(s.Given.a_when_step_with_the_name_StepName)
                .And(s.Given.the_current_time_is_captured_as_CapturedStartTime)
                .When(s.When.the_scenario_is_run)
                .And(s.When.the_current_time_is_captured_as_CapturedEndTime)
                .Then(s.Then.the_step_outcome_should_be_StepOutcome)
                .And(s.Then.the_step_start_time_should_be_after_the_CapturedStartTime_and_before_the_step_end_time)
                .And(s.Then.the_step_end_time_should_be_before_the_CapturedEndTime_and_after_the_step_start_time)
                .And(s.Then.the_step_reason_should_be_StepReason)
                .And(s.Then.the_step_exception_should_be_the_exception_thrown)
                .Run();
        }

        [ScenarioFact]
        public async Task PassAsync()
        {
            var s = new Steps();
            s.State.CapturedStartTime = new DateTime();
            s.State.CapturedEndTime = new DateTime();
            s.State.StepOutcome = Outcome.Passed;
            s.State.StepReason = null;
            s.State.StepException = null;
            s.State.StepName = "my action";
            await xBDD.CurrentRun.AddScenario()
                .SetOutputWriter(outputWriter)
                .Given(s.Given.a_scenario)
                .And(s.Given.a_when_step_with_the_name_StepName)
                .And(s.Given.the_current_time_is_captured_as_CapturedStartTime)
                .WhenAsync(s.When.the_scenario_is_run_asynchronously)
                .And(s.When.the_current_time_is_captured_as_CapturedEndTime)
                .Then(s.Then.the_step_outcome_should_be_StepOutcome)
                .And(s.Then.the_step_start_time_should_be_after_the_CapturedStartTime_and_before_the_step_end_time)
                .And(s.Then.the_step_end_time_should_be_before_the_CapturedEndTime_and_after_the_step_start_time)
                .And(s.Then.the_step_reason_should_be_StepReason)
                .And(s.Then.the_step_exception_should_be_the_exception_thrown)
                .RunAsync();
        }
        [ScenarioFact]
        public void FailSync()
        {
            var s = new Steps();
            s.State.CapturedStartTime = new DateTime();
            s.State.CapturedEndTime = new DateTime();
            s.State.StepOutcome = Outcome.Failed;
            s.State.StepException = new Exception("My Exception");
            s.State.StepExceptionMessage = "My Exception";
            s.State.StepReason = "My Exception";
            xBDD.CurrentRun.AddScenario()
                .SetOutputWriter(outputWriter)
                .Given(s.Given.a_scenario)
                .And(s.Given.a_step_that_throws_an_exception)
                .And(s.Given.the_current_time_is_captured_as_CapturedStartTime)
                .When(s.When.the_scenario_is_run_and_the_exception_caught)
                .And(s.When.the_current_time_is_captured_as_CapturedEndTime)
                .Then(s.Then.the_step_outcome_should_be_StepOutcome)
                .And(s.Then.the_step_start_time_should_be_after_the_CapturedStartTime_and_before_the_step_end_time)
                .And(s.Then.the_step_end_time_should_be_before_the_CapturedEndTime_and_after_the_step_start_time)
                .And(s.Then.the_step_reason_should_be_StepReason)
                .And(s.Then.the_step_exception_should_be_the_exception_thrown)
                .And(s.Then.the_step_exception_message_should_be_StepExceptionMessage)
                .Run();
        }
        [ScenarioFact]
        public async Task FailAsync()
        {
            var s = new Steps();
            s.State.CapturedStartTime = new DateTime();
            s.State.CapturedEndTime = new DateTime();
            s.State.StepOutcome = Outcome.Failed;
            s.State.StepException = new Exception("My Exception");
            s.State.StepReason = "My Exception";
            await xBDD.CurrentRun.AddScenario()
                .SetOutputWriter(outputWriter)
                .Given(s.Given.a_scenario)
                .And(s.Given.an_async_step_that_throws_an_exception)
                .And(s.Given.the_current_time_is_captured_as_CapturedStartTime)
                .WhenAsync(s.When.the_parent_scenario_is_run_async_and_the_exception_caught)
                .And(s.When.the_current_time_is_captured_as_CapturedEndTime)
                .Then(s.Then.the_step_outcome_should_be_StepOutcome)
                .And(s.Then.the_step_start_time_should_be_after_the_CapturedStartTime_and_before_the_step_end_time)
                .And(s.Then.the_step_end_time_should_be_before_the_CapturedEndTime_and_after_the_step_start_time)
                .And(s.Then.the_step_reason_should_be_StepReason)
                .And(s.Then.the_step_exception_should_be_the_exception_thrown)
                .RunAsync();
        }

        [ScenarioFact]
        public void SkipSync()
        {
            var s = new Steps();
            s.State.CapturedStartTime = new DateTime();
            s.State.CapturedEndTime = new DateTime();
            s.State.StepOutcome = Outcome.Skipped;
            s.State.StepException = new SkipStepException("Just Because");
            s.State.StepReason = "Just Because";
            xBDD.CurrentRun.AddScenario()
                .SetOutputWriter(outputWriter)
                .Given(s.Given.a_scenario)
                .And(s.Given.a_step_that_throws_a_skip_exception)
                .And(s.Given.the_current_time_is_captured_as_CapturedStartTime)
                .When(s.When.the_parent_scenario_is_run_and_the_exception_caught)
                .And(s.When.the_current_time_is_captured_as_CapturedEndTime)
                .Then(s.Then.the_step_outcome_should_be_StepOutcome)
                .And(s.Then.the_step_start_time_should_be_after_the_CapturedStartTime_and_before_the_step_end_time)
                .And(s.Then.the_step_end_time_should_be_before_the_CapturedEndTime_and_after_the_step_start_time)
                .And(s.Then.the_step_reason_should_be_StepReason)
                .And(s.Then.the_step_exception_should_be_the_exception_thrown)
                .Run();
        }
        [ScenarioFact]
        public async Task SkipAsync()
        {
            var s = new Steps();
            s.State.CapturedStartTime = new DateTime();
            s.State.CapturedEndTime = new DateTime();
            s.State.StepOutcome = Outcome.Skipped;
            s.State.StepException = new SkipStepException("Just Because");
            s.State.StepReason = "Just Because";
            await xBDD.CurrentRun.AddScenario()
                .SetOutputWriter(outputWriter)
                .Given(s.Given.a_scenario)
                .And(s.Given.an_async_step_that_throws_a_skip_exception)
                .And(s.Given.the_current_time_is_captured_as_CapturedStartTime)
                .WhenAsync(s.When.the_parent_scenario_is_run_async_and_the_exception_caught)
                .And(s.When.the_current_time_is_captured_as_CapturedEndTime)
                .Then(s.Then.the_step_outcome_should_be_StepOutcome)
                .And(s.Then.the_step_start_time_should_be_after_the_CapturedStartTime_and_before_the_step_end_time)
                .And(s.Then.the_step_end_time_should_be_before_the_CapturedEndTime_and_after_the_step_start_time)
                .And(s.Then.the_step_reason_should_be_StepReason)
                .And(s.Then.the_step_exception_should_be_the_exception_thrown)
                .RunAsync();
        }

        [ScenarioFact]
        public void SkipBecauseOfPreviousSkipSync()
        {
            var s = new Steps();
            s.State.StepReason = "Previous Error";
            s.State.ExpectedExceptionType = typeof(SkipStepException);
            xBDD.CurrentRun.AddScenario()
                .SetOutputWriter(outputWriter)
                .Given(s.Given.a_scenario_with_one_skipped_step)
                .And(s.Given.the_last_step_includes_ReturnIfPreviousError_line)
                .When(s.When.the_scenario_is_run_and_the_exception_caught)
                .Then(s.Then.code_in_the_last_step_after_the_ReturnIfPreviousError_line_should_not_execute)
                .And(s.Then.code_in_the_last_step_before_the_ReturnIfPreviousError_line_should_execute)
                .And(s.Then.the_last_step_should_have_a_skipped_outcome)
                .And(s.Then.the_step_reason_should_be_StepReason)
                .And(s.Then.the_step_exception_type_should_be_ExpectedExceptionType)
                .Run();
        }
        [ScenarioFact]
        public async Task SkipBecauseOfPreviousSkipAsync()
        {
            var s = new Steps();
            s.State.StepReason = "Previous Error";
            s.State.ExpectedExceptionType = typeof(SkipStepException);
            await xBDD.CurrentRun.AddScenario()
                .SetOutputWriter(outputWriter)
                .Given(s.Given.a_scenario_with_one_skipped_async_step)
                .And(s.Given.the_last_step_includes_ReturnIfPreviousError_line)
                .WhenAsync(s.When.the_parent_scenario_is_run_async_and_the_exception_caught)
                .Then(s.Then.code_in_the_last_step_after_the_ReturnIfPreviousError_line_should_not_execute)
                .And(s.Then.code_in_the_last_step_before_the_ReturnIfPreviousError_line_should_execute)
                .And(s.Then.the_last_step_should_have_a_skipped_outcome)
                .And(s.Then.the_step_reason_should_be_StepReason)
                .And(s.Then.the_step_exception_type_should_be_ExpectedExceptionType)
                .RunAsync();
        }

    }
}
