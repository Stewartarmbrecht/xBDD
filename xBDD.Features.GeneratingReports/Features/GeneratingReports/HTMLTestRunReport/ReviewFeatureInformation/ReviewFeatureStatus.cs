
namespace xBDD.Features.GeneratingReports.GeneratingReports.HTMLTestRunReport.ReviewFeatureInformation
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
	using System.Threading.Tasks;
	using xBDD;

    [TestClass]
    [AsA("")]
    [YouCan("")]
    [By("")]
    public class ReviewFeatureStatus: FeatureTestClass
    {

        [TestMethod]
        public async Task WithPassingStatus()
        {
            await xB.CurrentRun.AddScenario(this, 139)
                .Skip("With Passing Status", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithSomeSkippedStatus()
        {
            await xB.CurrentRun.AddScenario(this, 140)
                .Skip("With Some Skipped Status", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithSomeFailingStatus()
        {
            await xB.CurrentRun.AddScenario(this, 141)
                .Skip("With Some Failing Status", Assert.Inconclusive);
        }
    }
}

