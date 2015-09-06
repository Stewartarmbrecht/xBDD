using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using xBDD.Core;
using Xunit;

namespace xBDD.Test.Features.RunTests
{
    [StepLibrary]
    public class Steps : CommonSteps
    {
        private const string ReturnIfPreviousError = "step.ReturnIfPreviousError();";

        public Outcome ExpectedOutcome { get; internal set; }
        public IScenario Scenario { get; set; }
        public IStep Step { get; set; }
        public bool CodeExecutedThatShould { get; private set; }
        public bool CodeExecutedThatShouldnt { get; private set; }
        public Exception ThrownException { get; private set; }
        public DateTime Time1 { get; internal set; }
        public DateTime Time2 { get; internal set; }
        public DateTime CapturedStartTime { get; internal set; }
        public DateTime CapturedEndTime { get; internal set; }
        public string ExpectedReason { get; internal set; }
        public Exception ExpectedException { get; internal set; }
        public string ExceptionMessage { get; internal set; }

        public void the_current_time_is_captured_as_CapturedEndTime(IStep step)
        {
            CapturedEndTime = DateTime.Now;
        }

        public void the_parent_scenario_is_run(IStep step)
        {
            Scenario.Run();
        }
        public async Task the_parent_scenario_is_run_async(IStep step)
        {
            await Scenario.RunAsync();
        }

        public void the_current_time_is_captured_as_CapturedStartTime(IStep step)
        {
            CapturedStartTime = DateTime.Now;
        }

        public void a_scenario(IStep step)
        {
            var coreFactory = new CoreFactory();
            var testRun = new TestRun(coreFactory);
            Scenario = testRun.AddScenario();
        }

        public void a_step_that_does_not_thwow_an_exception(IStep step)
        {
            Scenario.When("my test step", stepTarget => { return; });
            Step = Scenario.Steps[0];
        }

        internal void an_async_step_that_does_not_thwow_an_exception(IStep step)
        {
            Scenario.WhenAsync("my test async step", stepTarget => { return Task.Run(() => { return; }); });
            Step = Scenario.Steps[0];
        }

        internal void the_exception_should_have_the_message_ExceptionMessage(IStep obj)
        {
            Assert.Equal(ExceptionMessage, CaughtException.Message);
        }

        internal void the_parent_scenario_is_run_and_the_exception_caught(IStep obj)
        {
            try
            {
                Scenario.Run();
            }
            catch(Exception ex)
            {
                CaughtException = ex;
            }
        }

        internal void the_step_outcome_should_be_ExpectedOutcome(IStep step)
        {
            Assert.Equal(ExpectedOutcome, Step.Outcome);
        }

        internal void the_end_time_should_be_before_the_CapturedEndTime_and_after_the_start_time(IStep step)
        {
            Assert.True(Step.EndTime <= CapturedEndTime && Step.EndTime >= CapturedStartTime);
        }

        internal void the_step_exception_should_be_ExpectedException(IStep step)
        {
            Assert.Equal(ExpectedException, Step.Exception);
        }

        internal void the_step_reason_should_be_ExpectedReason(IStep step)
        {
            Assert.Equal(ExpectedReason, Step.Reason);
        }

        internal void the_start_time_should_be_after_the_CapturedStartTime_and_before_the_step_end_time(IStep step)
        {
            Assert.True(Step.StartTime >= CapturedStartTime && Step.StartTime <= CapturedEndTime);
        }

        internal void a_scenario_with_all_passing_steps_is_run(IStep step)
        {
            var testRun = new TestRun(new CoreFactory());
            Scenario = testRun.AddScenario("My Scenario")
                .Given("my condition", s => { System.Threading.Thread.Sleep(5); })
                .When("my action", s => { System.Threading.Thread.Sleep(5); })
                .Then("my expectation", s => { System.Threading.Thread.Sleep(5); });
            Scenario.Run();
        }

        internal void a_scenario_with_no_steps_is_run(IStep step)
        {
            var testRun = new TestRun(new CoreFactory());
            Scenario = testRun.AddScenario("My Empty Scenario");
            Scenario.Run();
        }

        internal void the_end_time_should_be_before_or_equal_Time2(IStep step)
        {
            Assert.True(Scenario.EndTime <= Time2);
        }

        internal void the_time_should_be_less_than_5_milliseconds(IStep step)
        {
            Assert.True(Scenario.Time.Milliseconds < 5);
        }

