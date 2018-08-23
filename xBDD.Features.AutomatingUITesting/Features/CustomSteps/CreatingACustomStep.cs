
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
    public class CreatingACustomStep: FeatureTestClass
    {

        [TestMethod]
        public async Task Successful()
        {
            await xB.CurrentRun.AddScenario(this, 80)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task Failure()
        {
            await xB.CurrentRun.AddScenario(this, 81)
                .Skip("Not Tested", Assert.Inconclusive);
        }
    }
}

