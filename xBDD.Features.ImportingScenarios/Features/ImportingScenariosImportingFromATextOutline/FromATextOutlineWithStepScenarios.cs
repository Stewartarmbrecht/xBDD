
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
    public class FromATextOutlineWithStepScenarios: FeatureTestClass
    {

        [TestMethod]
        public async Task WithAStepWithAnEmptyName()
        {
            await xB.CurrentRun.AddScenario(this, 29)
                .Skip("With a step with an empty name", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithSpecialCharactersInTheStepName()
        {
            await xB.CurrentRun.AddScenario(this, 30)
                .Skip("With special characters in the step name", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithInvalidIndentedLineAfterScenario()
        {
            await xB.CurrentRun.AddScenario(this, 31)
                .Skip("With invalid indented line after scenario", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithScenarioExplanation()
        {
            await xB.CurrentRun.AddScenario(this, 32)
                .Skip("With scenario explanation", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithScenarioInput()
        {
            await xB.CurrentRun.AddScenario(this, 33)
                .Skip("With scenario input", Assert.Inconclusive);
        }
    }
}

