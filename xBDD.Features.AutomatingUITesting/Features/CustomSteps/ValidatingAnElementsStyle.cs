
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
    public class ValidatingAnElementsStyle: FeatureTestClass
    {

        [TestMethod]
        public async Task Successful()
        {
            await xB.CurrentRun.AddScenario(this, 104)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task Failure()
        {
            await xB.CurrentRun.AddScenario(this, 105)
                .Skip("Not Tested", Assert.Inconclusive);
        }
    }
}

