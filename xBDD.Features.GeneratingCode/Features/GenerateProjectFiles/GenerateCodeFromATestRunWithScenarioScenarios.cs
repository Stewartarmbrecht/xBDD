
namespace xBDD.Features.GeneratingCode.GenerateProjectFiles
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
	using System.Threading.Tasks;
	using xBDD;

    [TestClass]
    [AsA("")]
    [YouCan("")]
    [By("")]
    public class GenerateCodeFromATestRunWithScenarioScenarios: FeatureTestClass
    {

        [TestMethod]
        public async Task WithFullScenario()
        {
            await xB.CurrentRun.AddScenario(this, 38)
                .Skip("Untested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithScenarioNameEmpty()
        {
            await xB.CurrentRun.AddScenario(this, 39)
                .Skip("Untested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithScenarioExplanationEmpty()
        {
            await xB.CurrentRun.AddScenario(this, 40)
                .Skip("Untested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithNoSteps()
        {
            await xB.CurrentRun.AddScenario(this, 41)
                .Skip("Untested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithSteps()
        {
            await xB.CurrentRun.AddScenario(this, 42)
                .Skip("Untested", Assert.Inconclusive);
        }
    }
}

