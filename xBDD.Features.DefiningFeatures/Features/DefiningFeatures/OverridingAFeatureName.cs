
namespace xBDD.Features.DefiningFeatures.DefiningFeatures
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
	using System.Threading.Tasks;
	using xBDD;

    [TestClass]
    [AsA("")]
    [YouCan("")]
    [By("")]
    public class OverridingAFeatureName: FeatureTestClass
    {

        [TestMethod]
        public async Task WhenAddingAScenario()
        {
            await xB.CurrentRun.AddScenario(this, 68)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task ViaAnAttribute()
        {
            await xB.CurrentRun.AddScenario(this, 69)
                .Skip("Not Tested", Assert.Inconclusive);
        }
    }
}

