
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
    public class ReviewScenarioInformation: FeatureTestClass
    {

        [TestMethod]
        public async Task WithName()
        {
            await xB.CurrentRun.AddScenario(this, 176)
                .Skip("With Name", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithNoName()
        {
            await xB.CurrentRun.AddScenario(this, 177)
                .Skip("With No Name", Assert.Inconclusive);
        }
    }
}

