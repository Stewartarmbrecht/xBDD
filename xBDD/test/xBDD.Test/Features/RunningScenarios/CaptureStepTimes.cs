using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace xBDD.Test.Features.RunningScenarios
{
    public class CaptureStepTimes
    {
        [Fact]
        public void WhenPassingRun()
        {
            var s = new RunningScenariosSteps();
            var scenario = xBDD.CurrentRun.AddScenario();
            scenario
                .Given(s.a_simple_passing_scenario_with_a_time_capturing_step)
                .When(s.the_scenario_is_run)
                .Then(s.the_step_start_date_should_be_before_the_step_captured_time)
                .And(s.the_step_end_date_should_be_after_the_step_captured_time);
            scenario.Run();
        }

        [Fact]
        public void WhenFailingRun()
        {
            var s = new RunningScenariosSteps();
            var scenario = xBDD.CurrentRun.AddScenario();
            scenario
                .Given(s.a_simple_failing_scenario_with_a_failing_time_capturing_step)
                .When(s.the_scenario_is_run_and_the_exception_caught)
                .Then(s.the_step_start_date_should_be_before_the_step_captured_time)
                .And(s.the_step_end_date_should_be_after_the_step_captured_time);
            scenario.Run();
        }
    }
}
