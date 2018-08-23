
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
    public class GenerateCodeFromATestRunWithAreaScenarios: FeatureTestClass
    {

        [TestMethod]
        public async Task WithFullArea()
        {
            await xB.CurrentRun.AddScenario(this, 25)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithAreaNameClipping()
        {
            await xB.CurrentRun.AddScenario(this, 26)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithAreaNameEmpty()
        {
            await xB.CurrentRun.AddScenario(this, 27)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithAreaExplanationEmpty()
        {
            await xB.CurrentRun.AddScenario(this, 28)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithNoFeatures()
        {
            await xB.CurrentRun.AddScenario(this, 29)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithFeatures()
        {
            await xB.CurrentRun.AddScenario(this, 30)
                .Skip("Not Tested", Assert.Inconclusive);
        }
    }
}

