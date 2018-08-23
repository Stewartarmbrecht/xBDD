
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
    public class ReviewFeatureStatement: FeatureTestClass
    {

        [TestMethod]
        public async Task ExpandingFeatureStatement()
        {
            await xB.CurrentRun.AddScenario(this, 143)
                .Skip("Expanding feature statement", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task CollapsingFeatureStatement()
        {
            await xB.CurrentRun.AddScenario(this, 144)
                .Skip("Collapsing feature statement", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithFullStatement()
        {
            await xB.CurrentRun.AddScenario(this, 145)
                .Skip("With full statement", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithMissingParts()
        {
            await xB.CurrentRun.AddScenario(this, 146)
                .Skip("With missing parts", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithoutStatement()
        {
            await xB.CurrentRun.AddScenario(this, 147)
                .Skip("Without statement", Assert.Inconclusive);
        }
    }
}

