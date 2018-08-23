
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
    public class SettingAFeatureLevelOfEffortEstimate: FeatureTestClass
    {

        [TestMethod]
        public async Task Placeholder()
        {
            await xB.CurrentRun.AddScenario(this, 109)
                .Skip("Not Defined", Assert.Inconclusive);
        }
    }
}

