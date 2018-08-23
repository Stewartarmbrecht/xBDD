
namespace xBDD.Features.GeneratingReports.GeneratingReports.HTMLTestRunReport.ReviewTestRunInformation
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
	using System.Threading.Tasks;
	using xBDD;

    [TestClass]
    [AsA("")]
    [YouCan("")]
    [By("")]
    public class ReviewTestRunAreas: FeatureTestClass
    {

        [TestMethod]
        public async Task ExpandingAreas()
        {
            await xB.CurrentRun.AddScenario(this, 79)
                .Skip("Untested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task CollapsingAreas()
        {
            await xB.CurrentRun.AddScenario(this, 80)
                .Skip("Untested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithNoAreas()
        {
            await xB.CurrentRun.AddScenario(this, 81)
                .Skip("Untested", Assert.Inconclusive);
        }
    }
}

