
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
    public class SendingSpecialKeys: FeatureTestClass
    {

        [TestMethod]
        public async Task ToAValidInput()
        {
            await xB.CurrentRun.AddScenario(this, 21)
                .Skip("Untested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task ToAnInvalidInput()
        {
            await xB.CurrentRun.AddScenario(this, 22)
                .Skip("Untested", Assert.Inconclusive);
        }
    }
}

