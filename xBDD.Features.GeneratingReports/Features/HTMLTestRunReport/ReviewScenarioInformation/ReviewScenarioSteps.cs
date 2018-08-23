
namespace xBDD.Features.GeneratingReports.HTMLTestRunReport.ReviewScenarioInformation
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
                .Skip("Untested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task CollapsingSteps()
        {
            await xB.CurrentRun.AddScenario(this, 188)
                .Skip("Untested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithNoSteps()
        {
            await xB.CurrentRun.AddScenario(this, 189)
                .Skip("Untested", Assert.Inconclusive);
        }
    }
}

