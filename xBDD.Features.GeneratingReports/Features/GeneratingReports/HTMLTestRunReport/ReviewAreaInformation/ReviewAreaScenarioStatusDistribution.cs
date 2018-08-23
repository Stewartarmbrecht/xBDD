
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
    public class ReviewAreaScenarioStatusDistribution: FeatureTestClass
    {

        [TestMethod]
        public async Task WithAllPassing()
        {
            await xB.CurrentRun.AddScenario(this, 99)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithSomeSkipped()
        {
            await xB.CurrentRun.AddScenario(this, 100)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithSomeFailing()
        {
            await xB.CurrentRun.AddScenario(this, 101)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithSomeSkippedAndSomeFailing()
        {
            await xB.CurrentRun.AddScenario(this, 102)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithAllSkipped()
        {
            await xB.CurrentRun.AddScenario(this, 103)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithAllFailing()
        {
            await xB.CurrentRun.AddScenario(this, 104)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithNoScenarios()
        {
            await xB.CurrentRun.AddScenario(this, 105)
                .Skip("Not Tested", Assert.Inconclusive);
        }
    }
}

