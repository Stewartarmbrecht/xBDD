
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
    public class FromATextOutlineWithAreaScenarios: FeatureTestClass
    {

        [TestMethod]
        public async Task WithNoTestRunName()
        {
            await xB.CurrentRun.AddScenario(this, 7)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithATestRunWithNoAreas()
        {
            await xB.CurrentRun.AddScenario(this, 8)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithMissingEmptyLineAfterTestRunName()
        {
            await xB.CurrentRun.AddScenario(this, 9)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithAnAreaWithAnEmptyName()
        {
            await xB.CurrentRun.AddScenario(this, 11)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithAnAreaWithNoFeatures()
        {
            await xB.CurrentRun.AddScenario(this, 12)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithSpecialCharactersInTheAreaName()
        {
            await xB.CurrentRun.AddScenario(this, 13)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithInvalidIndentedLineAfterArea()
        {
            await xB.CurrentRun.AddScenario(this, 14)
                .Skip("Not Tested", Assert.Inconclusive);
        }
    }
}

