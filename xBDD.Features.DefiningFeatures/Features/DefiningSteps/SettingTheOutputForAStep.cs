
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
    public class SettingTheOutputForAStep: FeatureTestClass
    {

        [TestMethod]
        public async Task WhenExecutingAStep()
        {
            await xB.CurrentRun.AddScenario(this, 45)
                .Skip("Untested", Assert.Inconclusive);
        }
    }
}

