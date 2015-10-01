using System.Threading.Tasks;
using xBDD.Model;
using xBDD.Test;
using xBDD.xUnit;
using Xunit;
using Xunit.Abstractions;

namespace xBDD.Core.Test.Features.RunTests
{
    [Collection("xBDDCoreTest")]
    public class RunAStep
    {
        private readonly OutputWriter outputWriter;

        public RunAStep(ITestOutputHelper output)
        {
            outputWriter = new OutputWriter(output);
        }

        [ScenarioFact]
        public void PassSync()
        {
            xBDD.CurrentRun
                .AddScenario(this)
                .SetOutputWriter(outputWriter)
                .Skip("Re-writing");
            //var s = new Steps();
            //s.State.CapturedStartTime = new DateTime();
            //s.State.CapturedEndTime = new DateTime();
            //s.c.State.StepOutcome = Outcome.Passed;
            //s.c.State.StepReason = null;
            //s.c.State.StepException = null;
            //s.c.State.StepName = "my action";
            //xBDD.CurrentRun.AddScenario(this)
            //    .SetOutputWriter(outputWriter)
            //    .Given(s.c.Given.a_scenario)
            //    .And(s.c.Given.a_when_step_with_the_name_StepName)
            //    .And(s.Given.the_current_time_is_captured_as_CapturedStartTime)
            //    .When(s.c.When.the_scenario_is_run)
            //    .And(s.When.the_current_time_is_captured_as_CapturedEndTime)
            //    .Then(s.c.Then.the_step_outcome_should_be_StepOutcome)
            //    .And(s.Then.the_step_start_time_should_be_after_the_CapturedStartTime_and_before_the_step_end_time)
            //    .And(s.Then.the_step_end_time_should_be_before_the_CapturedEndTime_and_after_the_step_start_time)
            //    .And(s.c.Then.the_step_reason_should_be_StepReason)
            //    .And(s.c.Then.the_step_exception_should_be_the_exception_thrown)
            //    .Run();
        }

        [ScenarioFact]
        public async Task PassAsync()
        {
            await xBDD.CurrentRun
                .AddScenario(this)
                .SetOutputWriter(outputWriter)
                .SkipAsync("Re-writing");
            //var s = new Steps();
            //s.State.CapturedStartTime = new DateTime();
            //s.State.CapturedEndTime = new DateTime();
            //s.c.State.StepOutcome = Outcome.Passed;
            //s.c.State.StepReason = null;
            //s.c.State.StepException = null;
            //s.c.State.StepName = "my action";
            //await xBDD.CurrentRun.AddScenario(this)
            //    .SetOutputWriter(outputWriter)
            //    .Given(s.c.Given.a_scenario)
            //    .And(s.c.Given.a_when_step_with_the_name_StepName)
            //    .And(s.Given.the_current_time_is_captured_as_CapturedStartTime)
            //    .WhenAsync(s.c.When.the_scenario_is_run_asynchronously)
            //    .And(s.When.the_current_time_is_captured_as_CapturedEndTime)
            //    .Then(s.c.Then.the_step_outcome_should_be_StepOutcome)
            //    .And(s.Then.the_step_start_time_should_be_after_the_CapturedStartTime_and_before_the_step_end_time)
            //    .And(s.Then.the_step_end_time_should_be_before_the_CapturedEndTime_and_after_the_step_start_time)
            //    .And(s.c.Then.the_step_reason_should_be_StepReason)
            //    .And(s.c.Then.the_step_exception_should_be_the_exception_thrown)
            //    .RunAsync();
        }
        [ScenarioFact]
        public void FailSync()
        {
            xBDD.CurrentRun
                .AddScenario(this)
                .SetOutputWriter(outputWriter)
                .Skip("Re-writing");
            //var s = new Steps();
            //s.State.CapturedStartTime = new DateTime();
            //s.State.CapturedEndTime = new DateTime();
            //s.c.State.StepOutcome = Outcome.Failed;
            //s.c.State.StepException = new Exception("My Exception");
            //s.c.State.StepExceptionMessage = "My Exception";
            //s.c.State.StepReason = "My Exception";
            //xBDD.CurrentRun.AddScenario(this)
            //    .SetOutputWriter(outputWriter)
            //    .Given(s.c.Given.a_scenario)
            //    .And(s.Given.a_step_that_throws_an_exception)
            //    .And(s.Given.the_current_time_is_captured_as_CapturedStartTime)
            //    .When(s.c.When.the_scenario_is_run_and_the_exception_caught)
            //    .And(s.When.the_current_time_is_captured_as_CapturedEndTime)
            //    .Then(s.c.Then.the_step_outcome_should_be_StepOutcome)
            //    .And(s.Then.the_step_start_time_should_be_after_the_CapturedStartTime_and_before_the_step_end_time)
            //    .And(s.Then.the_step_end_time_should_be_before_the_CapturedEndTime_and_after_the_step_start_time)
            //    .And(s.c.Then.the_step_reason_should_be_StepReason)
            //    .And(s.c.Then.the_step_exception_should_be_the_exception_thrown)
            //    .And(s.c.Then.the_step_exception_message_should_be_StepExceptionMessage)
            //    .Run();
        }
        [ScenarioFact]
        public async Task FailAsync()
        {
            await xBDD.CurrentRun
                .AddScenario(this)
                .SetOutputWriter(outputWriter)
                .SkipAsync("Re-writing");
            //var s = new Steps();
            //s.State.CapturedStartTime = new DateTime();
            //s.State.CapturedEndTime = new DateTime();
            //s.c.State.StepOutcome = Outcome.Failed;
            //s.c.State.StepException = new Exception("My Exception");
            //s.c.State.StepReason = "My Exception";
            //await xBDD.CurrentRun.AddScenario(this)
            //    .SetOutputWriter(outputWriter)
            //    .Given(s.c.Given.a_scenario)
            //    .And(s.Given.an_async_step_that_throws_an_exception)
            //    .And(s.Given.the_current_time_is_captured_as_CapturedStartTime)
            //    .WhenAsync(s.When.the_parent_scenario_is_run_async_and_the_exception_caught)
            //    .And(s.When.the_current_time_is_captured_as_CapturedEndTime)
            //    .Then(s.c.Then.the_step_outcome_should_be_StepOutcome)
            //    .And(s.Then.the_step_start_time_should_be_after_the_CapturedStartTime_and_before_the_step_end_time)
            //    .And(s.Then.the_step_end_time_should_be_before_the_CapturedEndTime_and_after_the_step_start_time)
            //    .And(s.c.Then.the_step_reason_should_be_StepReason)
            //    .And(s.c.Then.the_step_exception_should_be_the_exception_thrown)
            //    .RunAsync();
        }

