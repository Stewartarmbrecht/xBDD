using System.Threading.Tasks;
using xBDD.Core;

namespace xBDD.Test.Sample
{
    public class SimpleTestRunUsingTypedState : ISimpleTestRun
    {
        internal ITestRun testRun = new TestRun(new Factory());
        public virtual IScenario Scenario { get; set; }

        //[Fact]
        public virtual void PassingScenario()
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

        //[Fact]
        public virtual async Task PassingScenarioAsync()
        {
            var s = new SampleStepsWithTypedState();
            var scenario = testRun.AddScenario();
            scenario.GivenAsync(s.the_user_logs_in_as_x_async);
            scenario.WhenAsync(s.the_user_loads_the_x_page_async);
            scenario.Then(s.the_loaded_page_should_have_a_header_of_x);

            s.UserName = "test.user@tococms.com";
            s.PageName = "Home - ToCo CMS";
            s.Header = "ToCo CMS";
            Scenario = scenario;
            await scenario.RunAsync();
        }

        public virtual void FailingScenarioWithFailingTimeCapturingStep()
        {
            var s = new SampleStepsWithTypedState();
            var scenario = testRun.AddScenario();
            scenario
                .Given(s.the_user_logs_in_as_x)
                .When(s.the_user_loads_the_x_page)
                .And(s.the_time_is_captured_and_the_step_fails)
                .Then(s.the_loaded_page_should_have_a_header_of_x);

            s.UserName = "test.user@tococms.com";
            s.PageName = "Home - ToCo CMS";
            s.Header = "ToCo CMS";
            Scenario = scenario;
            scenario.Run();
        }

        public virtual void PassingScenarioWithTimeCapturingStep()
        {
            var s = new SampleStepsWithTypedState();
            var scenario = testRun.AddScenario();
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

        //[Fact]
        public virtual void FailingScenario()
        {
            var s = new SampleStepsWithTypedState();
            var scenario = testRun.AddScenario();
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

        //[Fact]
        public virtual async Task FailingScenarioAsync()
        {
            var s = new SampleStepsWithTypedState();
            var scenario = testRun.AddScenario();
            scenario
                .GivenAsync(s.the_user_logs_in_as_x_async)
                .WhenAsync(s.the_user_loads_the_x_page_async)
                .Then(s.the_loaded_page_should_have_a_header_of_x);

            s.PageLoadShouldFail = true;
            s.UserName = "test.user@tococms.com";
            s.PageName = "Home - ToCo CMS";
            s.Header = "ToCo CMS";
            Scenario = scenario;
            await scenario.RunAsync();
        }
    }
}
