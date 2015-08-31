using System;
using System.Threading.Tasks;
using Xunit;

namespace xBDD.Test.Stories
{
    public class RunSimpleTest
    {
        [Fact]
        public void PassingTest()
        {
            var scenario = TestRun.Current.AddScenario();
            scenario.Given(Step1);
            scenario.When(Step2);
            scenario.Then(Step3);
            scenario.And(Step4);
            scenario.Run();
            Assert.Equal("Passing Test", scenario.Name);
            Assert.Equal("Run Simple Test", scenario.FeatureName);
            Assert.Equal("xBDD.Test.Stories", scenario.AreaPath);
            Assert.Equal(4, scenario.Steps.Count);
            Assert.Equal("Step 1", scenario.Steps[0].Name);
            Assert.Equal("Step 2", scenario.Steps[1].Name);
            Assert.Equal("Step 3", scenario.Steps[2].Name);
            Assert.Equal("Step 4", scenario.Steps[3].Name);
        }
        [Fact]
        public void FailingTest()
        {
            string exceptionMessage = "My Failure";
            var test = TestRun.Current.AddScenario();
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
        void Step1(IStep step)
        {

        }
        void Step2(IStep step)
        {

        }
        void Step3(IStep step)
        {

        }
        void Step4(IStep step)
        {

        }
        [Fact]
        public async Task PassingTestAsync()
        {
            var scenario = TestRun.Current.AddScenario();
            scenario.Given(Step1);
            scenario.When(Step2);
            scenario.Then(Step3);
            scenario.And(Step4);
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
            var scenario = TestRun.Current.AddScenario();
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
