
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
    public class AddingAnExplanationToATestRun: FeatureTestClass
    {

        [TestMethod]
        public async Task ViaAnAttributeWithInlineText()
        {
            await xB.CurrentRun.AddScenario(this, 145)
                .Skip("Defining", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task ViaAnAttributeWithAFileReference()
        {
            await xB.CurrentRun.AddScenario(this, 146)
                .Skip("Defining", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task UsingPlainText()
        {
            await xB.CurrentRun.AddScenario(this, 147)
                .Skip("Defining", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task UsingMarkdown()
        {
            await xB.CurrentRun.AddScenario(this, 148)
                .Skip("Defining", Assert.Inconclusive);
        }
    }
}

