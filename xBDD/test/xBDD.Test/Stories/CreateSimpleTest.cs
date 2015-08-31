using Xunit;

namespace xBDD.Test.Stories
{
    public class CreateSimpleTest
    {
        [Fact]
        public void CanCreateTestWithName()
        {
            var testName = "Can Create Test With Name";
            var test = TestRun.Current.AddTestCase(testName);
            Assert.Equal(testName, test.Name);
        }
        [Fact]
        public void CanCreateTestWithMethodName()
        {
            var testName = "Can Create Test With Method Name";
            var test = TestRun.Current.AddTestCase();
            Assert.Equal(testName, test.Name);
        }
        [Fact]
        public void CanAddGivenStep()
        {
            var test = TestRun.Current.AddTestCase();
            test.Given((step) => { return; });
            Assert.Equal(1, test.Steps.Count);
            Assert.Equal(ActionType.Given, test.Steps[0].ActionType);
        }
        [Fact]
        public void CanAddWhenStep()
        {
            var test = TestRun.Current.AddTestCase();
            test.When((step) => { return; });
            Assert.Equal(1, test.Steps.Count);
            Assert.Equal(ActionType.When, test.Steps[0].ActionType);
        }
        [Fact]
        public void CanAddThenStep()
        {
            var test = TestRun.Current.AddTestCase();
            test.Then((step) => { return; });
            Assert.Equal(1, test.Steps.Count);
            Assert.Equal(ActionType.Then, test.Steps[0].ActionType);
        }
        [Fact]
        public void CanAddAndStep()
        {
            var test = TestRun.Current.AddTestCase();
            test.And((step) => { return; });
            Assert.Equal(1, test.Steps.Count);
            Assert.Equal(ActionType.And, test.Steps[0].ActionType);
        }
        [Fact]
        public void CanSetStepName()
        {
            var test = TestRun.Current.AddTestCase();
            test.Given("Step 1", (step) => { return; });
            test.When("Step 2", (step) => { return; });
            test.Then("Step 3", (step) => { return; });
            test.And("Step 4", (step) => { return; });
            Assert.Equal("Step 1", test.Steps[0].Name);
            Assert.Equal("Step 2", test.Steps[1].Name);
            Assert.Equal("Step 3", test.Steps[2].Name);
            Assert.Equal("Step 4", test.Steps[3].Name);
        }
        [Fact]
        public void CanRunTest()
        {
            int hitCount = 0;
            var test = TestRun.Current.AddTestCase();
            test.Given("Step 1", (step) => { hitCount++; });
            test.When("Step 2", (step) => { hitCount++; });
            test.Then("Step 3", (step) => { hitCount++; });
            test.And("Step 4", (step) => { hitCount++; });
            test.Run();
            Assert.Equal(4, hitCount);
        }
    }
}
