using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace xBDD.Test.Features.RunTests
{
    public class FailAStep
    {
        [ScenarioFact]
        public void PassSync()
        {
            var s = new Steps();
            xBDD.CurrentRun.AddScenario();
            throw new SkipStepException("Not Implemented");
        }
        [ScenarioFact]
        public void PassAsync()
        {
            var s = new Steps();
            xBDD.CurrentRun.AddScenario();
            throw new SkipStepException("Not Implemented");
        }
        [ScenarioFact]
        public void FailSync()
        {
            var s = new Steps();
            xBDD.CurrentRun.AddScenario();
            throw new SkipStepException("Not Implemented");
        }
        [ScenarioFact]
        public void FailAsync()
        {
            var s = new Steps();
            xBDD.CurrentRun.AddScenario();
            throw new SkipStepException("Not Implemented");
        }

        [ScenarioFact]
        public void SkipSync()
        {
            var s = new Steps();
            xBDD.CurrentRun.AddScenario();
            throw new SkipStepException("Not Implemented");
        }
        [ScenarioFact]
        public void SkipAsync()
        {
            var s = new Steps();
            xBDD.CurrentRun.AddScenario();
            throw new SkipStepException("Not Implemented");
        }

        [ScenarioFact]
        public void SkipBecauseOfPreviousSkipSync()
        {
            var s = new Steps();
            xBDD.CurrentRun.AddScenario()
                .Given(s.a_scenario_with_one_skipped_step)
                .And(s.the_last_step_includes_ReturnIfPreviousError_line)
                .When(s.the_scenario_is_run)
                .Then(s.code_in_the_last_step_after_the_ReturnIfPreviousError_line_should_not_execute)
                .And(s.code_in_the_last_step_before_the_ReturnIfPreviousError_line_should_execute)
                .And(s.the_last_step_should_have_a_skipped_outcome)
                .Run();
        }
        [ScenarioFact]
        public void SkipBecauseOfPreviousSkipAsync()
        {
            var s = new Steps();
            xBDD.CurrentRun.AddScenario();
            throw new SkipStepException("Not Implemented");
        }

    }
}
