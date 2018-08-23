
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
    public class AddingStepsToAScenario: FeatureTestClass
    {

        [TestMethod]
        public async Task AddingASynchronousStep()
        {
            await xB.CurrentRun.AddScenario(this, 35)
                .Skip("Untested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task AddingAnAsynchronousStep()
        {
            await xB.CurrentRun.AddScenario(this, 36)
                .Skip("Untested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task AddingAReusableStep()
        {
            await xB.CurrentRun.AddScenario(this, 37)
                .Skip("Untested", Assert.Inconclusive);
        }
    }
}

