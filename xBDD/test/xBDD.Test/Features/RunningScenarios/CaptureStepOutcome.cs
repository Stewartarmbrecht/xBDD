using Xunit;

namespace xBDD.Test.Features.RunningScenarios
{
    public class CaptureStepOutcome
    {
        [Fact]
        public void WhenPassingRun()
        {
            var s = new RunningScenariosSteps();
            xBDD.CurrentRun.AddScenario()
                .When(s.a_simple_passing_scenario_is_run)
                .Then(s.the_step_outcome_should_show_passed)
                .Run();
        }

        [Fact]
        public void WhenFailingRun()
        {
            var s = new RunningScenariosSteps();
            xBDD.CurrentRun.AddScenario()
                .When(s.a_simple_failing_scenario_is_run_and_the_exception_caught)
                .Then(s.the_step_outcome_should_show_failed)
                .Run();
        }

        //[Fact]
        //public void WhenNotImplementedRun()
        //{
        //    var s = new RunningScenariosSteps();
        //    xBDD.CurrentRun.AddScenario()
        //        .When(s.a_simple_scenario_with_a_not_implemented_step_is_run)
        //        .Then(s.the_step_outcome_should_show_not_implemented)
        //        .Run();
        //}

    }
}
