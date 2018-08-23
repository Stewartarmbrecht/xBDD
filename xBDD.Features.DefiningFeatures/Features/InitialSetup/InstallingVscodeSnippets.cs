
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
    public class InstallingVscodeSnippets: FeatureTestClass
    {

        [TestMethod]
        public async Task ThroughTheExtensionManager()
        {
            await xB.CurrentRun.AddScenario(this, 31)
                .Skip("Defining", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task ViaTheCommandLine()
        {
            await xB.CurrentRun.AddScenario(this, 32)
                .Skip("Defining", Assert.Inconclusive);
        }
    }
}

