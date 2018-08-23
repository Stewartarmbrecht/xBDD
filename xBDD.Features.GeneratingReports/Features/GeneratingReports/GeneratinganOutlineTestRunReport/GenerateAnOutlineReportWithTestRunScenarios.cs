
namespace xBDD.Features.GeneratingReports.GeneratingReports.GeneratinganOutlineTestRunReport
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
	using System.Threading.Tasks;
	using xBDD;

    [TestClass]
    [AsA("")]
    [YouCan("")]
    [By("")]
    public class GenerateAnOutlineReportWithTestRunScenarios: FeatureTestClass
    {

        [TestMethod]
        public async Task WithFullTestRun()
        {
            await xB.CurrentRun.AddScenario(this, 261)
                .Skip("With Full Test Run", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithNoTestRunName()
        {
            await xB.CurrentRun.AddScenario(this, 262)
                .Skip("With No Test Run Name", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithTestRunExplanationEmpty()
        {
            await xB.CurrentRun.AddScenario(this, 263)
                .Skip("With Test Run Explanation Empty", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithNoAreas()
        {
            await xB.CurrentRun.AddScenario(this, 264)
                .Skip("With No Areas", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithAreas()
        {
            await xB.CurrentRun.AddScenario(this, 265)
                .Skip("With Areas", Assert.Inconclusive);
        }
    }
}

