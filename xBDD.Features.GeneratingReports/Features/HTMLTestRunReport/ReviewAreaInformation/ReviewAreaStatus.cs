
namespace xBDD.Features.GeneratingReports.HTMLTestRunReport.ReviewAreaInformation
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
	using System.Threading.Tasks;
	using xBDD;

    [TestClass]
    [AsA("")]
    [YouCan("")]
    [By("")]
    public class ReviewAreaStatus: FeatureTestClass
    {

        [TestMethod]
        public async Task WithPassingStatus()
        {
            await xB.CurrentRun.AddScenario(this, 87)
                .Skip("Untested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithSomeSkippedStatus()
        {
            await xB.CurrentRun.AddScenario(this, 88)
                .Skip("Untested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithSomeFailingStatus()
        {
            await xB.CurrentRun.AddScenario(this, 89)
                .Skip("Untested", Assert.Inconclusive);
        }
    }
}

