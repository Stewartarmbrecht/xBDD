
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
    public class ReviewScenarioExplanation: FeatureTestClass
    {

        [TestMethod]
        public async Task ExpandingExplanation()
        {
            await xB.CurrentRun.AddScenario(this, 179)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task CollapsingExplanation()
        {
            await xB.CurrentRun.AddScenario(this, 180)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithNoExplanation()
        {
            await xB.CurrentRun.AddScenario(this, 181)
                .Skip("Not Tested", Assert.Inconclusive);
        }
    }
}

