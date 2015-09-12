using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using xBDD.Core;
using Xunit;

namespace xBDD.Test.Features.RunTests
{
    public class Steps
    {
        public StepsState State { get; set; }
        public GivenSteps Given { get; set; }
        public WhenSteps When { get; set; }
        public ThenSteps Then { get; set; }
        public Steps()
        {
            State = new StepsState();
            Given = new GivenSteps(State);
            When = new WhenSteps(State);
            Then = new ThenSteps(State);
        }
    }
    public class StepsState : CommonState
    {
        public string ReturnIfPreviousError = "step.ReturnIfPreviousError();";
        public bool CodeExecutedThatShould { get; set; }
        public bool CodeExecutedThatShouldnt { get; set; }
        public DateTime Time1 { get; internal set; }
        public DateTime Time2 { get; internal set; }
        public DateTime CapturedStartTime { get; internal set; }
        public DateTime CapturedEndTime { get; internal set; }
        public string ExceptionMessage { get; internal set; }
        public Type ExpectedExceptionType { get; internal set; }
    }

    [StepLibrary]
    public class GivenSteps : CommonGivenSteps
    {
        StepsState state;
        public GivenSteps(StepsState state)
            : base(state)
        {
            this.state = state;
        }
        internal void a_scenario_with_one_skipped_step(IStep step)
        {
            var testRun = new TestRun(new CoreFactory());
            state.Scenario = testRun.AddScenario("My Scenario")
                .Given("my condition", s => { System.Threading.Thread.Sleep(5); })
                .When("my action", s => { System.Threading.Thread.Sleep(5); throw new SkipStepException("Test"); })
                .Then("my expectation", s => {
                    state.CodeExecutedThatShould = true;
                    s.ReturnIfPreviousError();
                    state.CodeExecutedThatShouldnt = true;
                });
            state.Step = state.Scenario.Steps[2];
        }
        internal void the_last_step_includes_ReturnIfPreviousError_line(IStep step)
        {
            step.ReplaceNameParameters("ReturnIfPreviousError", state.ReturnIfPreviousError.Quote());
        }
        public void the_current_time_is_captured_as_CapturedStartTime(IStep step)
        {
            state.CapturedStartTime = DateTime.Now;
        }
        internal void an_async_step_that_checks_for_a_previous_exception(IStep obj)
        {
            state.Scenario.WhenAsync("my step that checks", stepTarget => {
                return Task.Run(() => {
                    stepTarget.ReturnIfPreviousError();
                });
            });
        }
        internal void a_scenario_with_one_skipped_async_step(IStep obj)
        {
            var testRun = new TestRun(new CoreFactory());
            state.Scenario = testRun.AddScenario("My Scenario")
                .GivenAsync("my condition", s => { return Task.Run(() => { System.Threading.Thread.Sleep(5); }); })
                .WhenAsync("my action", s => { return Task.Run(() => { System.Threading.Thread.Sleep(5); throw new SkipStepException("Test"); }); })
                .ThenAsync("my expectation", s => {
                    return Task.Run(() => {
                        state.CodeExecutedThatShould = true;
                        s.ReturnIfPreviousError();
                        state.CodeExecutedThatShouldnt = true;
                    });
                });
            state.Step = state.Scenario.Steps[2];
        }
        internal void an_async_step_that_does_not_thwow_an_exception(IStep step)
        {
            state.Scenario.WhenAsync("my test async step", stepTarget => { return Task.Run(() => { return; }); });
            state.Step = state.Scenario.Steps[0];
        }
        internal void a_step_that_throws_an_exception(IStep obj)
        {
            state.Scenario.When("my step", stepTarget => { throw state.StepException; });
            state.Step = state.Scenario.Steps[0];
        }
        internal void an_async_step_that_throws_an_exception(IStep obj)
        {
            state.Scenario.WhenAsync("my step", stepTarget => { return Task.Run(() => { throw state.StepException; }); });
            state.Step = state.Scenario.Steps[0];
        }
        internal void a_step_that_throws_a_skip_exception(IStep obj)
        {
            state.Scenario.When("my step", stepTarget => { throw state.StepException; });
            state.Step = state.Scenario.Steps[0];
        }
        internal void an_async_step_that_throws_a_skip_exception(IStep obj)
        {
            state.Scenario.WhenAsync("my step", s => { return Task.Run(() => { throw state.StepException; }); });
            state.Step = state.Scenario.Steps[0];
        }

    }
    [StepLibrary]
    public class WhenSteps : CommonWhenSteps
    {
        StepsState state;
        public WhenSteps(StepsState state)
            : base(state)
        {
            this.state = state;
        }
        public void the_parent_scenario_is_run(IStep step)
        {
            state.Scenario.Run();
        }
        public async Task the_parent_scenario_is_run_async(IStep step)
        {
            await state.Scenario.RunAsync();
        }
        internal void a_scenario_with_the_first_step_skipped_and_the_middle_step_failing_is_run(IStep step)
        {
            var testRun = new TestRun(new CoreFactory());
            state.Scenario = testRun.AddScenario("My Scenario")
                .Given("my condition", s => { System.Threading.Thread.Sleep(5); throw new SkipStepException("Not Implemented"); })
                .When("my action", s => { System.Threading.Thread.Sleep(5); throw new Exception("My Error"); })
                .Then("my expectation", s => { System.Threading.Thread.Sleep(5); });
            try
            {
                state.Scenario.Run();
            }
            catch (Exception ex)
            {
                if (!(ex.InnerException is SkipStepException) && !(ex.InnerException is Exception) && !(ex.InnerException.Message == "My Error"))
                    throw;
            }
        }
        internal void a_scenario_with_one_middle_failing_steps_is_run(IStep step)
        {
            var testRun = new TestRun(new CoreFactory());
            state.Scenario = testRun.AddScenario("My Scenario")
                .Given("my condition", s => { System.Threading.Thread.Sleep(5); })
                .When("my action", s => { System.Threading.Thread.Sleep(5); throw new Exception("My Error"); })
                .Then("my expectation", s => { System.Threading.Thread.Sleep(5); });
            try
            {
                state.Scenario.Run();
            }
            catch (Exception ex)
            {
                if (!(ex.InnerException is Exception) && !(ex.InnerException.Message != "My Error"))
                    throw;
            }
        }
        internal void a_scenario_with_one_not_implemented_steps_is_run(IStep step)
        {
            var testRun = new TestRun(new CoreFactory());
            state.Scenario = testRun.AddScenario("My Scenario")
                .Given("my condition", s => { System.Threading.Thread.Sleep(5); })
                .When("my action", s => { System.Threading.Thread.Sleep(5); throw new NotImplementedException(); })
                .Then("my expectation", s => { System.Threading.Thread.Sleep(5); });
            try
            {
                state.Scenario.Run();
            }
            catch (Exception ex)
            {
                if (!(ex.InnerException is NotImplementedException))
                    throw;
            }
        }
        internal void a_scenario_with_one_skipped_steps_is_run(IStep step)
        {
            var testRun = new TestRun(new CoreFactory());
            state.Scenario = testRun.AddScenario("My Scenario")
                .Given("my condition", s => { System.Threading.Thread.Sleep(5); })
                .When("my action", s => { System.Threading.Thread.Sleep(5); throw new SkipStepException("Test"); })
                .Then("my expectation", s => { System.Threading.Thread.Sleep(5); });
            try
            {
                state.Scenario.Run();
            }
            catch (Exception ex)
            {
                if (!(ex.InnerException is SkipStepException))
                    throw;
            }
        }
        internal void a_scenario_with_all_skipped_steps_is_run(IStep step)
        {
            var testRun = new TestRun(new CoreFactory());
            state.Scenario = testRun.AddScenario("My Scenario")
                .Given("my condition", s => {
                    System.Threading.Thread.Sleep(5); throw new SkipStepException("Not Implemented");
                })
                .When("my action", s => { System.Threading.Thread.Sleep(5); throw new SkipStepException("Not Implemented"); })
                .Then("my expectation", s => { System.Threading.Thread.Sleep(5); throw new SkipStepException("Not Implemented"); });
            try
            {
                state.Scenario.Run();
            }
            catch (Exception ex)
            {
                if (!(ex.InnerException is SkipStepException))
                    throw;
            }
        }
        internal async Task a_scenario_is_skipped_using_the_SkipAsync_method_and_all_methods_call_ReturnIfPreviousError(IStep step)
        {
            var testRun = new TestRun(new CoreFactory());
            state.Scenario = testRun.AddScenario("My Scenario")
                .GivenAsync("my condition", s => { return Task.Run(() => { s.ReturnIfPreviousError(); System.Threading.Thread.Sleep(5); }); })
                .WhenAsync("my action", s => { return Task.Run(() => { s.ReturnIfPreviousError(); System.Threading.Thread.Sleep(5); }); })
                .ThenAsync("my expectation", s => { return Task.Run(() => { s.ReturnIfPreviousError(); System.Threading.Thread.Sleep(5); }); });
            try
            {
                await state.Scenario.SkipAsync("Not Started");
            }
            catch (Exception ex)
            {
                if (!(ex.InnerException is SkipStepException))
                    throw;
            }
        }
        internal void a_scenario_is_skipped_using_the_Skip_method_and_all_methods_call_ReturnIfPreviousError(IStep step)
        {
            var testRun = new TestRun(new CoreFactory());
            state.Scenario = testRun.AddScenario("My Scenario")
                .Given("my condition", s => { s.ReturnIfPreviousError(); System.Threading.Thread.Sleep(5); })
                .When("my action", s => { s.ReturnIfPreviousError(); System.Threading.Thread.Sleep(5); })
                .Then("my expectation", s => { s.ReturnIfPreviousError(); System.Threading.Thread.Sleep(5); });
            try
            {
                state.Scenario.Skip("Not Started");
            }
            catch (Exception ex)
            {
                if (!(ex.InnerException is SkipStepException))
                    throw;
            }
        }
        internal void a_scenario_with_no_steps_is_run(IStep step)
        {
            var testRun = new TestRun(new CoreFactory());
            state.Scenario = testRun.AddScenario("My Empty Scenario");
            state.Scenario.Run();
        }
        internal async Task a_scenario_with_all_passing_steps_is_run_async(IStep step)
        {
            var testRun = new TestRun(new CoreFactory());
            state.Scenario = testRun.AddScenario("My Scenario")
                .GivenAsync("my condition", s => { return Task.Run(() => { System.Threading.Thread.Sleep(5); }); })
                .WhenAsync("my action", s => { return Task.Run(() => { System.Threading.Thread.Sleep(5); }); })
                .ThenAsync("my validation", s => { return Task.Run(() => { System.Threading.Thread.Sleep(5); }); });
            await state.Scenario.RunAsync();
        }
        internal void a_scenario_with_all_passing_steps_is_run(IStep step)
        {
            var testRun = new TestRun(new CoreFactory());
            state.Scenario = testRun.AddScenario("My Scenario")
                .Given("my condition", s => { System.Threading.Thread.Sleep(5); })
                .When("my action", s => { System.Threading.Thread.Sleep(5); })
                .Then("my expectation", s => { System.Threading.Thread.Sleep(5); });
            state.Scenario.Run();
        }
        internal async Task the_parent_scenario_is_run_async_and_the_exception_caught(IStep obj)
        {
            try
            {
                await state.Scenario.RunAsync();
            }
            catch (Exception ex)
            {
                state.CaughtException = ex;
            }
        }
        internal void the_parent_scenario_is_run_and_the_exception_caught(IStep obj)
        {
            try
            {
                state.Scenario.Run();
            }
            catch (Exception ex)
            {
                state.CaughtException = ex;
            }
        }
        public void the_current_time_is_captured_as_CapturedEndTime(IStep step)
        {
            state.CapturedEndTime = DateTime.Now;
        }

    }
    [StepLibrary]
    public class ThenSteps : CommonThenSteps
    {
        StepsState state;
        public ThenSteps(StepsState state)
            : base(state)
        {
            this.state = state;
        }
        internal void the_scenario_time_should_match_the_summation_of_the_durations_of_all_child_steps(IStep step)
        {
            TimeSpan time = new TimeSpan();
            state.Scenario.Steps.ForEach(stepTest => {
                var diff = stepTest.EndTime.Subtract(stepTest.StartTime);
                time = time.Add(diff);
            });
            Assert.Equal(time, state.Scenario.Time);
        }
        internal void the_last_step_should_have_a_skipped_outcome(IStep step)
        {
            Assert.Equal(Outcome.Skipped, state.Scenario.Steps[2].Outcome);
        }
        internal void all_steps_after_the_skipped_step_should_be_marked_as_skipped(IStep step)
        {
            foreach (var stepAdded in state.Scenario.Steps)
            {
                Assert.Equal(Outcome.Skipped, stepAdded.Outcome);
            }
        }
        internal void code_in_the_last_step_before_the_ReturnIfPreviousError_line_should_execute(IStep step)
        {
            step.ReplaceNameParameters("ReturnIfPreviousError", state.ReturnIfPreviousError.Quote());
            Assert.True(state.CodeExecutedThatShould);
        }
        internal void code_in_the_last_step_after_the_ReturnIfPreviousError_line_should_not_execute(IStep step)
        {
            step.ReplaceNameParameters("ReturnIfPreviousError", state.ReturnIfPreviousError.Quote());
            Assert.False(state.CodeExecutedThatShouldnt);
        }
        internal void the_last_step_should_be_passed(IStep step)
        {
            Assert.Equal(Outcome.Passed, state.Scenario.Steps[2].Outcome);
        }
        internal void all_other_steps_should_be_marked_as_passed(IStep step)
        {
            Assert.Equal(Outcome.Passed, state.Scenario.Steps[0].Outcome);
            Assert.Equal(Outcome.Passed, state.Scenario.Steps[2].Outcome);
        }
        internal void the_scenario_start_time_should_match_the_start_time_of_the_first_step(IStep step)
        {
            Assert.Equal(state.Scenario.Steps[0].StartTime, state.Scenario.StartTime);
        }
        internal void the_scenario_end_time_should_match_the_end_time_of_the_last_step(IStep step)
        {
            Assert.Equal(state.Scenario.Steps[2].EndTime, state.Scenario.EndTime);
        }
        internal void the_step_exception_type_should_be_ExpectedExceptionType(IStep obj)
        {
            var ex = state.Step.Exception;
            Assert.Equal(state.ExpectedExceptionType, ex.GetType());
        }
        internal void all_scenario_steps_should_be_marked_as_skipped(IStep step)
        {
            foreach (var stepTarget in state.Scenario.Steps)
            {
                Assert.Equal(Outcome.Skipped, stepTarget.Outcome);
            }
        }
        internal void the_scenario_outcome_should_be_ScenarioOutcome(IStep step)
        {
            step.ReplaceNameParameters("ScenarioOutcome", Enum.GetName(typeof(Outcome), state.ScenarioOutcome).Quote());
            Assert.Equal(state.ScenarioOutcome, state.Scenario.Outcome);
        }
        internal void the_end_time_should_be_before_or_equal_Time2(IStep step)
        {
            Assert.True(state.Scenario.EndTime <= state.Time2);
        }
        internal void the_time_should_be_less_than_5_milliseconds(IStep step)
        {
            Assert.True(state.Scenario.Time.Milliseconds < 5);
        }
        internal void the_end_time_should_match_the_start_time(IStep step)
        {
            Assert.True(state.Scenario.EndTime.Equals(state.Scenario.StartTime));
        }
        internal void the_start_time_should_be_after_or_equal_to_Time1(IStep step)
        {
            Assert.True(state.Scenario.StartTime >= state.Time1);
        }
        internal void the_step_start_time_should_be_after_the_CapturedStartTime_and_before_the_step_end_time(IStep step)
        {
            Assert.True(state.Step.StartTime >= state.CapturedStartTime && state.Step.StartTime <= state.CapturedEndTime);
        }
        internal void the_step_end_time_should_be_before_the_CapturedEndTime_and_after_the_step_start_time(IStep step)
        {
            Assert.True(state.Step.EndTime <= state.CapturedEndTime && state.Step.EndTime >= state.CapturedStartTime);
        }
        internal void the_exception_should_have_the_message_ExceptionMessage(IStep obj)
        {
            Assert.Equal(state.ExceptionMessage, state.CaughtException.Message);
        }
        internal void the_first_step_should_be_skipped(IStep step)
        {
            Assert.Equal(Outcome.Skipped, state.Scenario.Steps[0].Outcome);
        }

        internal void all_scenario_steps_should_have_a_reason_of_SkipReason(IStep step)
        {
            foreach (var stepTarget in state.Scenario.Steps)
            {
                Assert.Equal(state.SkipReason, stepTarget.Reason);
            }
        }

    }
}
