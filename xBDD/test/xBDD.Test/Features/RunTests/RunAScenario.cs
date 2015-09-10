using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xBDD.xUnit;
using Xunit.Abstractions;

namespace xBDD.Test.Features.RunTests
{
    public class RunAScenario
    {
        private readonly IOutputWriter outputWriter;

        public RunAScenario(ITestOutputHelper output)
        {
            outputWriter = new OutputWriter(output);
        }

        [ScenarioFact]
        public void RunSync()
        {
            var s = new Steps();
            s.State.ExpectedOutcome = Outcome.Passed;
            xBDD.CurrentRun.AddScenario()
                .SetOutputWriter(outputWriter)
                .When(s.When.a_scenario_with_all_passing_steps_is_run)
                .Then(s.Then.the_scenario_outcome_should_be_ExpectedOutcome)
                .And(s.Then.the_start_time_should_match_the_start_time_of_the_first_step)
                .And(s.Then.the_end_time_should_match_the_end_time_of_the_last_step)
                .And(s.Then.the_time_should_match_the_summation_of_the_durations_of_all_child_steps)
                .Run();
        }
        [ScenarioFact]
        public void RunNoSteps()
        {
            var s = new Steps();
            s.State.ExpectedOutcome = Outcome.Passed;
            s.State.Time1 = DateTime.Now;
            xBDD.CurrentRun.AddScenario()
                .SetOutputWriter(outputWriter)
                .When(s.When.a_scenario_with_no_steps_is_run)
                .And("then Time2 is set", step => { s.State.Time2 = DateTime.Now; })
                .Then(s.Then.the_scenario_outcome_should_be_ExpectedOutcome)
                .And(s.Then.the_start_time_should_be_after_or_equal_to_Time1)
                .And(s.Then.the_end_time_should_match_the_start_time)
                .And(s.Then.the_end_time_should_be_before_or_equal_Time2)
                .And(s.Then.the_time_should_be_less_than_5_milliseconds)
                .Run();
        }
        [ScenarioFact]
        public async Task RunAsync()
        {
            var s = new Steps();
            s.State.ExpectedOutcome = Outcome.Passed;
            var scenario = xBDD.CurrentRun.AddScenario()
                .SetOutputWriter(outputWriter)
                .WhenAsync(s.When.a_scenario_with_all_passing_steps_is_run_async)
                .Then(s.Then.the_scenario_outcome_should_be_ExpectedOutcome)
                .And(s.Then.the_start_time_should_match_the_start_time_of_the_first_step)
                .And(s.Then.the_end_time_should_match_the_end_time_of_the_last_step)
                .And(s.Then.the_time_should_match_the_summation_of_the_durations_of_all_child_steps);
            await scenario.RunAsync();
        }
        [ScenarioFact]
        public void RunSyncWithAsyncStep()
        {
            var s = new Steps();
            s.State.ExceptionMessage = "The child step, 'When my test async step' is an asynchronous step and you are trying to run the scenario synchronously.";
            xBDD.CurrentRun.AddScenario()
                .SetOutputWriter(outputWriter)
                .Given(s.Given.a_scenario)
                .And(s.Given.an_async_step_that_does_not_thwow_an_exception)
                .When(s.When.the_parent_scenario_is_run_and_the_exception_caught)
                .Then(s.Then.the_exception_should_have_the_message_ExceptionMessage)
                .Run();
        }
        [ScenarioFact]
        public void Skip()
        {
            var s = new Steps();
            s.State.ExpectedOutcome = Outcome.Skipped;
            xBDD.CurrentRun.AddScenario()
                .SetOutputWriter(outputWriter)
                .When(s.When.a_scenario_is_skipped_using_the_Skip_method_and_all_methods_call_ReturnIfPreviousError)
                .Then(s.Then.the_scenario_outcome_should_be_ExpectedOutcome)
                .And(s.Then.the_start_time_should_match_the_start_time_of_the_first_step)
                .And(s.Then.the_end_time_should_match_the_end_time_of_the_last_step)
                .And(s.Then.the_time_should_match_the_summation_of_the_durations_of_all_child_steps)
                .And(s.Then.all_steps_should_be_marked_as_skipped)
                .Run();
        }
        [ScenarioFact]
        public async Task SkipAsync()
        {
            var s = new Steps();
            s.State.ExpectedOutcome = Outcome.Skipped;
            await xBDD.CurrentRun.AddScenario()
                .SetOutputWriter(outputWriter)
                .WhenAsync(s.When.a_scenario_is_skipped_using_the_SkipAsync_method_and_all_methods_call_ReturnIfPreviousError)
                .Then(s.Then.the_scenario_outcome_should_be_ExpectedOutcome)
                .And(s.Then.the_start_time_should_match_the_start_time_of_the_first_step)
                .And(s.Then.the_end_time_should_match_the_end_time_of_the_last_step)
                .And(s.Then.the_time_should_match_the_summation_of_the_durations_of_all_child_steps)
                .And(s.Then.all_steps_should_be_marked_as_skipped)
                .RunAsync();
        }
        [ScenarioFact]
        public void WithAllPassingSteps()
        {
            var s = new Steps();
            s.State.ExpectedOutcome = Outcome.Passed;
            xBDD.CurrentRun.AddScenario()
                .SetOutputWriter(outputWriter)
                .When(s.When.a_scenario_with_all_passing_steps_is_run)
                .Then(s.Then.the_scenario_outcome_should_be_ExpectedOutcome)
                .And(s.Then.the_start_time_should_match_the_start_time_of_the_first_step)
                .And(s.Then.the_end_time_should_match_the_end_time_of_the_last_step)
                .And(s.Then.the_time_should_match_the_summation_of_the_durations_of_all_child_steps)
                .Run();
        }

