
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
                .Skip("With no Test Run Name", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithATestRunWithNoAreas()
        {
            await xB.CurrentRun.AddScenario(this, 8)
                .Skip("With a test run with no areas", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithMissingEmptyLineAfterTestRunName()
        {
            await xB.CurrentRun.AddScenario(this, 9)
                .Skip("With missing empty line after test run name", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithAnAreaWithAnEmptyName()
        {
            await xB.CurrentRun.AddScenario(this, 11)
                .Skip("With an area with an empty name", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithAnAreaWithNoFeatures()
        {
            await xB.CurrentRun.AddScenario(this, 12)
                .Skip("With an area with no features", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithSpecialCharactersInTheAreaName()
        {
            await xB.CurrentRun.AddScenario(this, 13)
                .Skip("With special characters in the Area name", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithInvalidIndentedLineAfterArea()
        {
            await xB.CurrentRun.AddScenario(this, 14)
                .Skip("With invalid indented line after Area", Assert.Inconclusive);
        }
    }
}

