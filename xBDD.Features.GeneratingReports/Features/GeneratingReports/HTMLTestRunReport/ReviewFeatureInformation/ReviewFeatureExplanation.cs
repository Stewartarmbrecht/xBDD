
namespace xBDD.Features.GeneratingReports.GeneratingReports.HTMLTestRunReport.ReviewFeatureInformation
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
	using System.Threading.Tasks;
	using xBDD;

    [TestClass]
    [AsA("")]
    [YouCan("")]
    [By("")]
    public class ReviewFeatureExplanation: FeatureTestClass
    {

        [TestMethod]
        public async Task ExpandingExplanation()
        {
            await xB.CurrentRun.AddScenario(this, 157)
                .Skip("Expanding explanation", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task CollapsingExplanation()
        {
            await xB.CurrentRun.AddScenario(this, 158)
                .Skip("Collapsing explanation", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithNoExplanation()
        {
            await xB.CurrentRun.AddScenario(this, 159)
                .Skip("With no explanation", Assert.Inconclusive);
        }
    }
}

