
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
    public class ReviewTestRunStatus: FeatureTestClass
    {

        [TestMethod]
        public async Task WithPassingStatus()
        {
            await xB.CurrentRun.AddScenario(this, 27)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithSomeSkippedStatus()
        {
            await xB.CurrentRun.AddScenario(this, 28)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithSomeFailingStatus()
        {
            await xB.CurrentRun.AddScenario(this, 29)
                .Skip("Not Tested", Assert.Inconclusive);
        }
    }
}

