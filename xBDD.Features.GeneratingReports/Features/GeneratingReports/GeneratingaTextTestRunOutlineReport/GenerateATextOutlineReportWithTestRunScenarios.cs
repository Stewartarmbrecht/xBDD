
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
    public class GenerateATextOutlineReportWithTestRunScenarios: FeatureTestClass
    {

        [TestMethod]
        public async Task WithFullTestRun()
        {
            await xB.CurrentRun.AddScenario(this, 343)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithNoTestRunName()
        {
            await xB.CurrentRun.AddScenario(this, 344)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithTestRunExplanationEmpty()
        {
            await xB.CurrentRun.AddScenario(this, 345)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithNoAreas()
        {
            await xB.CurrentRun.AddScenario(this, 346)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithAreas()
        {
            await xB.CurrentRun.AddScenario(this, 347)
                .Skip("Not Tested", Assert.Inconclusive);
        }
    }
}

