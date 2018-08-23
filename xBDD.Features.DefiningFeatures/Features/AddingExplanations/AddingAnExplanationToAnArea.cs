
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
    public class AddingAnExplanationToAnArea: FeatureTestClass
    {

        [TestMethod]
        public async Task ViaAnAttributeWithInlineText()
        {
            await xB.CurrentRun.AddScenario(this, 140)
                .Skip("Definig", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task ViaAnAttributeWithAFileReference()
        {
            await xB.CurrentRun.AddScenario(this, 141)
                .Skip("Definig", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task UsingPlainText()
        {
            await xB.CurrentRun.AddScenario(this, 142)
                .Skip("Definig", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task UsingMarkdown()
        {
            await xB.CurrentRun.AddScenario(this, 143)
                .Skip("Definig", Assert.Inconclusive);
        }
    }
}

