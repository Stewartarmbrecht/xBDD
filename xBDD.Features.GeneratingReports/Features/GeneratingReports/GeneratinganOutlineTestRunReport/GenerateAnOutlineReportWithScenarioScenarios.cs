
namespace xBDD.Features.GeneratingReports.GeneratingReports.GeneratinganOutlineTestRunReport
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
	using System.Threading.Tasks;
	using xBDD;

    [TestClass]
    [AsA("")]
    [YouCan("")]
    [By("")]
    public class GenerateAnOutlineReportWithScenarioScenarios: FeatureTestClass
    {

        [TestMethod]
        public async Task WithFullScenario()
        {
            await xB.CurrentRun.AddScenario(this, 280)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithScenarioNameEmpty()
        {
            await xB.CurrentRun.AddScenario(this, 281)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithScenarioExplanationEmpty()
        {
            await xB.CurrentRun.AddScenario(this, 282)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithNoSteps()
        {
            await xB.CurrentRun.AddScenario(this, 283)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithSteps()
        {
            await xB.CurrentRun.AddScenario(this, 284)
                .Skip("Not Tested", Assert.Inconclusive);
        }
    }
}

