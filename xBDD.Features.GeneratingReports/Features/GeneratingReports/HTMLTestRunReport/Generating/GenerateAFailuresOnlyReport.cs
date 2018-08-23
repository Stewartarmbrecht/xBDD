
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
    public class GenerateAFailuresOnlyReport: FeatureTestClass
    {

        [TestMethod]
        public async Task WithFailures()
        {
            await xB.CurrentRun.AddScenario(this, 12)
                .Skip("Untested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithEmptyTestRun()
        {
            await xB.CurrentRun.AddScenario(this, 13)
                .Skip("Untested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithNoFailures()
        {
            await xB.CurrentRun.AddScenario(this, 14)
                .Skip("Untested", Assert.Inconclusive);
        }
    }
}

