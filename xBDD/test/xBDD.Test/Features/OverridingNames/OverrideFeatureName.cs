using Xunit;

namespace xBDD.Test.Features.OverridingNames
{
    [FeatureName("Override Feature Name - Overridden")]
    public class OverrideFeatureName
    {
        [Fact]
        public void WithFeatureNameAttribute()
        {
            var scenario = xBDD.CurrentRun.AddScenario();
            Assert.Equal("Override Feature Name - Overridden", scenario.FeatureName);
        }
        [Fact]
        public void WhenAddingScenario()
        {
            var featureName = "New Feature Name";
            var scenario = xBDD.CurrentRun.AddScenario(null, featureName);
            Assert.Equal(featureName, scenario.FeatureName);
        }
    }
}
