
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
    public class GenerateAnOutlineReportWithFeatureScenarios: FeatureTestClass
    {

        [TestMethod]
        public async Task WithFullFeature()
        {
            await xB.CurrentRun.AddScenario(this, 274)
                .Skip("With Full Feature", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithFeatureNameEmpty()
        {
            await xB.CurrentRun.AddScenario(this, 275)
                .Skip("With Feature Name Empty", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithFeatureExplanationEmpty()
        {
            await xB.CurrentRun.AddScenario(this, 276)
                .Skip("With Feature Explanation Empty", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithNoScenarios()
        {
            await xB.CurrentRun.AddScenario(this, 277)
                .Skip("With No Scenarios", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithScenarios()
        {
            await xB.CurrentRun.AddScenario(this, 278)
                .Skip("With Scenarios", Assert.Inconclusive);
        }
    }
}

