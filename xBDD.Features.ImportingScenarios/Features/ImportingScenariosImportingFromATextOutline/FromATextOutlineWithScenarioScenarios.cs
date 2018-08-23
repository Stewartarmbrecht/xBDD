
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
    public class FromATextOutlineWithScenarioScenarios: FeatureTestClass
    {

        [TestMethod]
        public async Task WithAnEmptyScenario()
        {
            await xB.CurrentRun.AddScenario(this, 23)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithAScenarioWithNoSteps()
        {
            await xB.CurrentRun.AddScenario(this, 24)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithSpecialCharactersInTheScenarioName()
        {
            await xB.CurrentRun.AddScenario(this, 25)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithInvalidIndentedLineAfterScenario()
        {
            await xB.CurrentRun.AddScenario(this, 26)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithScenarioExplanation()
        {
            await xB.CurrentRun.AddScenario(this, 27)
                .Skip("Not Tested", Assert.Inconclusive);
        }
    }
}

