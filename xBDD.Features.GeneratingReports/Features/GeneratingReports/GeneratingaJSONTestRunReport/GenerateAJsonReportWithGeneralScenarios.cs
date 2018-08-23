
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
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithEmptyTestRun()
        {
            await xB.CurrentRun.AddScenario(this, 214)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithNoScenarios()
        {
            await xB.CurrentRun.AddScenario(this, 215)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithNoTestsInTheProject()
        {
            await xB.CurrentRun.AddScenario(this, 216)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithTestFiltering()
        {
            await xB.CurrentRun.AddScenario(this, 217)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithXBDDTestRunFiltering()
        {
            await xB.CurrentRun.AddScenario(this, 218)
                .Skip("Not Tested", Assert.Inconclusive);
        }
    }
}

