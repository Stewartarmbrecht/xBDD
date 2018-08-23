
namespace xBDD.Features.DefiningFeatures.AddingTags
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
	using System.Threading.Tasks;
	using xBDD;

    [TestClass]
    [AsA("")]
    [YouCan("")]
    [By("")]
    public class AddingTagsToAFeature: FeatureTestClass
    {

        [TestMethod]
        public async Task InCode()
        {
            await xB.CurrentRun.AddScenario(this, 117)
                .Skip("Defining", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task ViaAnAttribute()
        {
            await xB.CurrentRun.AddScenario(this, 118)
                .Skip("Defining", Assert.Inconclusive);
        }
    }
}

