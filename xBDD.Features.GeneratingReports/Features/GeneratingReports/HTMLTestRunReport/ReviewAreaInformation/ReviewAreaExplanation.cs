
namespace xBDD.Features.GeneratingReports.GeneratingReports.HTMLTestRunReport.ReviewAreaInformation
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
	using System.Threading.Tasks;
	using xBDD;

    [TestClass]
    [AsA("")]
    [YouCan("")]
    [By("")]
    public class ReviewAreaExplanation: FeatureTestClass
    {

        [TestMethod]
        public async Task ExpandingExplanation()
        {
            await xB.CurrentRun.AddScenario(this, 127)
                .Skip("Expanding explanation", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task CollapsingExplanation()
        {
            await xB.CurrentRun.AddScenario(this, 128)
                .Skip("Collapsing explanation", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithoutExplanation()
        {
            await xB.CurrentRun.AddScenario(this, 129)
                .Skip("Without explanation", Assert.Inconclusive);
        }
    }
}

