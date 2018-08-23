
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
    public class GenerateATextOutlineReportWithAreaScenarios: FeatureTestClass
    {

        [TestMethod]
        public async Task WithFullArea()
        {
            await xB.CurrentRun.AddScenario(this, 349)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithAreaNameClipping()
        {
            await xB.CurrentRun.AddScenario(this, 350)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithAreaNameEmpty()
        {
            await xB.CurrentRun.AddScenario(this, 351)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithAreaExplanationEmpty()
        {
            await xB.CurrentRun.AddScenario(this, 352)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithNoFeatures()
        {
            await xB.CurrentRun.AddScenario(this, 353)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithFeatures()
        {
            await xB.CurrentRun.AddScenario(this, 354)
                .Skip("Not Tested", Assert.Inconclusive);
        }
    }
}

