
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
    public class SendingStandardKeys: FeatureTestClass
    {

        [TestMethod]
        public async Task ToAValidInput()
        {
            await xB.CurrentRun.AddScenario(this, 18)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task ToAnInvalidInput()
        {
            await xB.CurrentRun.AddScenario(this, 19)
                .Skip("Not Tested", Assert.Inconclusive);
        }
    }
}

