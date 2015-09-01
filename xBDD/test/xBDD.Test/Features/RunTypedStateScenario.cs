using System;
using System.Threading.Tasks;
using xBDD.Test.Support;
using Xunit;

namespace xBDD.Test.Stories
{
    public class RunTypedStateScenario
    {
        [Fact]
        public void PassingScenario()
        {
            Page page = new Page()
            {
                PageName = "Home"
            };
            var count = 5;
            var expectedMessage = "There were " + count + " failed login attempts since the last login!";
            var title = "Home";

            var scenario = xBDD.CurrentRun.AddScenario();
            scenario.Given(step => { TestSteps.TheUserSuccessfullyLogsInAfterXFailedAttempts(step, count); });
            scenario.When(step => { TestSteps.TheUserNavigatesToTheXPage(step, page); });
            scenario.Then(step => { TestSteps.TheLoadedPageShouldHaveATitleOfX(step, page, title); });
            scenario.And(step => { TestSteps.TheLoadedPageShouldHaveAMessageOfX(step, page, expectedMessage); });
            scenario.Run();

            Assert.Equal("Passing Scenario", scenario.Name);
            Assert.Equal("Run Typed State Scenario", scenario.FeatureName);
            Assert.Equal("xBDD.Test.Stories", scenario.AreaPath);
            Assert.Equal(4, scenario.Steps.Count);
            Assert.Equal("Given the user successfully logs in after 5 failed attempts", scenario.Steps[0].Name);
            Assert.Equal("When the user navigates to the Home page", scenario.Steps[1].Name);
            Assert.Equal("Then the loaded page should have a title of Home", scenario.Steps[2].Name);
            Assert.Equal("And the loaded page should have a message of 'There were 5 failed login attempts since the last login!'", scenario.Steps[3].Name);
        }
        [Fact]
        public void FailingScenario()
        {
            Page page = new Page()
            {
                PageName = "Home"
            };
            var count = 5;
            var expectedMessage = "There were " + count + " failed login attempts since the last login!";
            var title = "Home";
            string exceptionMessage = "My Failure";
            var scenario = xBDD.CurrentRun.AddScenario();
            scenario.Given(step => { TestSteps.TheUserSuccessfullyLogsInAfterXFailedAttempts(step, count); });
            scenario.When(step => { TestSteps.TheUserNavigatesToTheXPage(step, page); });
            scenario.And("the step fails", step => { throw new Exception(exceptionMessage); });
            scenario.Then(step => { TestSteps.TheLoadedPageShouldHaveATitleOfX(step, page, title); });
            scenario.And(step => { TestSteps.TheLoadedPageShouldHaveAMessageOfX(step, page, expectedMessage); });
            var thrownMessage = "";
            try
            {
                scenario.Run();
            }
            catch (Exception ex)
            {
                thrownMessage = ex.Message;
            }

            Assert.Equal(exceptionMessage, thrownMessage);
            Assert.Equal("Failing Scenario", scenario.Name);
            Assert.Equal("Run Typed State Scenario", scenario.FeatureName);
            Assert.Equal("xBDD.Test.Stories", scenario.AreaPath);
            Assert.Equal(5, scenario.Steps.Count);
            Assert.Equal("Given the user successfully logs in after 5 failed attempts", scenario.Steps[0].Name);
            Assert.Equal("When the user navigates to the Home page", scenario.Steps[1].Name);
            Assert.Equal("And the step fails", scenario.Steps[2].Name);
            Assert.Equal("Then ", scenario.Steps[3].Name);
            Assert.Equal("And ", scenario.Steps[4].Name);
        }

        [Fact(Skip = "Implementing Next")]
        public async Task PassingTestAsync()
        {
            var scenario = xBDD.CurrentRun.AddScenario();
            scenario.Given(TestSteps.Step_1);
            scenario.When(TestSteps.Step_2);
            scenario.Then(TestSteps.Step_3);
            scenario.And(TestSteps.Step_4);
            scenario.Run();
            Assert.Equal("Passing Test Async", scenario.Name);
            Assert.Equal("Run Simple Test", scenario.FeatureName);
            Assert.Equal("xBDD.Test.Stories", scenario.AreaPath);
            Assert.Equal(4, scenario.Steps.Count);
            Assert.Equal("Step 1", scenario.Steps[0].Name);
            Assert.Equal("Step 2", scenario.Steps[1].Name);
            Assert.Equal("Step 3", scenario.Steps[2].Name);
            Assert.Equal("Step 4", scenario.Steps[3].Name);
        }
        [Fact]
        public async Task FailingTestAsync()
        {
            string exceptionMessage = "My Failure";
            var scenario = xBDD.CurrentRun.AddScenario();
            scenario.Given(step => { throw new System.Exception(exceptionMessage); });
            var thrownMessage = "";
            try
            {
                scenario.Run();
            }
            catch (Exception ex)
            {
                thrownMessage = ex.Message;
            }

            Assert.Equal(exceptionMessage, thrownMessage);
        }
    }
}
