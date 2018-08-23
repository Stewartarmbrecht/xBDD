
namespace xBDD.Features.DefiningFeatures.DefiningSteps
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
	using System.Threading.Tasks;
	using xBDD;

    [TestClass]
    [AsA("")]
    [YouCan("")]
    [By("")]
    public class SettingAMultilineInputForAStep: FeatureTestClass
    {

        [TestMethod]
        public async Task WhenCreatingTheStep()
        {
            await xB.CurrentRun.AddScenario(this, 39)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WhenExecutingTheStep()
        {
            await xB.CurrentRun.AddScenario(this, 40)
                .Skip("Not Tested", Assert.Inconclusive);
        }
    }
}

