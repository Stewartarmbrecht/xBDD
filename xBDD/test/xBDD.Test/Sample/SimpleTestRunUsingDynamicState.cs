using System;
using System.Threading.Tasks;
using xBDD.Core;

namespace xBDD.Test.Sample
{
    public class SimpleTestRunUsingDynamicState
    {
        ITestRun testRun = new TestRun(new Factory());
        public IScenario Scenario { get; set; }

        //[Fact]
        public void PassingScenario()
        {
            var s = new SampleSteps();
            var scenario = testRun.AddScenario();
            scenario.Given(s.the_user_logs_in_as_x);
            scenario.When(s.the_user_loads_the_x_page);
            scenario.Then(s.the_loaded_page_should_have_a_header_of_x);

            scenario.State.UserName = "test.user@tococms.com";
            scenario.State.PageName = "Home - ToCo CMS";
            scenario.State.Header = "ToCo CMS";
            Scenario = scenario;
            scenario.Run();
        }

        //[Fact]
        public async Task PassingScenarioAsync()
        {
            var s = new SampleSteps();
            var scenario = testRun.AddScenario();
            scenario.GivenAsync(s.the_user_logs_in_as_x_async);
            scenario.WhenAsync(s.the_user_loads_the_x_page_async);
            scenario.Then(s.the_loaded_page_should_have_a_header_of_x);

            scenario.State.UserName = "test.user@tococms.com";
            scenario.State.PageName = "Home - ToCo CMS";
            scenario.State.Header = "ToCo CMS";
            Scenario = scenario;
            await scenario.RunAsync();
        }

        //[Fact]
        public void FailingScenario()
        {
            var s = new SampleSteps();
            var scenario = testRun.AddScenario();
            scenario.Given(s.the_user_logs_in_as_x);
            scenario.When(s.the_user_loads_the_x_page);
            scenario.Then(s.the_loaded_page_should_have_a_header_of_x);

            scenario.State.PageLoadShouldFail = true;
            scenario.State.UserName = "test.user@tococms.com";
            scenario.State.PageName = "Home - ToCo CMS";
            scenario.State.Header = "ToCo CMS";
            Scenario = scenario;
            scenario.Run();
        }

        //[Fact]
        public async Task FailingScenarioAsync()
        {
            var s = new SampleSteps();
            var scenario = testRun.AddScenario();
            scenario.GivenAsync(s.the_user_logs_in_as_x_async);
            scenario.WhenAsync(s.the_user_loads_the_x_page_async);
            scenario.Then(s.the_loaded_page_should_have_a_header_of_x);

            scenario.State.PageLoadShouldFail = true;
            scenario.State.UserName = "test.user@tococms.com";
            scenario.State.PageName = "Home - ToCo CMS";
            scenario.State.Header = "ToCo CMS";
            Scenario = scenario;
            await scenario.RunAsync();
        }
    }
}
