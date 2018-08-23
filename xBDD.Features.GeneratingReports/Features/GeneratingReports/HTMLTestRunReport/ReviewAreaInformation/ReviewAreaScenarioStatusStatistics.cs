
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
    public class ReviewAreaScenarioStatusStatistics: FeatureTestClass
    {

        [TestMethod]
        public async Task Expanding()
        {
            await xB.CurrentRun.AddScenario(this, 117)
                .Skip("Expanding", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task Collapsing()
        {
            await xB.CurrentRun.AddScenario(this, 118)
                .Skip("Collapsing", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithAllPassing()
        {
            await xB.CurrentRun.AddScenario(this, 119)
                .Skip("With All Passing", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithSomeSkipped()
        {
            await xB.CurrentRun.AddScenario(this, 120)
                .Skip("With Some Skipped", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithSomeFailing()
        {
            await xB.CurrentRun.AddScenario(this, 121)
                .Skip("With Some Failing", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithSomeSkippedAndSomeFailing()
        {
            await xB.CurrentRun.AddScenario(this, 122)
                .Skip("With Some Skipped and Some Failing", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithAllSkipped()
        {
            await xB.CurrentRun.AddScenario(this, 123)
                .Skip("With All Skipped", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithAllFailing()
        {
            await xB.CurrentRun.AddScenario(this, 124)
                .Skip("With All Failing", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithNoScenarios()
        {
            await xB.CurrentRun.AddScenario(this, 125)
                .Skip("With No Scenarios", Assert.Inconclusive);
        }
    }
}

