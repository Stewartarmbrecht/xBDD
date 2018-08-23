
namespace xBDD.Features.DefiningFeatures.InitialSetup
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
	using System.Threading.Tasks;
	using xBDD;

    [TestClass]
    [AsA("")]
    [YouCan("")]
    [By("")]
    public class RunningScenarios: FeatureTestClass
    {

        [TestMethod]
        public async Task RunningAllScenarios()
        {
            await xB.CurrentRun.AddScenario(this, 22)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task RunningAFilteredSetOfScenarios()
        {
            await xB.CurrentRun.AddScenario(this, 23)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task RunningASingleScenario()
        {
            await xB.CurrentRun.AddScenario(this, 24)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task DebuggingAScenario()
        {
            await xB.CurrentRun.AddScenario(this, 25)
                .Skip("Not Tested", Assert.Inconclusive);
        }
    }
}

