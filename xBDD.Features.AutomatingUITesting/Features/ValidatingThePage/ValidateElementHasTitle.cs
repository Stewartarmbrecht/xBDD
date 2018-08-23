
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
    public class ValidateElementHasTitle: FeatureTestClass
    {

        [TestMethod]
        public async Task WithSuccess()
        {
            await xB.CurrentRun.AddScenario(this, 67)
                .Skip("Untested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithCustomStepName()
        {
            await xB.CurrentRun.AddScenario(this, 68)
                .Skip("Untested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithSpecificWaitTime()
        {
            await xB.CurrentRun.AddScenario(this, 69)
                .Skip("Untested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithPageCapturedAsOutput()
        {
            await xB.CurrentRun.AddScenario(this, 70)
                .Skip("Untested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithFailure()
        {
            await xB.CurrentRun.AddScenario(this, 71)
                .Skip("Untested", Assert.Inconclusive);
        }
    }
}

