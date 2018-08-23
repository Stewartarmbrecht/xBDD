
namespace xBDD.Features.GeneratingReports.GeneratingReports.HTMLTestRunReport.ReviewStepInformation
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
	using System.Threading.Tasks;
	using xBDD;

    [TestClass]
    [AsA("")]
    [YouCan("")]
    [By("")]
    public class ReviewStepStatus: FeatureTestClass
    {

        [TestMethod]
        public async Task WithPassingStatus()
        {
            await xB.CurrentRun.AddScenario(this, 195)
                .Skip("With Passing Status", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithSomeSkippedStatus()
        {
            await xB.CurrentRun.AddScenario(this, 196)
                .Skip("With Some Skipped Status", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithSomeFailingStatus()
        {
            await xB.CurrentRun.AddScenario(this, 197)
                .Skip("With Some Failing Status", Assert.Inconclusive);
        }
    }
}

