
namespace xBDD.Features.GeneratingReports.GeneratingReports.GeneratingaTextTestRunReport
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
	using System.Threading.Tasks;
	using xBDD;

    [TestClass]
    [AsA("")]
    [YouCan("")]
    [By("")]
    public class GenerateATextReportWithAreaScenarios: FeatureTestClass
    {

        [TestMethod]
        public async Task WithFullArea()
        {
            await xB.CurrentRun.AddScenario(this, 308)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithAreaNameClipping()
        {
            await xB.CurrentRun.AddScenario(this, 309)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithAreaNameEmpty()
        {
            await xB.CurrentRun.AddScenario(this, 310)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithAreaExplanationEmpty()
        {
            await xB.CurrentRun.AddScenario(this, 311)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithNoFeatures()
        {
            await xB.CurrentRun.AddScenario(this, 312)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithFeatures()
        {
            await xB.CurrentRun.AddScenario(this, 313)
                .Skip("Not Tested", Assert.Inconclusive);
        }
    }
}

