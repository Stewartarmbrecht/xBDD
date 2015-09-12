using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xBDD.xUnit;
using Xunit;
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
            s.State.ScenarioOutcome = Outcome.Passed;
            xBDD.CurrentRun.AddScenario()
                .SetOutputWriter(outputWriter)
                .Given(s.Given.a_test_run)
                .And(s.Given.a_scenario)
                .And(s.Given.the_scenario_has_three_steps)
                .When(s.When.the_scenario_is_run)
                .Then(s.Then.the_scenario_outcome_should_be_ScenarioOutcome)
                .And(s.Then.the_scenario_start_time_should_match_the_start_time_of_the_first_step)
                .And(s.Then.the_scenario_end_time_should_match_the_end_time_of_the_last_step)
                .And(s.Then.the_scenario_time_should_match_the_summation_of_the_durations_of_all_child_steps)
                .And("step 1 should be passed", st => {
                    Assert.Equal(Outcome.Passed, s.State.Scenario.Steps[0].Outcome);
                })
                .And("step 2 should be passed", st => {
                    Assert.Equal(Outcome.Passed, s.State.Scenario.Steps[1].Outcome);
                })
                .And("step 3 should be passed", st => {
                    Assert.Equal(Outcome.Passed, s.State.Scenario.Steps[2].Outcome);
                })
                .Run();
        }
        [ScenarioFact]
        public void RunNoSteps()
        {
            var s = new Steps();
            s.State.ScenarioOutcome = Outcome.Passed;
            s.State.Time1 = DateTime.Now;
            xBDD.CurrentRun
                .AddScenario()
                .SetOutputWriter(outputWriter)
                .Given(s.Given.a_test_run)
                .And(s.Given.a_scenario)
                .When(s.When.the_scenario_is_run)
                .And("then Time2 is set", step => { s.State.Time2 = DateTime.Now; })
                .Then(s.Then.the_scenario_outcome_should_be_ScenarioOutcome)
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
            s.State.ScenarioOutcome = Outcome.Passed;
            await xBDD.CurrentRun.AddScenario()
                .SetOutputWriter(outputWriter)
                .Given(s.Given.a_test_run)
                .And(s.Given.a_scenario)
                .And(s.Given.the_scenario_has_three_steps)
                .WhenAsync(s.When.the_scenario_is_run_asynchronously)
                .Then(s.Then.the_scenario_outcome_should_be_ScenarioOutcome)
                .And(s.Then.the_scenario_start_time_should_match_the_start_time_of_the_first_step)
                .And(s.Then.the_scenario_end_time_should_match_the_end_time_of_the_last_step)
                .And(s.Then.the_scenario_time_should_match_the_summation_of_the_durations_of_all_child_steps)
                .And("step 1 should be passed", st => {
                    Assert.Equal(Outcome.Passed, s.State.Scenario.Steps[0].Outcome);
                })
                .And("step 2 should be passed", st => {
                    Assert.Equal(Outcome.Passed, s.State.Scenario.Steps[1].Outcome);
                })
                .And("step 3 should be passed", st => {
                    Assert.Equal(Outcome.Passed, s.State.Scenario.Steps[2].Outcome);
                })
                .RunAsync();
        }
        [ScenarioFact]
        public void RunSyncWithAsyncStep()
        {
            var s = new Steps();
            s.State.ScenarioExceptionMessage = "The child step, 'When my test async step' is an asynchronous step and you are trying to run the scenario synchronously.";
            xBDD.CurrentRun.AddScenario()
                .SetOutputWriter(outputWriter)
                .Given(s.Given.a_test_run)
                .And(s.Given.a_scenario)
                .And(s.Given.an_async_step_that_does_not_thwow_an_exception)
                .When(s.When.the_scenario_is_run_and_the_exception_caught)
                .Then(s.Then.the_caught_scenario_exception_should_have_a_message_of_ScenarioExceptionMessage)
                .Run();
        }
        [ScenarioFact]
        public void Skip()
        {
            var s = new Steps();
            s.State.ScenarioOutcome = Outcome.Skipped;
            s.State.ScenarioReason = "Scenario Skipped";
            xBDD.CurrentRun.AddScenario()
                .SetOutputWriter(outputWriter)
                .Given(s.Given.a_test_run)
                .And(s.Given.a_scenario)
                .And(s.Given.the_scenario_has_three_steps)
                .When(s.When.the_scenario_is_skipped_with_reason_of_ScenarioReason)
                .Then(s.Then.the_scenario_outcome_should_be_ScenarioOutcome)
                .And(s.Then.the_scenario_start_time_should_match_the_start_time_of_the_first_step)
                .And(s.Then.the_scenario_end_time_should_match_the_end_time_of_the_last_step)
                .And(s.Then.the_scenario_time_should_match_the_summation_of_the_durations_of_all_child_steps)
                .And(s.Then.all_scenario_steps_should_be_marked_as_skipped)
                .And(s.Then.the_scenario_reason_should_be_ScenarioReason)
                .Run();
        }
        [ScenarioFact]
        public void SkipNullReason()
        {
            var s = new Steps();
            s.State.ScenarioOutcome = Outcome.Failed;
            s.State.ScenarioExceptionType = "ArgumentNullException";
            s.State.ScenarioExceptionMessage = "Value cannot be null.\r\nParameter name: reason";
            xBDD.CurrentRun.AddScenario()
                .SetOutputWriter(outputWriter)
                .Given(s.Given.a_test_run)
                .And(s.Given.a_scenario)
                .And(s.Given.the_scenario_has_three_steps)
                .When(s.When.the_scenario_is_skipped_with_reason_of_ScenarioReason)
                .And(s.Then.the_caught_scenario_exception_should_be_of_type_ScenarioExceptionType)
                .And(s.Then.the_caught_scenario_exception_should_have_a_message_of_ScenarioExceptionMessage)
                .Run();
        }
        [ScenarioFact]
        public async Task SkipAsync()
        {
            var s = new Steps();
            s.State.ScenarioOutcome = Outcome.Skipped;
            s.State.ScenarioReason = "Scenario Skipped";
            await xBDD.CurrentRun.AddScenario()
                .SetOutputWriter(outputWriter)
                .Given(s.Given.a_test_run)
                .And(s.Given.a_scenario)
                .And(s.Given.the_scenario_has_three_steps)
                .WhenAsync(s.When.the_scenario_is_skipped_asynchronously_with_reason_of_ScenarioReason)
                .Then(s.Then.the_scenario_outcome_should_be_ScenarioOutcome)
                .And(s.Then.the_scenario_start_time_should_match_the_start_time_of_the_first_step)
                .And(s.Then.the_scenario_end_time_should_match_the_end_time_of_the_last_step)
                .And(s.Then.the_scenario_time_should_match_the_summation_of_the_durations_of_all_child_steps)
                .And(s.Then.all_scenario_steps_should_be_marked_as_skipped)
                .And(s.Then.the_scenario_reason_should_be_ScenarioReason)
                .RunAsync();
        }
        [ScenarioFact]
        public async Task SkipAsyncNullReason()
        {
            var s = new Steps();
            s.State.ScenarioOutcome = Outcome.Failed;
            s.State.ScenarioExceptionType = "ArgumentNullException";
            s.State.ScenarioExceptionMessage = "Value cannot be null.\r\nParameter name: reason";
            s.State.ScenarioReason = null;
            await xBDD.CurrentRun.AddScenario()
                .SetOutputWriter(outputWriter)
                .Given(s.Given.a_test_run)
                .And(s.Given.a_scenario)
                .And(s.Given.the_scenario_has_three_steps)
                .WhenAsync(s.When.the_scenario_is_skipped_asynchronously_with_reason_of_ScenarioReason)
                .And(s.Then.the_caught_scenario_exception_should_be_of_type_ScenarioExceptionType)
                .And(s.Then.the_caught_scenario_exception_should_have_a_message_of_ScenarioExceptionMessage)
                .RunAsync();
        }
        [ScenarioFact]
        public void WithAllPassingSteps()
        {
            var s = new Steps();
            s.State.ScenarioOutcome = Outcome.Passed;
            xBDD.CurrentRun.AddScenario()
                .SetOutputWriter(outputWriter)
                .Given(s.Given.a_test_run)
                .And(s.Given.a_scenario)
                .And(s.Given.the_scenario_has_three_steps)
                .When(s.When.the_scenario_is_run)
                .Then(s.Then.the_scenario_outcome_should_be_ScenarioOutcome)
                .And(s.Then.the_scenario_start_time_should_match_the_start_time_of_the_first_step)
                .And(s.Then.the_scenario_end_time_should_match_the_end_time_of_the_last_step)
                .And(s.Then.the_scenario_time_should_match_the_summation_of_the_durations_of_all_child_steps)
                .And("step 1 should be passed", st => {
                    Assert.Equal(Outcome.Passed, s.State.Scenario.Steps[0].Outcome);
                })
                .And("step 2 should be passed", st => {
                    Assert.Equal(Outcome.Passed, s.State.Scenario.Steps[1].Outcome);
                })
                .And("step 3 should be passed", st => {
                    Assert.Equal(Outcome.Passed, s.State.Scenario.Steps[2].Outcome);
                })
                .Run();
        }

        [ScenarioFact]
        public void WithAllSkippedSteps()
        {
            var s = new Steps();
            s.State.ScenarioOutcome = Outcome.Failed;
            s.State.ScenarioReason = "Step Skipped";
            s.State.ScenarioExceptionMessage = "The step 'Given my starting condition' threw a 'SkipStepException' exception with a message: 'Not Started'. See the inner exception for details.";
            s.State.ScenarioExceptionType = "StepException";
            xBDD.CurrentRun.AddScenario()
                .SetOutputWriter(outputWriter)
                .Given(s.Given.a_test_run)
                .And(s.Given.a_scenario)
                .And(s.Given.the_scenario_has_three_steps)
                .And(s.Given.all_steps_are_set_to_skip)
                .When(s.When.the_scenario_is_run_and_the_exception_caught)
                .Then(s.Then.the_scenario_outcome_should_be_ScenarioOutcome)
                .And(s.Then.the_scenario_start_time_should_match_the_start_time_of_the_first_step)
                .And(s.Then.the_scenario_end_time_should_match_the_end_time_of_the_last_step)
                .And(s.Then.the_scenario_time_should_match_the_summation_of_the_durations_of_all_child_steps)
                .And(s.Then.the_scenario_reason_should_be_ScenarioReason)
                .And(s.Then.the_caught_scenario_exception_should_be_of_type_ScenarioExceptionType)
                .And(s.Then.the_caught_scenario_exception_should_have_a_message_of_ScenarioExceptionMessage)
                .Run();
        }
        [ScenarioFact]
        public void WithOneMiddleSkippedStepAndTheRestPassing()
        {
            var s = new Steps();
            s.State.ScenarioOutcome = Outcome.Failed;
            s.State.ExceptionStepIndex = 1;
            s.State.StepException = new SkipStepException("Not Started");
            s.State.ScenarioReason = "Step Skipped";
            s.State.ScenarioExceptionType = "StepException";
            s.State.ScenarioExceptionMessage = "The step 'When my action' threw a 'SkipStepException' exception with a message: 'Not Started'. See the inner exception for details.";
            xBDD.CurrentRun.AddScenario()
                .SetOutputWriter(outputWriter)
                .Given(s.Given.a_test_run)
                .And(s.Given.a_scenario)
                .And(s.Given.the_scenario_has_three_steps)
                .And(s.Given.the_ExceptionStepIndex_step_throws_a_ExceptionType_exception)
                .When(s.When.the_scenario_is_run_and_the_exception_caught)
                .Then(s.Then.the_scenario_outcome_should_be_ScenarioOutcome)
                .And(s.Then.the_scenario_start_time_should_match_the_start_time_of_the_first_step)
                .And(s.Then.the_scenario_end_time_should_match_the_end_time_of_the_last_step)
                .And(s.Then.the_scenario_time_should_match_the_summation_of_the_durations_of_all_child_steps)
                .And(s.Then.the_caught_scenario_exception_should_be_of_type_ScenarioExceptionType)
                .And(s.Then.the_caught_scenario_exception_should_have_a_message_of_ScenarioExceptionMessage)
                .And(s.Then.the_scenario_reason_should_be_ScenarioReason)
                .And("step 1 should be passed", st => {
                    Assert.Equal(Outcome.Passed, s.State.Scenario.Steps[0].Outcome);
                })
                .And("step 3 should be skipped", st => {
                    Assert.Equal(Outcome.Skipped, s.State.Scenario.Steps[2].Outcome);
                })
                .Run();
        }
        [ScenarioFact]
        public void WithOneMiddleNotImplementedStepAndTheRestPassing()
        {
            var s = new Steps();
            s.State.ScenarioOutcome = Outcome.Failed;
            s.State.ExceptionStepIndex = 1;
            s.State.StepException = new NotImplementedException();
            s.State.ScenarioReason = "Step Not Implemented";
            s.State.ScenarioExceptionType = "StepNotImplementedException";
            s.State.ScenarioExceptionMessage = "The 'When my action' step is not implemented.";
            xBDD.CurrentRun.AddScenario()
                .SetOutputWriter(outputWriter)
                .Given(s.Given.a_test_run)
                .And(s.Given.a_scenario)
                .And(s.Given.the_scenario_has_three_steps)
                .And(s.Given.the_ExceptionStepIndex_step_throws_a_ExceptionType_exception)
                .When(s.When.the_scenario_is_run_and_the_exception_caught)
                .Then(s.Then.the_scenario_outcome_should_be_ScenarioOutcome)
                .And(s.Then.the_scenario_start_time_should_match_the_start_time_of_the_first_step)
                .And(s.Then.the_scenario_end_time_should_match_the_end_time_of_the_last_step)
                .And(s.Then.the_scenario_time_should_match_the_summation_of_the_durations_of_all_child_steps)
                .And(s.Then.the_caught_scenario_exception_should_be_of_type_ScenarioExceptionType)
                .And(s.Then.the_caught_scenario_exception_should_have_a_message_of_ScenarioExceptionMessage)
                .And(s.Then.the_scenario_reason_should_be_ScenarioReason)
                .And("step 1 should be passed", st => {
                    Assert.Equal(Outcome.Passed, s.State.Scenario.Steps[0].Outcome);
                })
                .And("step 3 should be skipped", st => {
                    Assert.Equal(Outcome.Skipped, s.State.Scenario.Steps[2].Outcome);
                })
                .Run();
        }
        [ScenarioFact]
        public void WithOneMiddleFailingStepAndTheRestPassing()
        {
            var s = new Steps();
            s.State.ScenarioOutcome = Outcome.Failed;
            xBDD.CurrentRun.AddScenario()
                .SetOutputWriter(outputWriter)
                .When(s.When.a_scenario_with_one_middle_failing_steps_is_run)
                .Then(s.Then.the_scenario_outcome_should_be_ScenarioOutcome)
                .And(s.Then.the_scenario_start_time_should_match_the_start_time_of_the_first_step)
                .And(s.Then.the_scenario_end_time_should_match_the_end_time_of_the_last_step)
                .And(s.Then.the_scenario_time_should_match_the_summation_of_the_durations_of_all_child_steps)
                .And(s.Then.all_other_steps_should_be_marked_as_passed)
                .Run();
        }
        [ScenarioFact]
        public void WithOneFailingStepAndPreceedingPassingSteps()
        {
            var s = new Steps();
            s.State.ScenarioOutcome = Outcome.Failed;
            xBDD.CurrentRun.AddScenario()
                .SetOutputWriter(outputWriter)
                .When(s.When.a_scenario_with_the_first_step_skipped_and_the_middle_step_failing_is_run)
                .Then(s.Then.the_scenario_outcome_should_be_ScenarioOutcome)
                .And(s.Then.the_scenario_start_time_should_match_the_start_time_of_the_first_step)
                .And(s.Then.the_scenario_end_time_should_match_the_end_time_of_the_last_step)
                .And(s.Then.the_scenario_time_should_match_the_summation_of_the_durations_of_all_child_steps)
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
