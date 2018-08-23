
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
    public class ReviewFeatureScenarioStatusStatistics: FeatureTestClass
    {

        [TestMethod]
        public async Task Expanding()
        {
            await xB.CurrentRun.AddScenario(this, 161)
                .Skip("Expanding", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task Collapsing()
        {
            await xB.CurrentRun.AddScenario(this, 162)
                .Skip("Collapsing", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithAllPassing()
        {
            await xB.CurrentRun.AddScenario(this, 163)
                .Skip("With All Passing", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithSomeSkipped()
        {
            await xB.CurrentRun.AddScenario(this, 164)
                .Skip("With Some Skipped", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithSomeFailing()
        {
            await xB.CurrentRun.AddScenario(this, 165)
                .Skip("With Some Failing", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithSomeSkippedAndSomeFailing()
        {
            await xB.CurrentRun.AddScenario(this, 166)
                .Skip("With Some Skipped and Some Failing", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithAllSkipped()
        {
            await xB.CurrentRun.AddScenario(this, 167)
                .Skip("With All Skipped", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithAllFailing()
        {
            await xB.CurrentRun.AddScenario(this, 168)
                .Skip("With All Failing", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithNoScenarios()
        {
            await xB.CurrentRun.AddScenario(this, 169)
                .Skip("With No Scenarios", Assert.Inconclusive);
        }
    }
}

