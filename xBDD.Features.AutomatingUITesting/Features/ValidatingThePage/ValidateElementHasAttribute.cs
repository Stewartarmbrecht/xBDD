
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
    public class ValidateElementHasAttribute: FeatureTestClass
    {

        [TestMethod]
        public async Task WithSuccess()
        {
            await xB.CurrentRun.AddScenario(this, 73)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithCustomStepName()
        {
            await xB.CurrentRun.AddScenario(this, 74)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithSpecificWaitTime()
        {
            await xB.CurrentRun.AddScenario(this, 75)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithPageCapturedAsOutput()
        {
            await xB.CurrentRun.AddScenario(this, 76)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithFailure()
        {
            await xB.CurrentRun.AddScenario(this, 77)
                .Skip("Not Tested", Assert.Inconclusive);
        }
    }
}

