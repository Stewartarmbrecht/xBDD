
namespace xBDD.Features.GeneratingReports.GeneratingReports.HTMLTestRunReport.ReviewTestRunInformation
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
	using System.Threading.Tasks;
	using xBDD;

    [TestClass]
    [AsA("")]
    [YouCan("")]
    [By("")]
    public class ReviewTestRunExplanation: FeatureTestClass
    {

        [TestMethod]
        public async Task ExpandingTheExplanation()
        {
            await xB.CurrentRun.AddScenario(this, 23)
                .Skip("Expanding the Explanation", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task CollapsingTheExplanation()
        {
            await xB.CurrentRun.AddScenario(this, 24)
                .Skip("Collapsing the Explanation", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithNoExplanation()
        {
            await xB.CurrentRun.AddScenario(this, 25)
                .Skip("With No Explanation", Assert.Inconclusive);
        }
    }
}

