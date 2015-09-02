using xBDD.Core;

namespace xBDD.Test.Sample
{
    public class SimpleTypedTestRun
    {
        ITestRun testRun = new TestRun(new Factory());
        public IScenario Scenario { get; set; }
        public void PassingScenario()
        {
            var ts = new SampleSteps();
            ts.PageName = "Home";
            ts.FailAttempts = 5;
            ts.Message = "There were " + ts.FailAttempts + " failed login attempts since the last login!";
            ts.Title = "Home";

            var s = xBDD.CurrentRun.AddScenario();
            s.Given(ts.the_user_successfully_logs_in_after_x_failed_attempts);
            s.When(ts.the_user_navigates_to_the_x_page);
            s.Then(ts.the_loaded_page_should_have_a_title_of_x);
            s.And(ts.the_loaded_page_should_have_a_message_of_x);
            s.Run();
        }
    }
}
