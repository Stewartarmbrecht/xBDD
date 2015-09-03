using Xunit;

namespace xBDD.Test.Features.RunningScenarios
{
    public class CaptureStepOutcome
    {
        [ScenarioFact]
        public void WhenPassingRun()
        {
            var s = new RunningScenariosSteps();
            xBDD.CurrentRun.AddScenario()
                .When(s.a_simple_passing_scenario_is_run)
                .Then(s.the_step_outcome_should_show_passed)
                .Run();
        }

        [ScenarioFact]
        public void WhenFailingRun()
        {
            var s = new RunningScenariosSteps();
            xBDD.CurrentRun.AddScenario()
                .When(s.a_simple_failing_scenario_is_run_and_the_exception_caught)
                .Then(s.the_step_outcome_should_show_failed)
                .Run();
        }

        [ScenarioFact]
        public void WhenSkippedRun()
        {
            var s = new RunningScenariosSteps();
            s.ExpectedReason = "Not Implemented.";
            xBDD.CurrentRun.AddScenario()
                .When(s.a_simple_scenario_with_a_skipped_step_is_run_and_the_exception_is_caught)
                .Then(s.the_step_outcome_should_show_skipped)
                .And(s.the_step_reason_should_be_ExpectedReason)
                .Run();
        }

    }
}
