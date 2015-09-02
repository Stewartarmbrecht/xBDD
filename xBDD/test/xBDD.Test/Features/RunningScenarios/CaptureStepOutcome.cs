using System.Threading.Tasks;
using Xunit;

namespace xBDD.Test.Features.RunningScenarios
{
    public class CaptureStepOutcome
    {
        [Fact]
        public void WhenPassingRun()
        {
            var s = new RunningScenariosSteps();
            var scenario = xBDD.CurrentRun.AddScenario();
            scenario
                .Given(s.a_simple_passing_scenario)
                .When(s.the_scenario_is_run)
                .Then(s.the_step_outcome_should_show_passed);
            scenario.Run();
        }

        [Fact]
        public void WhenFailingRun()
        {
            var s = new RunningScenariosSteps();
            var scenario = xBDD.CurrentRun.AddScenario();
            scenario
                .Given(s.a_simple_failing_scenario)
                .When(s.the_scenario_is_run_and_the_exception_caught)
                .Then(s.the_step_outcome_should_show_failed);
            scenario.Run();
        }
    }
}
