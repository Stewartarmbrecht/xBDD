using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace xBDD.Test.Stories
{
    public class OverrideStepName
    {
        [Fact]
        public void WhenAddingStep()
        {
            var stepName = "My Step";
            var test = TestRun.Current.AddTestCase();
            test.Given(stepName, step => { });
            Assert.Equal(stepName, test.Steps[0].Name);
        }
        [Fact]
        public void InsideStepMethod()
        {
            var stepName = "My Step";
            var test = TestRun.Current.AddTestCase();
            test.Given(step => { step.Name = stepName; });
            test.Run();
            Assert.Equal(stepName, test.Steps[0].Name);
        }
        [Fact]
        public void WithAttributeOnStepMethod()
        {
            var test = TestRun.Current.AddTestCase();
            test.Given(MyStep);
            Assert.Equal("My Overridden Step Name", test.Steps[0].Name);
        }

        [StepName("My Overridden Step Name")]
        private void MyStep(ITestStep step)
        {
            return;
        }
    }
}
