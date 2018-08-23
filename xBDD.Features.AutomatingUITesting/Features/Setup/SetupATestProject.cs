
namespace xBDD.Features.AutomatingUITesting.Setup
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
	using System.Threading.Tasks;
	using xBDD;

    [TestClass]
    [AsA("")]
    [YouCan("")]
    [By("")]
    public class SetupATestProject: FeatureTestClass
    {

        [TestMethod]
        public async Task ToUseNewBrowserSessionsForEachScenario()
        {
            await xB.CurrentRun.AddScenario(this, 4)
                .Skip("Untested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task ToUseTheSameBrowserSessionForAllScenarios()
        {
            await xB.CurrentRun.AddScenario(this, 5)
                .Skip("Untested", Assert.Inconclusive);
        }
    }
}

