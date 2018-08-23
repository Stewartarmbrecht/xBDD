
namespace xBDD.Features.DefiningFeatures.AddingExplanations
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
	using System.Threading.Tasks;
	using xBDD;

    [TestClass]
    [AsA("")]
    [YouCan("")]
    [By("")]
    public class AddingAnExplanationToAFeature: FeatureTestClass
    {

        [TestMethod]
        public async Task ViaAnAttributeWithInlineText()
        {
            await xB.CurrentRun.AddScenario(this, 135)
                .Skip("Not Defined", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task ViaAnAttributeWithAFileReference()
        {
            await xB.CurrentRun.AddScenario(this, 136)
                .Skip("Not Defined", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task UsingPlainText()
        {
            await xB.CurrentRun.AddScenario(this, 137)
                .Skip("Not Defined", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task UsingMarkdown()
        {
            await xB.CurrentRun.AddScenario(this, 138)
                .Skip("Not Defined", Assert.Inconclusive);
        }
    }
}

