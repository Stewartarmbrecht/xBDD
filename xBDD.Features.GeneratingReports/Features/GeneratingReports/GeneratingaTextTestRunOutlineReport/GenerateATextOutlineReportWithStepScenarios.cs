
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
    public class GenerateATextOutlineReportWithStepScenarios: FeatureTestClass
    {

        [TestMethod]
        public async Task WithFullStep()
        {
            await xB.CurrentRun.AddScenario(this, 368)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithStepNameEmpty()
        {
            await xB.CurrentRun.AddScenario(this, 369)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithStepExplanationEmpty()
        {
            await xB.CurrentRun.AddScenario(this, 370)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithStepInputEmpty()
        {
            await xB.CurrentRun.AddScenario(this, 371)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithStepOutputEmpty()
        {
            await xB.CurrentRun.AddScenario(this, 372)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithStepException()
        {
            await xB.CurrentRun.AddScenario(this, 373)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithStepInnerException()
        {
            await xB.CurrentRun.AddScenario(this, 374)
                .Skip("Not Tested", Assert.Inconclusive);
        }
    }
}

