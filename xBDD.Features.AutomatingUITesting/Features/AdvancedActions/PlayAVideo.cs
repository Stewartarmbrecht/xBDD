
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
    public class PlayAVideo: FeatureTestClass
    {

        [TestMethod]
        public async Task Successful()
        {
            await xB.CurrentRun.AddScenario(this, 156)
                .Skip("Not Defined", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task Failure()
        {
            await xB.CurrentRun.AddScenario(this, 157)
                .Skip("Not Defined", Assert.Inconclusive);
        }
    }
}

