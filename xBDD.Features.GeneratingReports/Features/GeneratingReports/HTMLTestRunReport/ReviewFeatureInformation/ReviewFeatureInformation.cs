
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
    public class ReviewFeatureInformation: FeatureTestClass
    {

        [TestMethod]
        public async Task WithName()
        {
            await xB.CurrentRun.AddScenario(this, 136)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithNoName()
        {
            await xB.CurrentRun.AddScenario(this, 137)
                .Skip("Not Tested", Assert.Inconclusive);
        }
    }
}

