
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
    public class AddingToAnExistingProject: FeatureTestClass
    {

        [TestMethod]
        public async Task InstallingXBDD()
        {
            await xB.CurrentRun.AddScenario(this, 16)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task AddingASimpleScenario()
        {
            await xB.CurrentRun.AddScenario(this, 17)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task AddingReportGeneration()
        {
            await xB.CurrentRun.AddScenario(this, 18)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task UsingABaseFeatureClass()
        {
            await xB.CurrentRun.AddScenario(this, 19)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task CreatingReusableSteps()
        {
            await xB.CurrentRun.AddScenario(this, 20)
                .Skip("Not Tested", Assert.Inconclusive);
        }
    }
}

