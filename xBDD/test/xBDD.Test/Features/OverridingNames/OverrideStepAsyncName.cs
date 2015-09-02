using System.Threading.Tasks;
using Xunit;

namespace xBDD.Test.Features.OverridingNames
{
    public class OverrideAsyncStepName
    {
        [Fact]
        public void WhenAddingStep()
        {
            var stepName = "My Step";
            var scenario = xBDD.CurrentRun.AddScenario();
            scenario.GivenAsync(stepName, step => { return Task.Run(() => { }); });
            Assert.Equal("Given My Step", scenario.Steps[0].Name);
        }
        [Fact]
        public async Task InsideStepMethod()
        {
            var stepName = "My Step";
            var scenario = xBDD.CurrentRun.AddScenario();
            scenario.GivenAsync(step => { return Task.Run(() => { step.SetName(stepName); }); });
            await scenario.RunAsync();
            Assert.Equal("Given My Step", scenario.Steps[0].Name);
        }
        [Fact]
        public void WithAttributeOnStepMethod()
        {
            var scenario = xBDD.CurrentRun.AddScenario();
            scenario.GivenAsync(MyStep);
            Assert.Equal("Given My Overridden Step Name", scenario.Steps[0].Name);
        }

        [StepName("My Overridden Step Name")]
        private Task MyStep(IStep step)
        {
            return Task.Run(() => { });
        }
    }
}
