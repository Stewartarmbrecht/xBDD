using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using xBDD.Core;

namespace xBDD.Test.Features.ViewProperties
{
    [StepLibrary]
    public class Steps
    {
        IScenario scenarioAdded;
        internal void a_step_is_added_to_a_scenario(IStep obj)
        {
            var factory = new Factory();
            var testRun = new TestRun(factory);
            scenarioAdded = testRun.AddScenario("Test Scenario");
        }

        internal void you_can_get_not_set_the_Outcome_property(IStep obj)
        {
            Outcome outcome = scenarioAdded.Outcome;
        }

        internal void you_can_get_not_set_the_StartTime_property(IStep obj)
        {
            DateTime dateTime = scenarioAdded.StartTime;
        }

        internal void you_can_get_not_set_the_EndTime_property(IStep obj)
        {
            DateTime dateTime = scenarioAdded.EndTime;
        }

        internal void you_can_get_not_set_the_TotalTime_property(IStep obj)
        {
            TimeSpan dateTime = scenarioAdded.Time;
        }
    }
}
