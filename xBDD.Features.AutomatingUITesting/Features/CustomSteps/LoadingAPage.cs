
namespace xBDD.Features.AutomatingUITesting.CustomSteps
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
	using System.Threading.Tasks;
	using xBDD;

    [TestClass]
    [AsA("")]
    [YouCan("")]
    [By("")]
    public class LoadingAPage: FeatureTestClass
    {

        [TestMethod]
        public async Task Successful()
        {
            await xB.CurrentRun.AddScenario(this, 83)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task Failure()
        {
            await xB.CurrentRun.AddScenario(this, 84)
                .Skip("Not Tested", Assert.Inconclusive);
        }
    }
}

