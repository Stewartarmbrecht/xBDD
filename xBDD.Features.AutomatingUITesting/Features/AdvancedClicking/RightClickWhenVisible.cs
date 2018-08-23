
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
    public class RightClickWhenVisible: FeatureTestClass
    {

        [TestMethod]
        public async Task WithSuccess()
        {
            await xB.CurrentRun.AddScenario(this, 131)
                .Skip("Definig", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithSpecificWaitTime()
        {
            await xB.CurrentRun.AddScenario(this, 132)
                .Skip("Definig", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithFailedCondition()
        {
            await xB.CurrentRun.AddScenario(this, 133)
                .Skip("Definig", Assert.Inconclusive);
        }
    }
}