        [ScenarioFact]
        public void SkipSync()
        {
            xBDD.CurrentRun
                .AddScenario(this)
                .SetOutputWriter(outputWriter)
                .Skip("Re-writing");
            //var s = new Steps();
            //s.State.CapturedStartTime = new DateTime();
            //s.State.CapturedEndTime = new DateTime();
            //s.c.State.StepOutcome = Outcome.Skipped;
            //s.c.State.StepException = new SkipStepException("Just Because");
            //s.c.State.StepReason = "Just Because";
            //xBDD.CurrentRun.AddScenario(this)
            //    .SetOutputWriter(outputWriter)
            //    .Given(s.c.Given.a_scenario)
            //    .And(s.Given.a_step_that_throws_a_skip_exception)
            //    .And(s.Given.the_current_time_is_captured_as_CapturedStartTime)
            //    .When(s.When.the_parent_scenario_is_run_and_the_exception_caught)
            //    .And(s.When.the_current_time_is_captured_as_CapturedEndTime)
            //    .Then(s.c.Then.the_step_outcome_should_be_StepOutcome)
            //    .And(s.Then.the_step_start_time_should_be_after_the_CapturedStartTime_and_before_the_step_end_time)
            //    .And(s.Then.the_step_end_time_should_be_before_the_CapturedEndTime_and_after_the_step_start_time)
            //    .And(s.c.Then.the_step_reason_should_be_StepReason)
            //    .And(s.c.Then.the_step_exception_should_be_the_exception_thrown)
            //    .Run();
        }
        [ScenarioFact]
        public async Task SkipAsync()
        {
            await xBDD.CurrentRun
                .AddScenario(this)
                .SetOutputWriter(outputWriter)
                .SkipAsync("Re-writing");
            //var s = new Steps();
            //s.State.CapturedStartTime = new DateTime();
            //s.State.CapturedEndTime = new DateTime();
            //s.c.State.StepOutcome = Outcome.Skipped;
            //s.c.State.StepException = new SkipStepException("Just Because");
            //s.c.State.StepReason = "Just Because";
            //await xBDD.CurrentRun.AddScenario(this)
            //    .SetOutputWriter(outputWriter)
            //    .Given(s.c.Given.a_scenario)
            //    .And(s.Given.an_async_step_that_throws_a_skip_exception)
            //    .And(s.Given.the_current_time_is_captured_as_CapturedStartTime)
            //    .WhenAsync(s.When.the_parent_scenario_is_run_async_and_the_exception_caught)
            //    .And(s.When.the_current_time_is_captured_as_CapturedEndTime)
            //    .Then(s.c.Then.the_step_outcome_should_be_StepOutcome)
            //    .And(s.Then.the_step_start_time_should_be_after_the_CapturedStartTime_and_before_the_step_end_time)
            //    .And(s.Then.the_step_end_time_should_be_before_the_CapturedEndTime_and_after_the_step_start_time)
            //    .And(s.c.Then.the_step_reason_should_be_StepReason)
            //    .And(s.c.Then.the_step_exception_should_be_the_exception_thrown)
            //    .RunAsync();
        }

