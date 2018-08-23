
namespace xBDD.Features.DefiningFeatures.DefiningFeatures
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
	using System.Threading.Tasks;
	using xBDD;

    [TestClass]
    [AsA("")]
    [YouCan("")]
    [By("")]
    public class AddingFeatures: FeatureTestClass
    {

        [TestMethod]
        public async Task WithScenarios()
        {
            await xB.CurrentRun.AddScenario(this, 60)
                .Skip("Untested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithoutScenarios()
        {
            await xB.CurrentRun.AddScenario(this, 61)
                .Skip("Untested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithAVSCodeSnippet()
        {
            await xB.CurrentRun.AddScenario(this, 62)
                .Skip("Untested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task UsingABaseClass()
        {
            await xB.CurrentRun.AddScenario(this, 63)
                .Skip("Untested", Assert.Inconclusive);
        }
    }
}

