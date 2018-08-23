
namespace xBDD.Features.GeneratingReports.GeneratingReports.HTMLTestRunReport.ReviewAreaInformation
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
	using System.Threading.Tasks;
	using xBDD;

    [TestClass]
    [AsA("")]
    [YouCan("")]
    [By("")]
    public class ReviewAreaFeatures: FeatureTestClass
    {

        [TestMethod]
        public async Task ExpandingFeatures()
        {
            await xB.CurrentRun.AddScenario(this, 131)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task CollapsingFeatures()
        {
            await xB.CurrentRun.AddScenario(this, 132)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithoutFeatures()
        {
            await xB.CurrentRun.AddScenario(this, 133)
                .Skip("Not Tested", Assert.Inconclusive);
        }
    }
}

