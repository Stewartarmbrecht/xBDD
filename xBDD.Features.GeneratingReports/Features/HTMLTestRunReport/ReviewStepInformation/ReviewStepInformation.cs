
namespace xBDD.Features.GeneratingReports.HTMLTestRunReport.ReviewStepInformation
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
	using System.Threading.Tasks;
	using xBDD;

    [TestClass]
    [AsA("")]
    [YouCan("")]
    [By("")]
    public class ReviewStepInformation: FeatureTestClass
    {

        [TestMethod]
        public async Task WithName()
        {
            await xB.CurrentRun.AddScenario(this, 192)
                .Skip("Untested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithNoName()
        {
            await xB.CurrentRun.AddScenario(this, 193)
                .Skip("Untested", Assert.Inconclusive);
        }
    }
}
