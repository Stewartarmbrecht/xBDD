
namespace xBDD.Features.DefiningFeatures.AddingEstimates
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
	using System.Threading.Tasks;
	using xBDD;

    [TestClass]
    [AsA("")]
    [YouCan("")]
    [By("")]
    public class SettingAAreaEstimatesUsingAPlaceholderFeature: FeatureTestClass
    {

        [TestMethod]
        public async Task Placeholder()
        {
            await xB.CurrentRun.AddScenario(this, 111)
                .Skip("Definig", Assert.Inconclusive);
        }
    }
}

