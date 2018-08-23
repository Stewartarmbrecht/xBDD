
namespace xBDD.Features.DefiningFeatures.InitialSetup
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
	using System.Threading.Tasks;
	using xBDD;

    [TestClass]
    [AsA("")]
    [YouCan("")]
    [By("")]
    public class SettingTheScenarioOutcome: FeatureTestClass
    {

        [TestMethod]
        public async Task FailingAScenario()
        {
            await xB.CurrentRun.AddScenario(this, 27)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task SkippingAScenario()
        {
            await xB.CurrentRun.AddScenario(this, 28)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task DocumentingAScenario()
        {
            await xB.CurrentRun.AddScenario(this, 29)
                .Skip("Not Tested", Assert.Inconclusive);
        }
    }
}

