
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
    public class AddingAnExplanationToAStep: FeatureTestClass
    {

        [TestMethod]
        public async Task StraightTexts()
        {
            await xB.CurrentRun.AddScenario(this, 127)
                .Skip("Definig", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task LeveragingMarkdown()
        {
            await xB.CurrentRun.AddScenario(this, 128)
                .Skip("Definig", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task AddingReferenecesToOtherFeatures()
        {
            await xB.CurrentRun.AddScenario(this, 129)
                .Skip("Definig", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task AddingReferenecesToOtherScenarios()
        {
            await xB.CurrentRun.AddScenario(this, 130)
                .Skip("Definig", Assert.Inconclusive);
        }
    }
}

