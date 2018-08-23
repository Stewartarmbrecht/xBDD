
namespace xBDD.Features.GeneratingReports.GeneratingReports.HTMLTestRunReport.Generating
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
	using System.Threading.Tasks;
	using xBDD;

    [TestClass]
    [AsA("")]
    [YouCan("")]
    [By("")]
    public class GenerateAReport: FeatureTestClass
    {

        [TestMethod]
        public async Task WithFullTestRun()
        {
            await xB.CurrentRun.AddScenario(this, 4)
                .Skip("With Full Test Run", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithEmptyTestRun()
        {
            await xB.CurrentRun.AddScenario(this, 5)
                .Skip("With Empty Test Run", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithNoScenarios()
        {
            await xB.CurrentRun.AddScenario(this, 6)
                .Skip("With No Scenarios", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithNoTestsInTheProject()
        {
            await xB.CurrentRun.AddScenario(this, 7)
                .Skip("With No Tests in the Project", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithNoName()
        {
            await xB.CurrentRun.AddScenario(this, 8)
                .Skip("With No Name", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task AsABacklogReport()
        {
            await xB.CurrentRun.AddScenario(this, 9)
                .Skip("As a Backlog Report", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task AsAWIPReport()
        {
            await xB.CurrentRun.AddScenario(this, 10)
                .Skip("As a WIP Report", Assert.Inconclusive);
        }
    }
}

