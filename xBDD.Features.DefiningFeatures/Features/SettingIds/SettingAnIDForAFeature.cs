
namespace xBDD.Features.DefiningFeatures.SettingIds
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
	using System.Threading.Tasks;
	using xBDD;

    [TestClass]
    [AsA("")]
    [YouCan("")]
    [By("")]
    public class SettingAnIDForAFeature: FeatureTestClass
    {

        [TestMethod]
        public async Task ViaAnAttribute()
        {
            await xB.CurrentRun.AddScenario(this, 85)
                .Skip("Not Started", Assert.Inconclusive);
        }
    }
}