        [ScenarioFact]
        public void WithAllSkippedSteps()
        {
            var s = new Steps();
            s.State.ExpectedOutcome = Outcome.Skipped;
            xBDD.CurrentRun.AddScenario()
                .SetOutputWriter(outputWriter)
                .When(s.When.a_scenario_with_all_skipped_steps_is_run)
                .Then(s.Then.the_scenario_outcome_should_be_ExpectedOutcome)
                .And(s.Then.the_start_time_should_match_the_start_time_of_the_first_step)
                .And(s.Then.the_end_time_should_match_the_end_time_of_the_last_step)
                .And(s.Then.the_time_should_match_the_summation_of_the_durations_of_all_child_steps)
                .And(s.Then.all_steps_after_the_skipped_step_should_be_marked_as_skipped)
                .Run();
        }
        [ScenarioFact]
        public void WithOneMiddleSkippedStepAndTheRestPassing()
        {
            var s = new Steps();
            s.State.ExpectedOutcome = Outcome.Skipped;
            xBDD.CurrentRun.AddScenario()
                .SetOutputWriter(outputWriter)
                .When(s.When.a_scenario_with_one_skipped_steps_is_run)
                .Then(s.Then.the_scenario_outcome_should_be_ExpectedOutcome)
                .And(s.Then.the_start_time_should_match_the_start_time_of_the_first_step)
                .And(s.Then.the_end_time_should_match_the_end_time_of_the_last_step)
                .And(s.Then.the_time_should_match_the_summation_of_the_durations_of_all_child_steps)
                .And(s.Then.all_other_steps_should_be_marked_as_passed)
                .Run();
        }
        [ScenarioFact]
        public void WithOneMiddleNotImplementedStepAndTheRestPassing()
        {
            var s = new Steps();
            s.State.ExpectedOutcome = Outcome.Skipped;
            xBDD.CurrentRun.AddScenario()
                .SetOutputWriter(outputWriter)
                .When(s.When.a_scenario_with_one_not_implemented_steps_is_run)
                .Then(s.Then.the_scenario_outcome_should_be_ExpectedOutcome)
                .And(s.Then.the_start_time_should_match_the_start_time_of_the_first_step)
                .And(s.Then.the_end_time_should_match_the_end_time_of_the_last_step)
                .And(s.Then.the_time_should_match_the_summation_of_the_durations_of_all_child_steps)
                .And(s.Then.all_other_steps_should_be_marked_as_passed)
                .Run();
        }
        [ScenarioFact]
        public void WithOneMiddleFailingStepAndTheRestPassing()
        {
            var s = new Steps();
            s.State.ExpectedOutcome = Outcome.Failed;
            xBDD.CurrentRun.AddScenario()
                .SetOutputWriter(outputWriter)
                .When(s.When.a_scenario_with_one_middle_failing_steps_is_run)
                .Then(s.Then.the_scenario_outcome_should_be_ExpectedOutcome)
                .And(s.Then.the_start_time_should_match_the_start_time_of_the_first_step)
                .And(s.Then.the_end_time_should_match_the_end_time_of_the_last_step)
                .And(s.Then.the_time_should_match_the_summation_of_the_durations_of_all_child_steps)
                .And(s.Then.all_other_steps_should_be_marked_as_passed)
                .Run();
        }
        [ScenarioFact]
        public void WithOneFailingStepAndPreceedingPassingSteps()
        {
            var s = new Steps();
            s.State.ExpectedOutcome = Outcome.Failed;
            xBDD.CurrentRun.AddScenario()
                .SetOutputWriter(outputWriter)
                .When(s.When.a_scenario_with_the_first_step_skipped_and_the_middle_step_failing_is_run)
                .Then(s.Then.the_scenario_outcome_should_be_ExpectedOutcome)
                .And(s.Then.the_start_time_should_match_the_start_time_of_the_first_step)
                .And(s.Then.the_end_time_should_match_the_end_time_of_the_last_step)
                .And(s.Then.the_time_should_match_the_summation_of_the_durations_of_all_child_steps)
                .And(s.Then.the_first_step_should_be_skipped)
                .And(s.Then.the_last_step_should_be_passed)
                .Run();
        }
        [ScenarioFact]
        public void WriteScenarioToOutput()
        {
            var s = new Steps();
            s.State.ScenarioName = "My Scenario";
            s.State.StepName = "my step";
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("My Scenario");
            sb.AppendLine("    Given my step");
            s.State.Output = sb.ToString();
            xBDD.CurrentRun.AddScenario()
                .SetOutputWriter(outputWriter)
                .Given(s.Given.a_test_run)
                .Given(s.Given.a_scenario_with_the_name_ScenarioName)
                .And(s.Given.a_given_step_with_the_name_StepName)
                .And(s.Given.the_scenario_is_set_to_write_its_output)
                .When(s.When.the_scenario_is_run)
                .Then(s.Then.the_scenario_should_write_the_following_output)
                .Run();
        }
        [ScenarioFact]
        public void WriteScenarioWithMultilineParamterToOutput()
        {
            var s = new Steps();
            s.State.ScenarioName = "My Scenario";
            s.State.StepName = "my step";
            StringBuilder mp = new StringBuilder();
            mp.AppendLine("That does this");
            mp.AppendLine("Then does this");
            s.State.MultilineParameter = mp.ToString();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("My Scenario");
            sb.AppendLine("    Given my step");
            sb.AppendLine("        That does this");
            sb.AppendLine("        Then does this");
            s.State.Output = sb.ToString();
            xBDD.CurrentRun.AddScenario()
                .SetOutputWriter(outputWriter)
                .Given(s.Given.a_test_run)
                .Given(s.Given.a_scenario_with_the_name_ScenarioName)
                .And(s.Given.a_given_step_with_the_name_StepName)
                .And(s.Given.the_step_has_a_multiline_parameter_of)
                .And(s.Given.the_scenario_is_set_to_write_its_output)
                .When(s.When.the_scenario_is_run)
                .Then(s.Then.the_scenario_should_write_the_following_output)
                .Run();
        }
    }
}
