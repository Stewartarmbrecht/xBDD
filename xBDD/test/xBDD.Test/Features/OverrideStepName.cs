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
            var scenario = xBDD.CurrentRun.AddScenario();
            scenario.Given(stepName, step => { });
            Assert.Equal("Given My Step", scenario.Steps[0].Name);
        }
        [Fact]
        public void InsideStepMethod()
        {
            var stepName = "My Step";
            var scenario = xBDD.CurrentRun.AddScenario();
            scenario.Given(step => { step.SetName(stepName); });
            scenario.Run();
            Assert.Equal("Given My Step", scenario.Steps[0].Name);
        }
        [Fact]
        public void WithAttributeOnStepMethod()
        {
            var scenario = xBDD.CurrentRun.AddScenario();
            scenario.Given(MyStep);
            Assert.Equal("Given My Overridden Step Name", scenario.Steps[0].Name);
        }

        [StepName("My Overridden Step Name")]
        private void MyStep(IStep step)
        {
            return;
        }
    }
}
