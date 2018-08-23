
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
    public class ValidateElementHasText: FeatureTestClass
    {

        [TestMethod]
        public async Task WithSuccess()
        {
            await xB.CurrentRun.AddScenario(this, 55)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithCustomStepName()
        {
            await xB.CurrentRun.AddScenario(this, 56)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithSpecificWaitTime()
        {
            await xB.CurrentRun.AddScenario(this, 57)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithPageCapturedAsOutput()
        {
            await xB.CurrentRun.AddScenario(this, 58)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithFailure()
        {
            await xB.CurrentRun.AddScenario(this, 59)
                .Skip("Not Tested", Assert.Inconclusive);
        }
    }
}

