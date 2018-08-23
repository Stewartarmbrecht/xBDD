
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
    public class ReviewAreaFeatureStatusStatistics: FeatureTestClass
    {

        [TestMethod]
        public async Task Expanding()
        {
            await xB.CurrentRun.AddScenario(this, 107)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task Collapsing()
        {
            await xB.CurrentRun.AddScenario(this, 108)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithAllPassing()
        {
            await xB.CurrentRun.AddScenario(this, 109)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithSomeSkipped()
        {
            await xB.CurrentRun.AddScenario(this, 110)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithSomeFailing()
        {
            await xB.CurrentRun.AddScenario(this, 111)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithSomeSkippedAndSomeFailing()
        {
            await xB.CurrentRun.AddScenario(this, 112)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithAllSkipped()
        {
            await xB.CurrentRun.AddScenario(this, 113)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithAllFailing()
        {
            await xB.CurrentRun.AddScenario(this, 114)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithNoFeatures()
        {
            await xB.CurrentRun.AddScenario(this, 115)
                .Skip("Not Tested", Assert.Inconclusive);
        }
    }
}

