
namespace xBDD.Features.DefiningFeatures.SettingStatus
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
	using System.Threading.Tasks;
	using xBDD;

    [TestClass]
    [AsA("")]
    [YouCan("")]
    [By("")]
    public class SettingTheStatusOfAFeature: FeatureTestClass
    {

        [TestMethod]
        public async Task ToDefining()
        {
            await xB.CurrentRun.AddScenario(this, 100)
                .Skip("Definig", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task ToReady()
        {
            await xB.CurrentRun.AddScenario(this, 101)
                .Skip("Definig", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task ToBuilding()
        {
            await xB.CurrentRun.AddScenario(this, 102)
                .Skip("Definig", Assert.Inconclusive);
        }
    }
}

