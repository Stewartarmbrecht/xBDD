
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
    public class ValidateElementIsVisible: FeatureTestClass
    {

        [TestMethod]
        public async Task WithSuccess()
        {
            await xB.CurrentRun.AddScenario(this, 43)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithCustomStepName()
        {
            await xB.CurrentRun.AddScenario(this, 44)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithSpecificWaitTime()
        {
            await xB.CurrentRun.AddScenario(this, 45)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithPageCapturedAsOutput()
        {
            await xB.CurrentRun.AddScenario(this, 46)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithFailure()
        {
            await xB.CurrentRun.AddScenario(this, 47)
                .Skip("Not Tested", Assert.Inconclusive);
        }
    }
}

