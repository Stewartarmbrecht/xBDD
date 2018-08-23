
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
                .Skip("With an feature with an empty name", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithAFeatureWithNoScenarios()
        {
            await xB.CurrentRun.AddScenario(this, 17)
                .Skip("With a feature with no scenarios", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithSpecialCharactersInTheFeatureName()
        {
            await xB.CurrentRun.AddScenario(this, 18)
                .Skip("With special characters in the Feature name", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithInvalidIndentedLineAfterFeature()
        {
            await xB.CurrentRun.AddScenario(this, 19)
                .Skip("With invalid indented line after feature", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithFeatureStatement()
        {
            await xB.CurrentRun.AddScenario(this, 20)
                .Skip("With Feature Statement", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithFeatureExplanation()
        {
            await xB.CurrentRun.AddScenario(this, 21)
                .Skip("With Feature Explanation", Assert.Inconclusive);
        }
    }
}

