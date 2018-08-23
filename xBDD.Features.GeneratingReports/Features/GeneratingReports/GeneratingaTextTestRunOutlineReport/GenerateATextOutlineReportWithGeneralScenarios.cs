
namespace xBDD.Features.GeneratingReports.GeneratingReports.GeneratingaTextTestRunOutlineReport
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
	using System.Threading.Tasks;
	using xBDD;

    [TestClass]
    [AsA("")]
    [YouCan("")]
    [By("")]
    public class GenerateATextOutlineReportWithGeneralScenarios: FeatureTestClass
    {

        [TestMethod]
        public async Task WithFullTestRun()
        {
            await xB.CurrentRun.AddScenario(this, 336)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithEmptyTestRun()
        {
            await xB.CurrentRun.AddScenario(this, 337)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithNoScenarios()
        {
            await xB.CurrentRun.AddScenario(this, 338)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithNoTestsInTheProject()
        {
            await xB.CurrentRun.AddScenario(this, 339)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithTestFiltering()
        {
            await xB.CurrentRun.AddScenario(this, 340)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithXBDDTestRunFiltering()
        {
            await xB.CurrentRun.AddScenario(this, 341)
                .Skip("Not Tested", Assert.Inconclusive);
        }
    }
}

