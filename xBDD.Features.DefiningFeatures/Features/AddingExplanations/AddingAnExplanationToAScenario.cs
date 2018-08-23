
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
    public class AddingAnExplanationToAScenario: FeatureTestClass
    {

        [TestMethod]
        public async Task UsingPlainText()
        {
            await xB.CurrentRun.AddScenario(this, 132)
                .Skip("Defining", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task UsingMarkdown()
        {
            await xB.CurrentRun.AddScenario(this, 133)
                .Skip("Defining", Assert.Inconclusive);
        }
    }
}

