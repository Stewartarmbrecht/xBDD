
namespace xBDD.Features.GeneratingReports.GeneratingReports.GeneratingaTextTestRunOutlineReport
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
	using System.Threading.Tasks;
	using xBDD;

    [TestClass]
    [AsA("")]
    [YouCan("")]
    [By("")]
    public class GenerateATextOutlineReportWithScenarioScenarios: FeatureTestClass
    {

        [TestMethod]
        public async Task WithFullScenario()
        {
            await xB.CurrentRun.AddScenario(this, 362)
                .Skip("With Full Scenario", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithScenarioNameEmpty()
        {
            await xB.CurrentRun.AddScenario(this, 363)
                .Skip("With Scenario Name Empty", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithScenarioExplanationEmpty()
        {
            await xB.CurrentRun.AddScenario(this, 364)
                .Skip("With Scenario Explanation Empty", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithNoSteps()
        {
            await xB.CurrentRun.AddScenario(this, 365)
                .Skip("With No Steps", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithSteps()
        {
            await xB.CurrentRun.AddScenario(this, 366)
                .Skip("With Steps", Assert.Inconclusive);
        }
    }
}

