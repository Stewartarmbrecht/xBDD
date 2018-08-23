
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
    public class SettingTheStatusOfAScenario: FeatureTestClass
    {

        [TestMethod]
        public async Task ToDefining()
        {
            await xB.CurrentRun.AddScenario(this, 88)
                .Skip("Defining", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task ToReady()
        {
            await xB.CurrentRun.AddScenario(this, 89)
                .Skip("Defining", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task ToBuilding()
        {
            await xB.CurrentRun.AddScenario(this, 90)
                .Skip("Defining", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task ToUntested()
        {
            await xB.CurrentRun.AddScenario(this, 91)
                .Skip("Defining", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task ToFailing()
        {
            await xB.CurrentRun.AddScenario(this, 92)
                .Skip("Defining", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task ToWaiting()
        {
            await xB.CurrentRun.AddScenario(this, 93)
                .Skip("Defining", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task ToFixing()
        {
            await xB.CurrentRun.AddScenario(this, 94)
                .Skip("Defining", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task ToBuilt()
        {
            await xB.CurrentRun.AddScenario(this, 95)
                .Skip("Defining", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task ToDeployed()
        {
            await xB.CurrentRun.AddScenario(this, 96)
                .Skip("Defining", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task ToExecuting()
        {
            await xB.CurrentRun.AddScenario(this, 97)
                .Skip("Defining", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task ToDeprecated()
        {
            await xB.CurrentRun.AddScenario(this, 98)
                .Skip("Defining", Assert.Inconclusive);
        }
    }
}

