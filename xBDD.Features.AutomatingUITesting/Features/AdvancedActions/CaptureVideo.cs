
namespace xBDD.Features.AutomatingUITesting.AdvancedActions
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
	using System.Threading.Tasks;
	using xBDD;

    [TestClass]
    [AsA("")]
    [YouCan("")]
    [By("")]
    public class CaptureVideo: FeatureTestClass
    {

        [TestMethod]
        public async Task Successful()
        {
            await xB.CurrentRun.AddScenario(this, 162)
                .Skip("Not Defined", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task Failure()
        {
            await xB.CurrentRun.AddScenario(this, 163)
                .Skip("Not Defined", Assert.Inconclusive);
        }
    }
}

