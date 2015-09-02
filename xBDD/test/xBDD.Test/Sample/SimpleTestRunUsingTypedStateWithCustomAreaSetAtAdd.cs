﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace xBDD.Test.Sample
{
    public class SimpleTestRunUsingTypedStateWithCustomAreaSetAtAdd : SimpleTestRunUsingTypedState
    {
        public override void PassingScenario()
        {
            var s = new SampleStepsWithTypedState();
            var scenario = testRun.AddScenario(null, null, "My.Explicitly.Set.Area");
            scenario.Given(s.the_user_logs_in_as_x);
            scenario.When(s.the_user_loads_the_x_page);
            scenario.Then(s.the_loaded_page_should_have_a_header_of_x);

            s.UserName = "test.user@tococms.com";
            s.PageName = "Home - ToCo CMS";
            s.Header = "ToCo CMS";
            Scenario = scenario;
            scenario.Run();
        }

        public override void FailingScenario()
        {
            var s = new SampleStepsWithTypedState();
            var scenario = testRun.AddScenario(null, "My Explicitly Set Feature Name");
            scenario
                .Given(s.the_user_logs_in_as_x)
                .When(s.the_user_loads_the_x_page)
                .Then(s.the_loaded_page_should_have_a_header_of_x);

            s.PageLoadShouldFail = true;
            s.UserName = "test.user@tococms.com";
            s.PageName = "Home - ToCo CMS";
            s.Header = "ToCo CMS";
            Scenario = scenario;
            scenario.Run();
        }

        public override void PassingScenarioWithTimeCapturingStep()
        {
            var s = new SampleStepsWithTypedState();
            var scenario = testRun.AddScenario("My Explicitly Set Scenario Name");
            scenario
                .Given(s.the_user_logs_in_as_x)
                .When(s.the_user_loads_the_x_page)
                .And(s.the_time_is_captured)
                .Then(s.the_loaded_page_should_have_a_header_of_x);

            s.UserName = "test.user@tococms.com";
            s.PageName = "Home - ToCo CMS";
            s.Header = "ToCo CMS";
            Scenario = scenario;
            scenario.Run();
        }
    }
}
