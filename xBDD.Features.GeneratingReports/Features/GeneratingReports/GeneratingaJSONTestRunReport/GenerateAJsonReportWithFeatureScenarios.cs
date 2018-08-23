
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
    public class GenerateAJsonReportWithFeatureScenarios: FeatureTestClass
    {

        [TestMethod]
        public async Task WithFullFeature()
        {
            await xB.CurrentRun.AddScenario(this, 233)
                .Skip("With Full Feature", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithFeatureNameEmpty()
        {
            await xB.CurrentRun.AddScenario(this, 234)
                .Skip("With Feature Name Empty", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithFeatureExplanationEmpty()
        {
            await xB.CurrentRun.AddScenario(this, 235)
                .Skip("With Feature Explanation Empty", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithNoScenarios()
        {
            await xB.CurrentRun.AddScenario(this, 236)
                .Skip("With No Scenarios", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithScenarios()
        {
            await xB.CurrentRun.AddScenario(this, 237)
                .Skip("With Scenarios", Assert.Inconclusive);
        }
    }
}

