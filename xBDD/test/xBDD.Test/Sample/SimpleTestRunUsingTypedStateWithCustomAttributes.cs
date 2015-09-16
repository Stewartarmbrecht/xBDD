using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace xBDD.Test.Sample
{
    [AreaPath("My.New.Area.Path")]
    [FeatureName("My New Feature Name")]
    public class SimpleTestRunUsingTypedStateWithCustomAttributes : SimpleTestRunUsingTypedState
    {
        [ScenarioName("My New Scenario Name")]
        public override void PassingScenario()
        {
            var s = new SampleStepsWithTypedState();
            s.UserName = "test.user@tococms.com";
            s.PageName = "Home - ToCo CMS";
            s.Header = "ToCo CMS";

            Scenario = testRun.AddScenario(this)
                .Given(s.the_user_logs_in_as_UserName)
                .When(s.the_user_loads_the_PageName_page)
                .Then(s.the_loaded_page_should_have_a_header_of_ExpectedHeader);

            Scenario.Run();
        }
    }
}
