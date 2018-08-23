
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
    public class AddingTagsToAScenario: FeatureTestClass
    {

        [TestMethod]
        public async Task InCode()
        {
            await xB.CurrentRun.AddScenario(this, 114)
                .Skip("Definig", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task ViaAnAttribute()
        {
            await xB.CurrentRun.AddScenario(this, 115)
                .Skip("Definig", Assert.Inconclusive);
        }
    }
}

