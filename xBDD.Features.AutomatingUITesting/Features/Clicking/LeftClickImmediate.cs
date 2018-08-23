
namespace xBDD.Features.AutomatingUITesting.Clicking
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
	using System.Threading.Tasks;
	using xBDD;

    [TestClass]
    [AsA("")]
    [YouCan("")]
    [By("")]
    public class LeftClickImmediate: FeatureTestClass
    {

        [TestMethod]
        public async Task WhenVisible()
        {
            await xB.CurrentRun.AddScenario(this, 30)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WhenDoesNotExist()
        {
            await xB.CurrentRun.AddScenario(this, 31)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WhenNotVisible()
        {
            await xB.CurrentRun.AddScenario(this, 32)
                .Skip("Not Tested", Assert.Inconclusive);
        }
    }
}

