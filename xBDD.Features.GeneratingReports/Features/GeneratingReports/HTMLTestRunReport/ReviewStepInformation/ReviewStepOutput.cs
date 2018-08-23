
namespace xBDD.Features.GeneratingReports.GeneratingReports.HTMLTestRunReport.ReviewStepInformation
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
	using System.Threading.Tasks;
	using xBDD;

    [TestClass]
    [AsA("")]
    [YouCan("")]
    [By("")]
    public class ReviewStepOutput: FeatureTestClass
    {

        [TestMethod]
        public async Task ExpandingOutput()
        {
            await xB.CurrentRun.AddScenario(this, 203)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task CollapsingOutput()
        {
            await xB.CurrentRun.AddScenario(this, 204)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithoutOutput()
        {
            await xB.CurrentRun.AddScenario(this, 205)
                .Skip("Not Tested", Assert.Inconclusive);
        }
    }
}

