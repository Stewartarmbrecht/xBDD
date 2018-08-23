
namespace xBDD.Features.DefiningFeatures.DefiningATestRun
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
	using System.Threading.Tasks;
	using xBDD;

    [TestClass]
    [AsA("")]
    [YouCan("")]
    [By("")]
    public class SettingTheTestRunName: FeatureTestClass
    {

        [TestMethod]
        public async Task ViaCode()
        {
            await xB.CurrentRun.AddScenario(this, 77)
                .Skip("Untested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task ViaAnEnvironmentVariable()
        {
            await xB.CurrentRun.AddScenario(this, 78)
                .Skip("Untested", Assert.Inconclusive);
        }
    }
}

