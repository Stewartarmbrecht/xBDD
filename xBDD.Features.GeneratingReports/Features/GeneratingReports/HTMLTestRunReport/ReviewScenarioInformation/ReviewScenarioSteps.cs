
namespace xBDD.Features.GeneratingReports.GeneratingReports.HTMLTestRunReport.ReviewScenarioInformation
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
	using System.Threading.Tasks;
	using xBDD;

    [TestClass]
    [AsA("")]
    [YouCan("")]
    [By("")]
    public class ReviewScenarioSteps: FeatureTestClass
    {

        [TestMethod]
        public async Task ExpandingSteps()
        {
            await xB.CurrentRun.AddScenario(this, 187)
                .Skip("Expanding steps", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task CollapsingSteps()
        {
            await xB.CurrentRun.AddScenario(this, 188)
                .Skip("Collapsing steps", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithNoSteps()
        {
            await xB.CurrentRun.AddScenario(this, 189)
                .Skip("With no steps", Assert.Inconclusive);
        }
    }
}

