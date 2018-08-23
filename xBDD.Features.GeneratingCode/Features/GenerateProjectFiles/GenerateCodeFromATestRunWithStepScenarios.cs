
namespace xBDD.Features.GeneratingCode.GenerateProjectFiles
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
	using System.Threading.Tasks;
	using xBDD;

    [TestClass]
    [AsA("")]
    [YouCan("")]
    [By("")]
    public class GenerateCodeFromATestRunWithStepScenarios: FeatureTestClass
    {

        [TestMethod]
        public async Task WithFullStep()
        {
            await xB.CurrentRun.AddScenario(this, 44)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithStepNameEmpty()
        {
            await xB.CurrentRun.AddScenario(this, 45)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithStepExplanationEmpty()
        {
            await xB.CurrentRun.AddScenario(this, 46)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithStepInputEmpty()
        {
            await xB.CurrentRun.AddScenario(this, 47)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithStepOutputEmpty()
        {
            await xB.CurrentRun.AddScenario(this, 48)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithStepException()
        {
            await xB.CurrentRun.AddScenario(this, 49)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithStepInnerException()
        {
            await xB.CurrentRun.AddScenario(this, 50)
                .Skip("Not Tested", Assert.Inconclusive);
        }
    }
}

