
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
    public class SettingAnOutputWriterForAScenario: FeatureTestClass
    {

        [TestMethod]
        public async Task WhenCreatingAScenario()
        {
            await xB.CurrentRun.AddScenario(this, 52)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WhenCreatingAFeature()
        {
            await xB.CurrentRun.AddScenario(this, 53)
                .Skip("Not Tested", Assert.Inconclusive);
        }
    }
}

