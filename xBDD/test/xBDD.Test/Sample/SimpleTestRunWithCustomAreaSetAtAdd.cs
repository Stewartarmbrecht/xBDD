using System;
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
            s.UserName = "test.user@tococms.com";
            s.PageName = "Home - ToCo CMS";
            s.Header = "ToCo CMS";

            Scenario = testRun.AddScenario(null, null, "My.Explicitly.Set.Area", this)
                .Given(s.the_user_logs_in_as_UserName)
                .When(s.the_user_loads_the_PageName_page)
                .Then(s.the_loaded_page_should_have_a_header_of_ExpectedHeader);

            Scenario.Run();
        }

        public override void FailingScenario()
        {
            var s = new SampleStepsWithTypedState();
            s.PageLoadShouldFail = true;
            s.UserName = "test.user@tococms.com";
            s.PageName = "Home - ToCo CMS";
            s.Header = "ToCo CMS";

            Scenario = testRun.AddScenario(null, "My Explicitly Set Feature Name", this)
                .Given(s.the_user_logs_in_as_UserName)
                .When(s.the_user_loads_the_PageName_page)
                .Then(s.the_loaded_page_should_have_a_header_of_ExpectedHeader);

            Scenario.Run();
        }

        public override void PassingScenarioWithTimeCapturingStep()
        {
            var s = new SampleStepsWithTypedState();
            s.UserName = "test.user@tococms.com";
            s.PageName = "Home - ToCo CMS";
            s.Header = "ToCo CMS";

            Scenario = testRun.AddScenario("My Explicitly Set Scenario Name", this)
                .Given(s.the_user_logs_in_as_UserName)
                .When(s.the_user_loads_the_PageName_page)
                .And(s.the_time_is_captured)
                .Then(s.the_loaded_page_should_have_a_header_of_ExpectedHeader);

            Scenario.Run();
        }
    }
}
