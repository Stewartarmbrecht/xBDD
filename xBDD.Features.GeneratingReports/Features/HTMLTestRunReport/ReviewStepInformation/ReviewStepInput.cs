
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
    public class ReviewStepInput: FeatureTestClass
    {

        [TestMethod]
        public async Task ExpandingInput()
        {
            await xB.CurrentRun.AddScenario(this, 199)
                .Skip("Untested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task CollapsingInput()
        {
            await xB.CurrentRun.AddScenario(this, 200)
                .Skip("Untested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithoutInput()
        {
            await xB.CurrentRun.AddScenario(this, 201)
                .Skip("Untested", Assert.Inconclusive);
        }
    }
}

