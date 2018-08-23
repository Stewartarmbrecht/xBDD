
namespace xBDD.Features.ImportingScenarios.ImportingScenariosImportingFromATextOutline
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
	using System.Threading.Tasks;
	using xBDD;

    [TestClass]
    [AsA("")]
    [YouCan("")]
    [By("")]
    public class FromATextOutlineWithFeatureScenarios: FeatureTestClass
    {

        [TestMethod]
        public async Task WithAnFeatureWithAnEmptyName()
        {
            await xB.CurrentRun.AddScenario(this, 16)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithAFeatureWithNoScenarios()
        {
            await xB.CurrentRun.AddScenario(this, 17)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithSpecialCharactersInTheFeatureName()
        {
            await xB.CurrentRun.AddScenario(this, 18)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithInvalidIndentedLineAfterFeature()
        {
            await xB.CurrentRun.AddScenario(this, 19)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithFeatureStatement()
        {
            await xB.CurrentRun.AddScenario(this, 20)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithFeatureExplanation()
        {
            await xB.CurrentRun.AddScenario(this, 21)
                .Skip("Not Tested", Assert.Inconclusive);
        }
    }
}

