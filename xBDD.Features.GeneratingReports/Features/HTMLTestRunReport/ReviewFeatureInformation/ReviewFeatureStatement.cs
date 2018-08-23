
namespace xBDD.Features.GeneratingReports.HTMLTestRunReport.ReviewFeatureInformation
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
	using System.Threading.Tasks;
	using xBDD;

    [TestClass]
    [AsA("")]
    [YouCan("")]
    [By("")]
    public class ReviewFeatureStatement: FeatureTestClass
    {

        [TestMethod]
        public async Task ExpandingFeatureStatement()
        {
            await xB.CurrentRun.AddScenario(this, 143)
                .Skip("Untested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task CollapsingFeatureStatement()
        {
            await xB.CurrentRun.AddScenario(this, 144)
                .Skip("Untested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithFullStatement()
        {
            await xB.CurrentRun.AddScenario(this, 145)
                .Skip("Untested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithMissingParts()
        {
            await xB.CurrentRun.AddScenario(this, 146)
                .Skip("Untested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithoutStatement()
        {
            await xB.CurrentRun.AddScenario(this, 147)
                .Skip("Untested", Assert.Inconclusive);
        }
    }
}

