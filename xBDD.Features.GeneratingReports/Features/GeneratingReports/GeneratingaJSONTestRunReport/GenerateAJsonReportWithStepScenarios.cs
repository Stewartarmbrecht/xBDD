
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
    public class GenerateAJsonReportWithStepScenarios: FeatureTestClass
    {

        [TestMethod]
        public async Task WithFullStep()
        {
            await xB.CurrentRun.AddScenario(this, 245)
                .Skip("With Full Step", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithStepNameEmpty()
        {
            await xB.CurrentRun.AddScenario(this, 246)
                .Skip("With Step Name Empty", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithStepExplanationEmpty()
        {
            await xB.CurrentRun.AddScenario(this, 247)
                .Skip("With Step Explanation Empty", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithStepInputEmpty()
        {
            await xB.CurrentRun.AddScenario(this, 248)
                .Skip("With Step Input Empty", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithStepOutputEmpty()
        {
            await xB.CurrentRun.AddScenario(this, 249)
                .Skip("With Step Output Empty", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithStepException()
        {
            await xB.CurrentRun.AddScenario(this, 250)
                .Skip("With Step Exception", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithStepInnerException()
        {
            await xB.CurrentRun.AddScenario(this, 251)
                .Skip("With Step Inner Exception", Assert.Inconclusive);
        }
    }
}

