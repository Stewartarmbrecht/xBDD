using System.Threading.Tasks;
using xBDD.Core;
 
namespace xBDD.Test.Sample
{
    public class SimpleTestRunUsingDynamicState : ISimpleTestRun
    {
        public int SaveToDatabase(string connectionName)
        {
            return testRun.SaveToDatabase(connectionName);
        }
        TestRun testRun = new TestRun(new CoreFactory());
        public Scenario Scenario { get; set; }

        public void PassingScenario()
        {
            var s = new SampleStepsWithDynamicState();
            Scenario = testRun.AddScenario(this)
                .Given(s.the_user_logs_in_as_UserName)
                .When(s.the_user_loads_the_PageName_page)
                .Then(s.the_loaded_page_should_have_a_header_of_ExpectedHeader);

            Scenario.State.UserName = "test.user@tococms.com";
            Scenario.State.PageName = "Home - ToCo CMS";
            Scenario.State.Header = "ToCo CMS";

            Scenario.Run();
        }

        public async Task PassingScenarioAsync()
        {
            var s = new SampleStepsWithDynamicState();
            Scenario = testRun.AddScenario(this)
                .GivenAsync(s.the_user_logs_in_as_UserName_async)
                .WhenAsync(s.the_user_loads_the_PageName_page_async)
                .Then(s.the_loaded_page_should_have_a_header_of_ExpectedHeader);

            Scenario.State.UserName = "test.user@tococms.com";
            Scenario.State.PageName = "Home - ToCo CMS";
            Scenario.State.Header = "ToCo CMS";

            await Scenario.RunAsync();
        }

        public void FailingScenarioWithFailingTimeCapturingStep()
        {
            var s = new SampleStepsWithDynamicState();
            Scenario = testRun.AddScenario(this)
                .Given(s.the_user_logs_in_as_UserName)
                .When(s.the_user_loads_the_PageName_page)
                .And(s.the_time_is_captured_and_the_step_fails)
                .Then(s.the_loaded_page_should_have_a_header_of_ExpectedHeader);

            Scenario.State.UserName = "test.user@tococms.com";
            Scenario.State.PageName = "Home - ToCo CMS";
            Scenario.State.Header = "ToCo CMS";

            Scenario.Run();
        }

        public void PassingScenarioWithTimeCapturingStep()
        {
            var s = new SampleStepsWithDynamicState();
            Scenario = testRun.AddScenario(this)
                .Given(s.the_user_logs_in_as_UserName)
                .When(s.the_user_loads_the_PageName_page)
                .And(s.the_time_is_captured)
                .Then(s.the_loaded_page_should_have_a_header_of_ExpectedHeader);

            Scenario.State.UserName = "test.user@tococms.com";
            Scenario.State.PageName = "Home - ToCo CMS";
            Scenario.State.Header = "ToCo CMS";

            Scenario.Run();
        }

        public void FailingScenario()
        {
            var s = new SampleStepsWithDynamicState();
            Scenario = testRun.AddScenario(this)
                .Given(s.the_user_logs_in_as_UserName)
                .When(s.the_user_loads_the_PageName_page)
                .Then(s.the_loaded_page_should_have_a_header_of_ExpectedHeader);

            Scenario.State.PageLoadShouldFail = true;
            Scenario.State.UserName = "test.user@tococms.com";
            Scenario.State.PageName = "Home - ToCo CMS";
            Scenario.State.Header = "ToCo CMS";

            Scenario.Run();
        }

        public async Task FailingScenarioAsync()
        {
            var s = new SampleStepsWithDynamicState();
            Scenario = testRun.AddScenario(this)
                .GivenAsync(s.the_user_logs_in_as_UserName_async)
                .WhenAsync(s.the_user_loads_the_PageName_page_async)
                .Then(s.the_loaded_page_should_have_a_header_of_ExpectedHeader);

            Scenario.State.PageLoadShouldFail = true;
            Scenario.State.UserName = "test.user@tococms.com";
            Scenario.State.PageName = "Home - ToCo CMS";
            Scenario.State.Header = "ToCo CMS";

            await Scenario.RunAsync();
        }

        public void SkippedScenario()
        {
            var s = new SampleStepsWithDynamicState();
            Scenario = testRun.AddScenario(this)
                .Given(s.the_user_logs_in_as_UserName)
                .When(s.the_user_loads_the_PageName_page)
                .Then(s.the_loaded_page_should_have_a_header_of_ExpectedHeader);

            Scenario.State.PageLoadShouldSkip = true;
            Scenario.State.UserName = "test.user@tococms.com";
            Scenario.State.PageName = "Home - ToCo CMS";
            Scenario.State.Header = "ToCo CMS";

            Scenario.Run();
        }
    }
}
