
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
    public class DoubleClickWhenVisible: FeatureTestClass
    {

        [TestMethod]
        public async Task WithSuccess()
        {
            await xB.CurrentRun.AddScenario(this, 139)
                .Skip("Not Defined", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithSpecificWaitTime()
        {
            await xB.CurrentRun.AddScenario(this, 140)
                .Skip("Not Defined", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithFailedCondition()
        {
            await xB.CurrentRun.AddScenario(this, 141)
                .Skip("Not Defined", Assert.Inconclusive);
        }
    }
}

