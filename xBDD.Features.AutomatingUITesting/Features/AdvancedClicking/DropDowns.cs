
namespace xBDD.Features.AutomatingUITesting.AdvancedClicking
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
	using System.Threading.Tasks;
	using xBDD;

    [TestClass]
    [AsA("")]
    [YouCan("")]
    [By("")]
    public class DropDowns: FeatureTestClass
    {

        [TestMethod]
        public async Task WithSuccess()
        {
            await xB.CurrentRun.AddScenario(this, 143)
                .Skip("Not Defined", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithFailure()
        {
            await xB.CurrentRun.AddScenario(this, 144)
                .Skip("Not Defined", Assert.Inconclusive);
        }
    }
}

