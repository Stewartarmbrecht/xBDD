
namespace xBDD.Features.GeneratingReports.GeneratingReports.GeneratingaJSONTestRunReport
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
	using System.Threading.Tasks;
	using xBDD;

    [TestClass]
    [AsA("")]
    [YouCan("")]
    [By("")]
    public class GenerateAJsonReportWithGeneralScenarios: FeatureTestClass
    {

        [TestMethod]
        public async Task WithFullTestRun()
        {
            await xB.CurrentRun.AddScenario(this, 213)
                .Skip("With Full Test Run", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithEmptyTestRun()
        {
            await xB.CurrentRun.AddScenario(this, 214)
                .Skip("With Empty Test Run", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithNoScenarios()
        {
            await xB.CurrentRun.AddScenario(this, 215)
                .Skip("With No Scenarios", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithNoTestsInTheProject()
        {
            await xB.CurrentRun.AddScenario(this, 216)
                .Skip("With No Tests in the Project", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithTestFiltering()
        {
            await xB.CurrentRun.AddScenario(this, 217)
                .Skip("With Test Filtering", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithXBDDTestRunFiltering()
        {
            await xB.CurrentRun.AddScenario(this, 218)
                .Skip("With xBDD Test Run Filtering", Assert.Inconclusive);
        }
    }
}

