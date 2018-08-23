
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
    public class GenerateAnOutlineReportWithAreaScenarios: FeatureTestClass
    {

        [TestMethod]
        public async Task WithFullArea()
        {
            await xB.CurrentRun.AddScenario(this, 267)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithAreaNameClipping()
        {
            await xB.CurrentRun.AddScenario(this, 268)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithAreaNameEmpty()
        {
            await xB.CurrentRun.AddScenario(this, 269)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithAreaExplanationEmpty()
        {
            await xB.CurrentRun.AddScenario(this, 270)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithNoFeatures()
        {
            await xB.CurrentRun.AddScenario(this, 271)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithFeatures()
        {
            await xB.CurrentRun.AddScenario(this, 272)
                .Skip("Not Tested", Assert.Inconclusive);
        }
    }
}

