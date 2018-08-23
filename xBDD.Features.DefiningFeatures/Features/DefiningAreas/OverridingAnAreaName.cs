
namespace xBDD.Features.DefiningFeatures.DefiningAreas
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
	using System.Threading.Tasks;
	using xBDD;

    [TestClass]
    [AsA("")]
    [YouCan("")]
    [By("")]
    public class OverridingAnAreaName: FeatureTestClass
    {

        [TestMethod]
        public async Task WhenCreatingAScenario()
        {
            await xB.CurrentRun.AddScenario(this, 72)
                .Skip("Untested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task ForASingleFeatureViaAttribute()
        {
            await xB.CurrentRun.AddScenario(this, 73)
                .Skip("Untested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task ForANamespace()
        {
            await xB.CurrentRun.AddScenario(this, 74)
                .Skip("Untested", Assert.Inconclusive);
        }
    }
}

