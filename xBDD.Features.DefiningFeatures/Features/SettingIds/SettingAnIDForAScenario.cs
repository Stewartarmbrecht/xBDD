
namespace xBDD.Features.DefiningFeatures.SettingIds
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
	using System.Threading.Tasks;
	using xBDD;

    [TestClass]
    [AsA("")]
    [YouCan("")]
    [By("")]
    public class SettingAnIDForAScenario: FeatureTestClass
    {

        [TestMethod]
        public async Task ThatIsUnique()
        {
            await xB.CurrentRun.AddScenario(this, 81)
                .Skip("Not Started", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task ThatIsNotUnique()
        {
            await xB.CurrentRun.AddScenario(this, 82)
                .Skip("Not Started", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task ThatIsAnEmptyString()
        {
            await xB.CurrentRun.AddScenario(this, 83)
                .Skip("Not Started", Assert.Inconclusive);
        }
    }
}

