﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace xBDD.Test.Features.RunTests
{
    public class RunAScenario
    {
        [ScenarioFact]
        public void RunSync()
        {
            var s = new Steps();
            s.ExpectedOutcome = Outcome.Passed;
            xBDD.CurrentRun.AddScenario()
                .When(s.a_scenario_with_all_passing_steps_is_run)
                .Then(s.the_scenario_outcome_should_be_ExpectedOutcome)
                .And(s.the_start_time_should_match_the_start_time_of_the_first_step)
                .And(s.the_end_time_should_match_the_end_time_of_the_last_step)
                .And(s.the_time_should_match_the_summation_of_the_durations_of_all_child_steps)
                .Run();
        }
        [ScenarioFact]
        public void RunNoSteps()
        {
            var s = new Steps();
            s.ExpectedOutcome = Outcome.Passed;
            s.Time1 = DateTime.Now;
            xBDD.CurrentRun.AddScenario()
                .When(s.a_scenario_with_no_steps_is_run)
                .And("then_Time2_is_set", step => { s.Time2 = DateTime.Now; })
                .Then(s.the_scenario_outcome_should_be_ExpectedOutcome)
                .And(s.the_start_time_should_be_after_or_equal_to_Time1)
                .And(s.the_end_time_should_match_the_start_time)
                .And(s.the_end_time_should_be_before_or_equal_Time2)
                .And(s.the_time_should_be_less_than_5_milliseconds)
                .Run();
        }
        [ScenarioFact]
        public void RunAsync()
        {
            var s = new Steps();
            xBDD.CurrentRun.AddScenario().Skip();
        }
        [ScenarioFact]
        public void RunSyncWithAsyncStep()
        {
            var s = new Steps();
            s.ExceptionMessage = "The child step, 'When my test async step' is an asynchronous step and you are trying to run the scenario synchronously.";
            xBDD.CurrentRun.AddScenario()
                .Given(s.a_scenario)
                .And(s.an_async_step_that_does_not_thwow_an_exception)
                .When(s.the_parent_scenario_is_run_and_the_exception_caught)
                .Then(s.the_exception_should_have_the_message_ExceptionMessage)
                .Run();
        }
        [ScenarioFact]
        public void Skip()
        {
            var s = new Steps();
            s.ExpectedOutcome = Outcome.Skipped;
            xBDD.CurrentRun.AddScenario()
                .When(s.a_scenario_is_skipped_using_the_Skip_method_and_all_methods_call_ReturnIfPreviousError)
                .Then(s.the_scenario_outcome_should_be_ExpectedOutcome)
                .And(s.the_start_time_should_match_the_start_time_of_the_first_step)
                .And(s.the_end_time_should_match_the_end_time_of_the_last_step)
                .And(s.the_time_should_match_the_summation_of_the_durations_of_all_child_steps)
                .And(s.all_steps_should_be_marked_as_skipped)
                .Run();
        }
        [ScenarioFact]
        public async Task SkipAsync()
        {
            var s = new Steps();
            s.ExpectedOutcome = Outcome.Skipped;
            await xBDD.CurrentRun.AddScenario()
                .WhenAsync(s.a_scenario_is_skipped_using_the_SkipAsync_method_and_all_methods_call_ReturnIfPreviousError)
                .Then(s.the_scenario_outcome_should_be_ExpectedOutcome)
                .And(s.the_start_time_should_match_the_start_time_of_the_first_step)
                .And(s.the_end_time_should_match_the_end_time_of_the_last_step)
                .And(s.the_time_should_match_the_summation_of_the_durations_of_all_child_steps)
                .And(s.all_steps_should_be_marked_as_skipped)
                .RunAsync();
        }
        [ScenarioFact]
        public void WithAllPassingSteps()
        {
            var s = new Steps();
            s.ExpectedOutcome = Outcome.Passed;
            xBDD.CurrentRun.AddScenario()
                .When(s.a_scenario_with_all_passing_steps_is_run)
                .Then(s.the_scenario_outcome_should_be_ExpectedOutcome)
                .And(s.the_start_time_should_match_the_start_time_of_the_first_step)
                .And(s.the_end_time_should_match_the_end_time_of_the_last_step)
                .And(s.the_time_should_match_the_summation_of_the_durations_of_all_child_steps)
                .Run();
        }

        [ScenarioFact]
        public void WithAllSkippedSteps()
        {
            var s = new Steps();
            s.ExpectedOutcome = Outcome.Skipped;
            xBDD.CurrentRun.AddScenario()
                .When(s.a_scenario_with_all_skipped_steps_is_run)
                .Then(s.the_scenario_outcome_should_be_ExpectedOutcome)
                .And(s.the_start_time_should_match_the_start_time_of_the_first_step)
                .And(s.the_end_time_should_match_the_end_time_of_the_last_step)
                .And(s.the_time_should_match_the_summation_of_the_durations_of_all_child_steps)
                .And(s.all_steps_after_the_skipped_step_should_be_marked_as_skipped)
                .Run();
        }
        [ScenarioFact]
        public void WithOneMiddleSkippedStepAndTheRestPassing()
        {
            var s = new Steps();
            s.ExpectedOutcome = Outcome.Skipped;
            xBDD.CurrentRun.AddScenario()
                .When(s.a_scenario_with_one_skipped_steps_is_run)
                .Then(s.the_scenario_outcome_should_be_ExpectedOutcome)
                .And(s.the_start_time_should_match_the_start_time_of_the_first_step)
                .And(s.the_end_time_should_match_the_end_time_of_the_last_step)
                .And(s.the_time_should_match_the_summation_of_the_durations_of_all_child_steps)
                .And(s.all_other_steps_should_be_marked_as_passed)
                .Run();
        }
        [ScenarioFact]
        public void WithOneMiddleNotImplementedStepAndTheRestPassing()
        {
            var s = new Steps();
            s.ExpectedOutcome = Outcome.Skipped;
            xBDD.CurrentRun.AddScenario()
                .When(s.a_scenario_with_one_not_implemented_steps_is_run)
                .Then(s.the_scenario_outcome_should_be_ExpectedOutcome)
                .And(s.the_start_time_should_match_the_start_time_of_the_first_step)
                .And(s.the_end_time_should_match_the_end_time_of_the_last_step)
                .And(s.the_time_should_match_the_summation_of_the_durations_of_all_child_steps)
                .And(s.all_other_steps_should_be_marked_as_passed)
                .Run();
        }
        [ScenarioFact]
        public void WithOneMiddleFailingStepAndTheRestPassing()
        {
            var s = new Steps();
            s.ExpectedOutcome = Outcome.Failed;
            xBDD.CurrentRun.AddScenario()
                .When(s.a_scenario_with_one_middle_failing_steps_is_run)
                .Then(s.the_scenario_outcome_should_be_ExpectedOutcome)
                .And(s.the_start_time_should_match_the_start_time_of_the_first_step)
                .And(s.the_end_time_should_match_the_end_time_of_the_last_step)
                .And(s.the_time_should_match_the_summation_of_the_durations_of_all_child_steps)
                .And(s.all_other_steps_should_be_marked_as_passed)
                .Run();
        }
        [ScenarioFact]
        public void WithOneFailingStepAndPreceedingPassingSteps()
        {
            var s = new Steps();
            s.ExpectedOutcome = Outcome.Failed;
            xBDD.CurrentRun.AddScenario()
                .When(s.a_scenario_with_the_first_step_skipped_and_the_middle_step_failing_is_run)
                .Then(s.the_scenario_outcome_should_be_ExpectedOutcome)
                .And(s.the_start_time_should_match_the_start_time_of_the_first_step)
                .And(s.the_end_time_should_match_the_end_time_of_the_last_step)
                .And(s.the_time_should_match_the_summation_of_the_durations_of_all_child_steps)
                .And(s.the_first_step_should_be_skipped)
                .And(s.the_last_step_should_be_passed)
                .Run();
        }
    }
}
