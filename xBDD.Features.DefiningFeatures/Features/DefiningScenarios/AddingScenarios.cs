
namespace xBDD.Features.DefiningFeatures.DefiningScenarios
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
	using System.Threading.Tasks;
	using xBDD;

    [TestClass]
    [AsA("")]
    [YouCan("")]
    [By("")]
    public class AddingScenarios: FeatureTestClass
    {

        [TestMethod]
        public async Task WithSteps()
        {
            await xB.CurrentRun.AddScenario(this, 48)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithoutSteps()
        {
            await xB.CurrentRun.AddScenario(this, 49)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task UsingAVSCodeSnippet()
        {
            await xB.CurrentRun.AddScenario(this, 50)
                .Skip("Not Tested", Assert.Inconclusive);
        }
    }
}

