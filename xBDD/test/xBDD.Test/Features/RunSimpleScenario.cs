using System;
using System.Threading.Tasks;
using xBDD.Test.Support;
using Xunit;

namespace xBDD.Test.Stories
{
    public class RunSimpleTest
    {
        [Fact]
        public void PassingTest()
        {
            var scenario = xBDD.CurrentRun.AddScenario();
            scenario.Given(TestSteps.Step_1);
            scenario.When(TestSteps.Step_2);
            scenario.Then(TestSteps.Step_3);
            scenario.And(TestSteps.Step_4);
            scenario.Run();
            Assert.Equal("Passing Test", scenario.Name);
            Assert.Equal("Run Simple Test", scenario.FeatureName);
            Assert.Equal("xBDD.Test.Stories", scenario.AreaPath);
            Assert.Equal(4, scenario.Steps.Count);
            Assert.Equal("Given step 1", scenario.Steps[0].Name);
            Assert.Equal("When step 2", scenario.Steps[1].Name);
            Assert.Equal("Then step 3", scenario.Steps[2].Name);
            Assert.Equal("And step 4", scenario.Steps[3].Name);
            Assert.Equal(4, (int)scenario.State["Counter"]);
        }
        [Fact]
        public void FailingTest()
        {
            string exceptionMessage = "My Failure";
            var test = xBDD.CurrentRun.AddScenario();
            test.Given(step => { throw new System.Exception(exceptionMessage); });
            var thrownMessage = "";
            try
            {
                test.Run();
            }
            catch(Exception ex)
            {
                thrownMessage = ex.Message;
            }

            Assert.Equal(exceptionMessage, thrownMessage);
        }
        [Fact]
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
            Assert.Equal("Given step 1", scenario.Steps[0].Name);
            Assert.Equal("When step 2", scenario.Steps[1].Name);
            Assert.Equal("Then step 3", scenario.Steps[2].Name);
            Assert.Equal("And step 4", scenario.Steps[3].Name);
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
