
namespace xBDD.Features.GeneratingReports.GeneratingReports.GeneratingaJSONTestRunReport
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
	using System.Threading.Tasks;
	using xBDD;

    [TestClass]
    [AsA("")]
    [YouCan("")]
    [By("")]
    public class GenerateAJsonReportWithScenarioScenarios: FeatureTestClass
    {

        [TestMethod]
        public async Task WithFullScenario()
        {
            await xB.CurrentRun.AddScenario(this, 239)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithScenarioNameEmpty()
        {
            await xB.CurrentRun.AddScenario(this, 240)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithScenarioExplanationEmpty()
        {
            await xB.CurrentRun.AddScenario(this, 241)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithNoSteps()
        {
            await xB.CurrentRun.AddScenario(this, 242)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithSteps()
        {
            await xB.CurrentRun.AddScenario(this, 243)
                .Skip("Not Tested", Assert.Inconclusive);
        }
    }
}

