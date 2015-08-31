using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace xBDD.Test.Stories
{
    [FeatureName("Override Feature Name - Overridden")]
    public class OverrideFeatureName
    {
        [Fact]
        public void WithFeatureNameAttribute()
        {
            var scenario = TestRun.Current.AddScenario();
            Assert.Equal("Override Feature Name - Overridden", scenario.FeatureName);
        }
        [Fact]
        public void WhenAddingScenario()
        {
            var featureName = "New Feature Name";
            var scenario = TestRun.Current.AddScenario(null, featureName);
            Assert.Equal(featureName, scenario.FeatureName);
        }
    }
}
