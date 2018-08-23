
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
    public class ReviewStepError: FeatureTestClass
    {

        [TestMethod]
        public async Task ExpandingException()
        {
            await xB.CurrentRun.AddScenario(this, 207)
                .Skip("Untested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task CollapsingException()
        {
            await xB.CurrentRun.AddScenario(this, 208)
                .Skip("Untested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithInnerException()
        {
            await xB.CurrentRun.AddScenario(this, 209)
                .Skip("Untested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithNoException()
        {
            await xB.CurrentRun.AddScenario(this, 210)
                .Skip("Untested", Assert.Inconclusive);
        }
    }
}

