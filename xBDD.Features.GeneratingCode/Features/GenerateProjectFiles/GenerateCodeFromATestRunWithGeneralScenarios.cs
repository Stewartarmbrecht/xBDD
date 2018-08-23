
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
    public class GenerateCodeFromATestRunWithGeneralScenarios: FeatureTestClass
    {

        [TestMethod]
        public async Task WithFullTestRun()
        {
            await xB.CurrentRun.AddScenario(this, 12)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithEmptyTestRun()
        {
            await xB.CurrentRun.AddScenario(this, 13)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithNoScenarios()
        {
            await xB.CurrentRun.AddScenario(this, 14)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithNoTestsInTheProject()
        {
            await xB.CurrentRun.AddScenario(this, 15)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithTestFiltering()
        {
            await xB.CurrentRun.AddScenario(this, 16)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithXBDDTestRunFiltering()
        {
            await xB.CurrentRun.AddScenario(this, 17)
                .Skip("Not Tested", Assert.Inconclusive);
        }
    }
}

