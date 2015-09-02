using System;
using System.Threading.Tasks;
using xBDD.Core;

namespace xBDD.Test.Sample
{
    public class AsyncTestRunUsingDynamicState
    {
        ITestRun testRun = new TestRun(new Factory());
        public IScenario Scenario { get; set; }

        //[Fact]
        public async Task PassingScenario()
        {
            var s = new SampleSteps();
            var scenario = testRun.AddScenario();
            scenario.GivenAsync(s.the_user_logs_in_as_x_async);
            scenario.WhenAsync(s.the_user_loads_the_x_page_async);
            scenario.ThenAsync(s.the_loaded_page_should_have_a_header_of_x_async);

            scenario.State.UserName = "test.user@tococms.com";
            scenario.State.PageName = "Home - ToCo CMS";
            scenario.State.Header = "ToCo CMS";
            Scenario = scenario;
            await scenario.RunAsync();
        }

        //[Fact]
        public async Task FailingScenario()
        {
            var s = new SampleSteps();
            var scenario = testRun.AddScenario();
            scenario.GivenAsync(s.the_user_logs_in_as_x_async);
            scenario.WhenAsync(s.the_user_loads_the_x_page_async);
            scenario.ThenAsync(s.the_loaded_page_should_have_a_header_of_x_async);

            scenario.State.PageLoadShouldFail = true;
            scenario.State.UserName = "test.user@tococms.com";
            scenario.State.PageName = "Home - ToCo CMS";
            scenario.State.Header = "ToCo CMS";
            Scenario = scenario;
            await scenario.RunAsync();
        }
    }
}
