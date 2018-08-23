
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
    public class Hovering: FeatureTestClass
    {

        [TestMethod]
        public async Task WithSuccess()
        {
            await xB.CurrentRun.AddScenario(this, 149)
                .Skip("Defining", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithFailure()
        {
            await xB.CurrentRun.AddScenario(this, 150)
                .Skip("Defining", Assert.Inconclusive);
        }
    }
}

