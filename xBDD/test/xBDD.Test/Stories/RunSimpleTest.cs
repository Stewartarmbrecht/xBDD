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
            var test = TestRun.Current.AddTestCase();
            test.Given(Step1);
            test.When(Step2);
            test.Then(Step3);
            test.And(Step4);
            test.Run();
            Assert.Equal("Passing Test", test.Name);
            Assert.Equal("Run Simple Test", test.ClassName);
            Assert.Equal("xBDD.Test.Stories", test.Namespace);
            Assert.Equal(4, test.Steps.Count);
            Assert.Equal("Step 1", test.Steps[0].Name);
            Assert.Equal("Step 2", test.Steps[1].Name);
            Assert.Equal("Step 3", test.Steps[2].Name);
            Assert.Equal("Step 4", test.Steps[3].Name);
        }
        [Fact]
        public void FailingTest()
        {
            string exceptionMessage = "My Failure";
            var test = TestRun.Current.AddTestCase();
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
        void Step1(ITestStep step)
        {

        }
        void Step2(ITestStep step)
        {

        }
        void Step3(ITestStep step)
        {

        }
        void Step4(ITestStep step)
        {

        }
        [Fact]
        public async Task PassingTestAsync()
        {
            var test = TestRun.Current.AddTestCase();
            test.Given(Step1);
            test.When(Step2);
            test.Then(Step3);
            test.And(Step4);
            test.Run();
            Assert.Equal("Passing Test Async", test.Name);
            Assert.Equal("Run Simple Test", test.ClassName);
            Assert.Equal("xBDD.Test.Stories", test.Namespace);
            Assert.Equal(4, test.Steps.Count);
            Assert.Equal("Step 1", test.Steps[0].Name);
            Assert.Equal("Step 2", test.Steps[1].Name);
            Assert.Equal("Step 3", test.Steps[2].Name);
            Assert.Equal("Step 4", test.Steps[3].Name);
        }
        [Fact]
        public async Task FailingTestAsync()
        {
            string exceptionMessage = "My Failure";
            var test = TestRun.Current.AddTestCase();
            test.Given(step => { throw new System.Exception(exceptionMessage); });
            var thrownMessage = "";
            try
            {
                test.Run();
            }
            catch (Exception ex)
            {
                thrownMessage = ex.Message;
            }

            Assert.Equal(exceptionMessage, thrownMessage);
        }
        //[Fact]
        //public void CreateTestWithMethodName()
        //{
        //    var testName = "Create Test With Method Name";
        //    var test = TestRun.Current.AddTestCase();
        //    Assert.Equal(testName, test.Name);
        //}
        //[Fact]
        //public void AddGivenStep()
        //{
        //    var test = TestRun.Current.AddTestCase();
        //    test.Given((step) => { return; });
        //    Assert.Equal(1, test.Steps.Count);
        //    Assert.Equal(ActionType.Given, test.Steps[0].ActionType);
        //}
        //[Fact]
        //public void AddWhenStep()
        //{
        //    var test = TestRun.Current.AddTestCase();
        //    test.When((step) => { return; });
        //    Assert.Equal(1, test.Steps.Count);
        //    Assert.Equal(ActionType.When, test.Steps[0].ActionType);
        //}
        //[Fact]
        //public void AddThenStep()
        //{
        //    var test = TestRun.Current.AddTestCase();
        //    test.Then((step) => { return; });
        //    Assert.Equal(1, test.Steps.Count);
        //    Assert.Equal(ActionType.Then, test.Steps[0].ActionType);
        //}
        //[Fact]
        //public void AddAndStep()
        //{
        //    var test = TestRun.Current.AddTestCase();
        //    test.And((step) => { return; });
        //    Assert.Equal(1, test.Steps.Count);
        //    Assert.Equal(ActionType.And, test.Steps[0].ActionType);
        //}
        //[Fact]
        //public void SetStepName()
        //{
        //    var test = TestRun.Current.AddTestCase();
        //    test.Given("Step 1", (step) => { return; });
        //    test.When("Step 2", (step) => { return; });
        //    test.Then("Step 3", (step) => { return; });
        //    test.And("Step 4", (step) => { return; });
        //    Assert.Equal("Step 1", test.Steps[0].Name);
        //    Assert.Equal("Step 2", test.Steps[1].Name);
        //    Assert.Equal("Step 3", test.Steps[2].Name);
        //    Assert.Equal("Step 4", test.Steps[3].Name);
        //}
        //[Fact]
        //public void SetStepNameFromActionName()
        //{
        //    var test = TestRun.Current.AddTestCase();
        //    test.Given(MyAction);
        //    Assert.Equal(1, test.Steps.Count);
        //    Assert.Equal("My Action", test.Steps[0].Name);
        //}
        //void MyAction(TestStep step)
        //{

        //}
        //[Fact]
        //public void DoNotSetStepNameWithAnonymousMethod()
        //{
        //    var test = TestRun.Current.AddTestCase();
        //    test.Given(step => { return; });
        //    Assert.Equal(1, test.Steps.Count);
        //    Assert.Equal(null, test.Steps[0].Name);
        //}
        //[Fact]
        //public void SetStepNameFromGenericActionName()
        //{
        //    var test = TestRun.Current.AddTestCase();
        //    test.Given(MyGenericAction<string>);
        //    Assert.Equal(1, test.Steps.Count);
        //    Assert.Equal("My Generic Action", test.Steps[0].Name);
        //}
        //void MyGenericAction<MyType>(TestStep step)
        //{

        //}
        //[Fact]
        //public void RunTest()
        //{
        //    int hitCount = 0;
        //    var test = TestRun.Current.AddTestCase();
        //    test.Given(step => { hitCount++; });
        //    test.When(step => { hitCount++; });
        //    test.Then(step => { hitCount++; });
        //    test.And(step => { hitCount++; });
        //    test.Run();
        //    Assert.Equal(4, hitCount);
        //}
        //[Fact]
        //public void SetStepNameInStep()
        //{
        //    string stepName = "My Test Step";
        //    var test = TestRun.Current.AddTestCase();
        //    test.Given(step => { step.Name = stepName; });
        //    test.Run();
        //    Assert.Equal(1, test.Steps.Count);
        //    Assert.Equal(stepName, test.Steps[0].Name);
        //}
    }
}
