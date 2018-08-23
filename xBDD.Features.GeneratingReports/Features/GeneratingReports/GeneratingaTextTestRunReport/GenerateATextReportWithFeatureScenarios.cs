
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
    public class GenerateATextReportWithFeatureScenarios: FeatureTestClass
    {

        [TestMethod]
        public async Task WithFullFeature()
        {
            await xB.CurrentRun.AddScenario(this, 315)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithFeatureNameEmpty()
        {
            await xB.CurrentRun.AddScenario(this, 316)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithFeatureExplanationEmpty()
        {
            await xB.CurrentRun.AddScenario(this, 317)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithNoScenarios()
        {
            await xB.CurrentRun.AddScenario(this, 318)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithScenarios()
        {
            await xB.CurrentRun.AddScenario(this, 319)
                .Skip("Not Tested", Assert.Inconclusive);
        }
    }
}

