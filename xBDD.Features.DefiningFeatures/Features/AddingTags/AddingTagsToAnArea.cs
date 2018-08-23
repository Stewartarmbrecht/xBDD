
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
    public class AddingTagsToAnArea: FeatureTestClass
    {

        [TestMethod]
        public async Task ViaCode()
        {
            await xB.CurrentRun.AddScenario(this, 120)
                .Skip("Defining", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task ViaAnAssemblyAttribute()
        {
            await xB.CurrentRun.AddScenario(this, 121)
                .Skip("Defining", Assert.Inconclusive);
        }
    }
}

