
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
    public class ReviewAreaName: FeatureTestClass
    {

        [TestMethod]
        public async Task WithName()
        {
            await xB.CurrentRun.AddScenario(this, 84)
                .Skip("With Name", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithNoName()
        {
            await xB.CurrentRun.AddScenario(this, 85)
                .Skip("With No Name", Assert.Inconclusive);
        }
    }
}

