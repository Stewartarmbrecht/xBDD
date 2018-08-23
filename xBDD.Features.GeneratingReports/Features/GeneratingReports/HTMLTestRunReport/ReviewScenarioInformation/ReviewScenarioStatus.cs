
namespace xBDD.Features.GeneratingReports.GeneratingReports.HTMLTestRunReport.ReviewScenarioInformation
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
	using System.Threading.Tasks;
	using xBDD;

    [TestClass]
    [AsA("")]
    [YouCan("")]
    [By("")]
    public class ReviewScenarioStatus: FeatureTestClass
    {

        [TestMethod]
        public async Task WithPassingStatus()
        {
            await xB.CurrentRun.AddScenario(this, 183)
                .Skip("With Passing Status", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithSomeSkippedStatus()
        {
            await xB.CurrentRun.AddScenario(this, 184)
                .Skip("With Some Skipped Status", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithSomeFailingStatus()
        {
            await xB.CurrentRun.AddScenario(this, 185)
                .Skip("With Some Failing Status", Assert.Inconclusive);
        }
    }
}

