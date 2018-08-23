
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
    public class SharingValuesBetweenSteps: FeatureTestClass
    {

        [TestMethod]
        public async Task ObjectRefereneces()
        {
            await xB.CurrentRun.AddScenario(this, 42)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task LiteralValues()
        {
            await xB.CurrentRun.AddScenario(this, 43)
                .Skip("Not Tested", Assert.Inconclusive);
        }
    }
}