        internal void the_end_time_should_match_the_start_time(IStep step)
        {
            Assert.True(Scenario.EndTime.Equals(Scenario.StartTime));
        }

        internal void the_start_time_should_be_after_or_equal_to_Time1(IStep step)
        {
            Assert.True(Scenario.StartTime >= Time1);
        }

        internal void the_scenario_outcome_should_be_ExpectedOutcome(IStep step)
        {
            step.SetNameWithReplacement("ExpectedOutcome", Enum.GetName(typeof(Outcome), ExpectedOutcome).Quote());
            Assert.Equal(ExpectedOutcome, Scenario.Outcome);
        }

        internal void all_steps_should_be_marked_as_skipped(IStep step)
        {
            foreach(var stepTarget in Scenario.Steps)
            {
                Assert.Equal(Outcome.Skipped, stepTarget.Outcome);
            }
        }

        internal void a_scenario_is_skipped_using_the_Skip_method_and_all_methods_call_ReturnIfPreviousError(IStep step)
        {
            var testRun = new TestRun(new CoreFactory());
            Scenario = testRun.AddScenario("My Scenario")
                .Given("my condition", s => { s.ReturnIfPreviousError(); System.Threading.Thread.Sleep(5); })
                .When("my action", s => { s.ReturnIfPreviousError(); System.Threading.Thread.Sleep(5); })
                .Then("my expectation", s => { s.ReturnIfPreviousError(); System.Threading.Thread.Sleep(5); });
            try
            {
                Scenario.Skip();
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
            Scenario = testRun.AddScenario("My Scenario")
                .GivenAsync("my condition", s => { return Task.Run(() => { s.ReturnIfPreviousError(); System.Threading.Thread.Sleep(5); }); })
                .WhenAsync("my action", s => { return Task.Run(() => { s.ReturnIfPreviousError(); System.Threading.Thread.Sleep(5); }); })
                .ThenAsync("my expectation", s => { return Task.Run(() => { s.ReturnIfPreviousError(); System.Threading.Thread.Sleep(5); }); });
            try
            {
                await Scenario.SkipAsync();
            }
            catch (Exception ex)
            {
                if (!(ex.InnerException is SkipStepException))
                    throw;
            }
        }

        internal void the_start_time_should_match_the_start_time_of_the_first_step(IStep step)
        {
            Assert.Equal(Scenario.Steps[0].StartTime, Scenario.StartTime);
        }

        internal void the_end_time_should_match_the_end_time_of_the_last_step(IStep step)
        {
            Assert.Equal(Scenario.Steps[2].EndTime, Scenario.EndTime);
        }

        internal void a_scenario_with_all_skipped_steps_is_run(IStep step)
        {
            var testRun = new TestRun(new CoreFactory());
            Scenario = testRun.AddScenario("My Scenario")
                .Given("my condition", s => {
                    System.Threading.Thread.Sleep(5); throw new SkipStepException("Not Implemented"); })
                .When("my action", s => { System.Threading.Thread.Sleep(5); throw new SkipStepException("Not Implemented"); })
                .Then("my expectation", s => { System.Threading.Thread.Sleep(5); throw new SkipStepException("Not Implemented"); });
            try
            {
                Scenario.Run();
            }
            catch(Exception ex)
            {
                if (!(ex.InnerException is SkipStepException))
                    throw;
            }
        }

        internal void all_other_steps_should_be_marked_as_passed(IStep step)
        {
            Assert.Equal(Outcome.Passed, Scenario.Steps[0].Outcome);
            Assert.Equal(Outcome.Passed, Scenario.Steps[2].Outcome);
        }

        internal void a_scenario_with_one_skipped_steps_is_run(IStep step)
        {
            var testRun = new TestRun(new CoreFactory());
            Scenario = testRun.AddScenario("My Scenario")
                .Given("my condition", s => { System.Threading.Thread.Sleep(5); })
                .When("my action", s => { System.Threading.Thread.Sleep(5); throw new SkipStepException("Test"); })
                .Then("my expectation", s => { System.Threading.Thread.Sleep(5); });
            try
            {
                Scenario.Run();
            }
            catch(Exception ex)
            {
                if (!(ex.InnerException is SkipStepException))
                    throw;
            }
        }

        internal void a_scenario_with_one_not_implemented_steps_is_run(IStep step)
        {
            var testRun = new TestRun(new CoreFactory());
            Scenario = testRun.AddScenario("My Scenario")
                .Given("my condition", s => { System.Threading.Thread.Sleep(5); })
                .When("my action", s => { System.Threading.Thread.Sleep(5); throw new NotImplementedException(); })
                .Then("my expectation", s => { System.Threading.Thread.Sleep(5); });
            try
            {
                Scenario.Run();
            }
            catch (Exception ex)
            {
                if (!(ex.InnerException is NotImplementedException))
                    throw;
            }
        }

        internal void a_scenario_with_one_middle_failing_steps_is_run(IStep step)
        {
            var testRun = new TestRun(new CoreFactory());
            Scenario = testRun.AddScenario("My Scenario")
                .Given("my condition", s => { System.Threading.Thread.Sleep(5); })
                .When("my action", s => { System.Threading.Thread.Sleep(5); throw new Exception("My Error"); })
                .Then("my expectation", s => { System.Threading.Thread.Sleep(5); });
            try
            {
                Scenario.Run();
            }
            catch (Exception ex)
            {
                if (!(ex.InnerException is Exception) && !(ex.InnerException.Message != "My Error"))
                    throw;
            }
        }

        internal void the_last_step_should_be_passed(IStep step)
        {
            Assert.Equal(Outcome.Passed, Scenario.Steps[2].Outcome);
        }

        internal void the_first_step_should_be_skipped(IStep step)
        {
            Assert.Equal(Outcome.Skipped, Scenario.Steps[0].Outcome);
        }

        internal void a_scenario_with_the_first_step_skipped_and_the_middle_step_failing_is_run(IStep step)
        {
            var testRun = new TestRun(new CoreFactory());
            Scenario = testRun.AddScenario("My Scenario")
                .Given("my condition", s => { System.Threading.Thread.Sleep(5); throw new SkipStepException("Not Implemented"); })
                .When("my action", s => { System.Threading.Thread.Sleep(5); throw new Exception("My Error"); })
                .Then("my expectation", s => { System.Threading.Thread.Sleep(5); });
            try
            {
                Scenario.Run();
            }
            catch (Exception ex)
            {
                if (!(ex.InnerException is SkipStepException) && !(ex.InnerException is Exception) && !(ex.InnerException.Message == "My Error"))
                    throw;
            }
        }

        internal void the_last_step_should_have_a_skipped_outcome(IStep step)
        {
            Assert.Equal(Outcome.Skipped, Scenario.Steps[2].Outcome);
        }

        internal void code_in_the_last_step_before_the_ReturnIfPreviousError_line_should_execute(IStep step)
        {
            step.SetNameWithReplacement("ReturnIfPreviousError", ReturnIfPreviousError.Quote());
            Assert.True(CodeExecutedThatShould);
        }

        internal void code_in_the_last_step_after_the_ReturnIfPreviousError_line_should_not_execute(IStep step)
        {
            step.SetNameWithReplacement("ReturnIfPreviousError", ReturnIfPreviousError.Quote());
            Assert.False(CodeExecutedThatShouldnt);
        }

        internal void the_scenario_is_run(IStep step)
        {
            try
            {
                Scenario.Run();
            }
            catch(Exception ex)
            {
                ThrownException = ex;
            }
        }

        internal void the_last_step_includes_ReturnIfPreviousError_line(IStep step)
        {
            step.SetNameWithReplacement("ReturnIfPreviousError", ReturnIfPreviousError.Quote());
        }

        internal void a_scenario_with_one_skipped_step(IStep step)
        {
            var testRun = new TestRun(new CoreFactory());
            Scenario = testRun.AddScenario("My Scenario")
                .Given("my condition", s => { System.Threading.Thread.Sleep(5); })
                .When("my action", s => { System.Threading.Thread.Sleep(5); throw new SkipStepException("Test"); })
                .Then("my expectation", s => {
                    CodeExecutedThatShould = true;
                    s.ReturnIfPreviousError();
                    CodeExecutedThatShouldnt = true;
                });
        }

        internal void all_steps_after_the_skipped_step_should_be_marked_as_skipped(IStep step)
        {
            foreach(var stepAdded in Scenario.Steps)
            {
                Assert.Equal(Outcome.Skipped, stepAdded.Outcome);
            }
        }

        internal void the_time_should_match_the_summation_of_the_durations_of_all_child_steps(IStep step)
        {
            TimeSpan time = new TimeSpan();
            Scenario.Steps.ForEach(stepTest => {
                var diff = stepTest.EndTime.Subtract(stepTest.StartTime);
                time = time.Add(diff);
            });
            Assert.Equal(time, Scenario.Time);
        }
    }
}
