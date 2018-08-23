
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
    public class GenerateAnOutlineReportWithGeneralScenarios: FeatureTestClass
    {

        [TestMethod]
        public async Task WithFullTestRun()
        {
            await xB.CurrentRun.AddScenario(this, 254)
                .Skip("With Full Test Run", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithEmptyTestRun()
        {
            await xB.CurrentRun.AddScenario(this, 255)
                .Skip("With Empty Test Run", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithNoScenarios()
        {
            await xB.CurrentRun.AddScenario(this, 256)
                .Skip("With No Scenarios", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithNoTestsInTheProject()
        {
            await xB.CurrentRun.AddScenario(this, 257)
                .Skip("With No Tests in the Project", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithTestFiltering()
        {
            await xB.CurrentRun.AddScenario(this, 258)
                .Skip("With Test Filtering", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithXBDDTestRunFiltering()
        {
            await xB.CurrentRun.AddScenario(this, 259)
                .Skip("With xBDD Test Run Filtering", Assert.Inconclusive);
        }
    }
}

