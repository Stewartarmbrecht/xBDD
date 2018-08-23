
namespace xBDD.Features.AutomatingUITesting.AdvancedClicking
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
	using System.Threading.Tasks;
	using xBDD;

    [TestClass]
    [AsA("")]
    [YouCan("")]
    [By("")]
    public class RightClickImmediate: FeatureTestClass
    {

        [TestMethod]
        public async Task WhenVisible()
        {
            await xB.CurrentRun.AddScenario(this, 127)
                .Skip("Not Defined", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WhenDoesNotExist()
        {
            await xB.CurrentRun.AddScenario(this, 128)
                .Skip("Not Defined", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WhenNotVisible()
        {
            await xB.CurrentRun.AddScenario(this, 129)
                .Skip("Not Defined", Assert.Inconclusive);
        }
    }
}

