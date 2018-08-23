
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
    public class GenerateAnOutlineReportWithStepScenarios: FeatureTestClass
    {

        [TestMethod]
        public async Task WithFullStep()
        {
            await xB.CurrentRun.AddScenario(this, 286)
                .Skip("With Full Step", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithStepNameEmpty()
        {
            await xB.CurrentRun.AddScenario(this, 287)
                .Skip("With Step Name Empty", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithStepExplanationEmpty()
        {
            await xB.CurrentRun.AddScenario(this, 288)
                .Skip("With Step Explanation Empty", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithStepInputEmpty()
        {
            await xB.CurrentRun.AddScenario(this, 289)
                .Skip("With Step Input Empty", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithStepOutputEmpty()
        {
            await xB.CurrentRun.AddScenario(this, 290)
                .Skip("With Step Output Empty", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithStepException()
        {
            await xB.CurrentRun.AddScenario(this, 291)
                .Skip("With Step Exception", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithStepInnerException()
        {
            await xB.CurrentRun.AddScenario(this, 292)
                .Skip("With Step Inner Exception", Assert.Inconclusive);
        }
    }
}

