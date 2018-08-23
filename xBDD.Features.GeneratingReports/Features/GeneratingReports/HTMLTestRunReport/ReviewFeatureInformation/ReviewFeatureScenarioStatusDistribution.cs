
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
    public class ReviewFeatureScenarioStatusDistribution: FeatureTestClass
    {

        [TestMethod]
        public async Task WithAllPassing()
        {
            await xB.CurrentRun.AddScenario(this, 149)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithSomeSkipped()
        {
            await xB.CurrentRun.AddScenario(this, 150)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithSomeFailing()
        {
            await xB.CurrentRun.AddScenario(this, 151)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithSomeSkippedAndSomeFailing()
        {
            await xB.CurrentRun.AddScenario(this, 152)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithAllSkipped()
        {
            await xB.CurrentRun.AddScenario(this, 153)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithAllFailing()
        {
            await xB.CurrentRun.AddScenario(this, 154)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithNoScenarios()
        {
            await xB.CurrentRun.AddScenario(this, 155)
                .Skip("Not Tested", Assert.Inconclusive);
        }
    }
}

