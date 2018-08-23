
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
    public class ReviewFeatureScenarios: FeatureTestClass
    {

        [TestMethod]
        public async Task ExpandingScenarios()
        {
            await xB.CurrentRun.AddScenario(this, 171)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task CollapsingScenarios()
        {
            await xB.CurrentRun.AddScenario(this, 172)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithNoScenarios()
        {
            await xB.CurrentRun.AddScenario(this, 173)
                .Skip("Not Tested", Assert.Inconclusive);
        }
    }
}

