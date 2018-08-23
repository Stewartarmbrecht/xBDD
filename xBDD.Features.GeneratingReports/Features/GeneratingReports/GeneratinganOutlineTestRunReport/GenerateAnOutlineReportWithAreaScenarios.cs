
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
                .Skip("With Full Area", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithAreaNameClipping()
        {
            await xB.CurrentRun.AddScenario(this, 268)
                .Skip("With Area Name Clipping", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithAreaNameEmpty()
        {
            await xB.CurrentRun.AddScenario(this, 269)
                .Skip("With Area Name Empty", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithAreaExplanationEmpty()
        {
            await xB.CurrentRun.AddScenario(this, 270)
                .Skip("With Area Explanation Empty", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithNoFeatures()
        {
            await xB.CurrentRun.AddScenario(this, 271)
                .Skip("With No Features", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithFeatures()
        {
            await xB.CurrentRun.AddScenario(this, 272)
                .Skip("With Features", Assert.Inconclusive);
        }
    }
}

