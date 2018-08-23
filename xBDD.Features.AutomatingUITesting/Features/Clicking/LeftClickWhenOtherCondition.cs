
namespace xBDD.Features.AutomatingUITesting.Clicking
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
	using System.Threading.Tasks;
	using xBDD;

    [TestClass]
    [AsA("")]
    [YouCan("")]
    [By("")]
    public class LeftClickWhenOtherCondition: FeatureTestClass
    {

        [TestMethod]
        public async Task MakeImpossible()
        {
            await xB.CurrentRun.AddScenario(this, 38)
                .Given("out Wait conditions from click conditions", (s) => {  })
                .Given("ass inheritance", (s) => {  })
                .Skip("Need to Remove", Assert.Inconclusive);
        }
    }
}

