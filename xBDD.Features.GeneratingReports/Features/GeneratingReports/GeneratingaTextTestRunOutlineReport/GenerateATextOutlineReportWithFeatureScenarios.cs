
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
    public class GenerateATextOutlineReportWithFeatureScenarios: FeatureTestClass
    {

        [TestMethod]
        public async Task WithFullFeature()
        {
            await xB.CurrentRun.AddScenario(this, 356)
                .Skip("With Full Feature", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithFeatureNameEmpty()
        {
            await xB.CurrentRun.AddScenario(this, 357)
                .Skip("With Feature Name Empty", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithFeatureExplanationEmpty()
        {
            await xB.CurrentRun.AddScenario(this, 358)
                .Skip("With Feature Explanation Empty", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithNoScenarios()
        {
            await xB.CurrentRun.AddScenario(this, 359)
                .Skip("With No Scenarios", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithScenarios()
        {
            await xB.CurrentRun.AddScenario(this, 360)
                .Skip("With Scenarios", Assert.Inconclusive);
        }
    }
}

