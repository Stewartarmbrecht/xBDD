
namespace xBDD.Features.GeneratingReports.GeneratingReports.GeneratingaTextTestRunReport
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
	using System.Threading.Tasks;
	using xBDD;

    [TestClass]
    [AsA("")]
    [YouCan("")]
    [By("")]
    public class GenerateATextReportWithTestRunScenarios: FeatureTestClass
    {

        [TestMethod]
        public async Task WithFullTestRun()
        {
            await xB.CurrentRun.AddScenario(this, 302)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithNoTestRunName()
        {
            await xB.CurrentRun.AddScenario(this, 303)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithTestRunExplanationEmpty()
        {
            await xB.CurrentRun.AddScenario(this, 304)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithNoAreas()
        {
            await xB.CurrentRun.AddScenario(this, 305)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithAreas()
        {
            await xB.CurrentRun.AddScenario(this, 306)
                .Skip("Not Tested", Assert.Inconclusive);
        }
    }
}

