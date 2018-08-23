
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
    public class DoubleClickImmediate: FeatureTestClass
    {

        [TestMethod]
        public async Task WhenVisible()
        {
            await xB.CurrentRun.AddScenario(this, 135)
                .Skip("Not Defined", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WhenDoesNotExist()
        {
            await xB.CurrentRun.AddScenario(this, 136)
                .Skip("Not Defined", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WhenNotVisible()
        {
            await xB.CurrentRun.AddScenario(this, 137)
                .Skip("Not Defined", Assert.Inconclusive);
        }
    }
}

