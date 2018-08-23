
namespace xBDD.Features.AutomatingUITesting.EnteringText
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
	using System.Threading.Tasks;
	using xBDD;

    [TestClass]
    [AsA("")]
    [YouCan("")]
    [By("")]
    public class PastingText: FeatureTestClass
    {

        [TestMethod]
        public async Task WhenVisible()
        {
            await xB.CurrentRun.AddScenario(this, 24)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WhenDoesNotExist()
        {
            await xB.CurrentRun.AddScenario(this, 25)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WhenNotVisible()
        {
            await xB.CurrentRun.AddScenario(this, 26)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WhenNotAValidInput()
        {
            await xB.CurrentRun.AddScenario(this, 27)
                .Skip("Not Tested", Assert.Inconclusive);
        }
    }
}

