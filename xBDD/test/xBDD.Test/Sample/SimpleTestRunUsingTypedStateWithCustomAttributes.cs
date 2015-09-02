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
            var scenario = testRun.AddScenario();
            scenario.Given(s.the_user_logs_in_as_x);
            scenario.When(s.the_user_loads_the_x_page);
            scenario.Then(s.the_loaded_page_should_have_a_header_of_x);

            s.UserName = "test.user@tococms.com";
            s.PageName = "Home - ToCo CMS";
            s.Header = "ToCo CMS";
            Scenario = scenario;
            scenario.Run();
        }
    }
}
