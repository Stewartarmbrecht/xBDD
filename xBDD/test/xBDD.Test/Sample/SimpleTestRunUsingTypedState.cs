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
            s.UserName = "test.user@tococms.com";
            s.PageName = "Home - ToCo CMS";
            s.Header = "ToCo CMS";

            Scenario = testRun.AddScenario()
                .Given(s.the_user_logs_in_as_x)
                .When(s.the_user_loads_the_x_page)
                .Then(s.the_loaded_page_should_have_a_header_of_x);

            Scenario.Run();
        }

        //[Fact]
        public virtual async Task PassingScenarioAsync()
        {
            var s = new SampleStepsWithTypedState();
            s.UserName = "test.user@tococms.com";
            s.PageName = "Home - ToCo CMS";
            s.Header = "ToCo CMS";
            Scenario = testRun.AddScenario()
                .GivenAsync(s.the_user_logs_in_as_x_async)
                .WhenAsync(s.the_user_loads_the_x_page_async)
                .Then(s.the_loaded_page_should_have_a_header_of_x);

            await Scenario.RunAsync();
        }

        public virtual void FailingScenarioWithFailingTimeCapturingStep()
        {
            var s = new SampleStepsWithTypedState();
            s.UserName = "test.user@tococms.com";
            s.PageName = "Home - ToCo CMS";
            s.Header = "ToCo CMS";

            Scenario = testRun.AddScenario()
                .Given(s.the_user_logs_in_as_x)
                .When(s.the_user_loads_the_x_page)
                .And(s.the_time_is_captured_and_the_step_fails)
                .Then(s.the_loaded_page_should_have_a_header_of_x);

            Scenario.Run();
        }

        public virtual void PassingScenarioWithTimeCapturingStep()
        {
            var s = new SampleStepsWithTypedState();
            s.UserName = "test.user@tococms.com";
            s.PageName = "Home - ToCo CMS";
            s.Header = "ToCo CMS";

            Scenario = testRun.AddScenario()
                .Given(s.the_user_logs_in_as_x)
                .When(s.the_user_loads_the_x_page)
                .And(s.the_time_is_captured)
                .Then(s.the_loaded_page_should_have_a_header_of_x);

            Scenario.Run();
        }

        //[Fact]
        public virtual void FailingScenario()
        {
            var s = new SampleStepsWithTypedState();
            s.PageLoadShouldFail = true;
            s.UserName = "test.user@tococms.com";
            s.PageName = "Home - ToCo CMS";
            s.Header = "ToCo CMS";

            Scenario = testRun.AddScenario()
                .Given(s.the_user_logs_in_as_x)
                .When(s.the_user_loads_the_x_page)
                .Then(s.the_loaded_page_should_have_a_header_of_x);

            Scenario.Run();
        }

        //[Fact]
        public virtual async Task FailingScenarioAsync()
        {
            var s = new SampleStepsWithTypedState();
            s.PageLoadShouldFail = true;
            s.UserName = "test.user@tococms.com";
            s.PageName = "Home - ToCo CMS";
            s.Header = "ToCo CMS";

            Scenario = testRun.AddScenario()
                .GivenAsync(s.the_user_logs_in_as_x_async)
                .WhenAsync(s.the_user_loads_the_x_page_async)
                .Then(s.the_loaded_page_should_have_a_header_of_x);

            await Scenario.RunAsync();
        }
    }
}
