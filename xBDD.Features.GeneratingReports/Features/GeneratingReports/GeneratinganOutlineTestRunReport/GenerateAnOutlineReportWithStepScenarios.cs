
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
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithStepNameEmpty()
        {
            await xB.CurrentRun.AddScenario(this, 287)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithStepExplanationEmpty()
        {
            await xB.CurrentRun.AddScenario(this, 288)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithStepInputEmpty()
        {
            await xB.CurrentRun.AddScenario(this, 289)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithStepOutputEmpty()
        {
            await xB.CurrentRun.AddScenario(this, 290)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithStepException()
        {
            await xB.CurrentRun.AddScenario(this, 291)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithStepInnerException()
        {
            await xB.CurrentRun.AddScenario(this, 292)
                .Skip("Not Tested", Assert.Inconclusive);
        }
    }
}

