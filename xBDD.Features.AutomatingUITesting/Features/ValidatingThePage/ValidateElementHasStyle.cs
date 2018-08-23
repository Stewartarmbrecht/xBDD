
namespace xBDD.Features.AutomatingUITesting.ValidatingThePage
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
	using System.Threading.Tasks;
	using xBDD;

    [TestClass]
    [AsA("")]
    [YouCan("")]
    [By("")]
    public class ValidateElementHasStyle: FeatureTestClass
    {

        [TestMethod]
        public async Task WithSuccess()
        {
            await xB.CurrentRun.AddScenario(this, 61)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithCustomStepName()
        {
            await xB.CurrentRun.AddScenario(this, 62)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithSpecificWaitTime()
        {
            await xB.CurrentRun.AddScenario(this, 63)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithPageCapturedAsOutput()
        {
            await xB.CurrentRun.AddScenario(this, 64)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithFailure()
        {
            await xB.CurrentRun.AddScenario(this, 65)
                .Skip("Not Tested", Assert.Inconclusive);
        }
    }
}

