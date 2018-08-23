
namespace xBDD.Features.DefiningFeatures.DefiningScenarios
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
	using System.Threading.Tasks;
	using xBDD;

    [TestClass]
    [AsA("")]
    [YouCan("")]
    [By("")]
    public class SettingTheDefaultReportingSortForAScenario: FeatureTestClass
    {

        [TestMethod]
        public async Task SettingTheSortOnAllScenarios()
        {
            await xB.CurrentRun.AddScenario(this, 55)
                .Skip("Untested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task SettingTheSortOnNoneOfTheScenarios()
        {
            await xB.CurrentRun.AddScenario(this, 56)
                .Skip("Untested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task SettingTheSortOnSomeOfTheScenarios()
        {
            await xB.CurrentRun.AddScenario(this, 57)
                .Skip("Untested", Assert.Inconclusive);
        }
    }
}