        [ScenarioFact]
        public void SkipBecauseOfPreviousSkipSync()
        {
            xBDD.CurrentRun
                .AddScenario(this)
                .SetOutputWriter(outputWriter)
                .Skip("Re-writing");
            //var s = new Steps();
            //s.c.State.StepReason = "Previous Error";
            //s.State.ExpectedExceptionType = typeof(SkipStepException);
            //xBDD.CurrentRun.AddScenario(this)
            //    .SetOutputWriter(outputWriter)
            //    .Given(s.Given.a_scenario_with_one_skipped_step)
            //    .And(s.Given.the_last_step_includes_ReturnIfPreviousError_line)
            //    .When(s.c.When.the_scenario_is_run_and_the_exception_caught)
            //    .Then(s.Then.code_in_the_last_step_after_the_ReturnIfPreviousError_line_should_not_execute)
            //    .And(s.Then.code_in_the_last_step_before_the_ReturnIfPreviousError_line_should_execute)
            //    .And(s.Then.the_last_step_should_have_a_skipped_outcome)
            //    .And(s.c.Then.the_step_reason_should_be_StepReason)
            //    .And(s.Then.the_step_exception_type_should_be_ExpectedExceptionType)
            //    .Run();
        }
        [ScenarioFact]
        public async Task SkipBecauseOfPreviousSkipAsync()
        {
            await xBDD.CurrentRun
                .AddScenario(this)
                .SetOutputWriter(outputWriter)
                .SkipAsync("Re-writing");
            //var s = new Steps();
            //s.c.State.StepReason = "Previous Error";
            //s.State.ExpectedExceptionType = typeof(SkipStepException);
            //await xBDD.CurrentRun.AddScenario(this)
            //    .SetOutputWriter(outputWriter)
            //    .Given(s.Given.a_scenario_with_one_skipped_async_step)
            //    .And(s.Given.the_last_step_includes_ReturnIfPreviousError_line)
            //    .WhenAsync(s.When.the_parent_scenario_is_run_async_and_the_exception_caught)
            //    .Then(s.Then.code_in_the_last_step_after_the_ReturnIfPreviousError_line_should_not_execute)
            //    .And(s.Then.code_in_the_last_step_before_the_ReturnIfPreviousError_line_should_execute)
            //    .And(s.Then.the_last_step_should_have_a_skipped_outcome)
            //    .And(s.c.Then.the_step_reason_should_be_StepReason)
            //    .And(s.Then.the_step_exception_type_should_be_ExpectedExceptionType)
            //    .RunAsync();
        }

        [ScenarioFact]
        public void ReusableStepThatUsesObjectCreatedInPreviousStep()
        {
            Wrapper<Scenario> scenarioWrapper = new Wrapper<Scenario>();
            Wrapper<int> count = new Wrapper<int>();
            xBDD.CurrentRun
                .AddScenario(this)
                .SetOutputWriter(outputWriter)
                .Given(Code.HasMethod("\\Features\\RunTests\\SampleCode\\AddAReusableStepThatUsesObjectCreatedInPreviousStep.cs"))
                .When(Code.ExecuteMethod((s) =>
                {
                    scenarioWrapper.Object = new SampleCode.AddAReusableStepThatUsesObjectCreatedInPreviousStep().Add(count);
                }))
                .Then(xBDD.CreateStep("the count should be 3", (s) => { Assert.Equal(3, count.Object); }))
                .And(ScenarioTarget.WillHaveOutcome(Outcome.Passed, scenarioWrapper))
                .Run();
        }
    }
}
