
namespace xBDD.Features.DefiningFeatures.SettingOwnership
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
	using System.Threading.Tasks;
	using xBDD;

    [TestClass]
    [AsA("")]
    [YouCan("")]
    [By("")]
    public class SettingAnOwnerForAFeature: FeatureTestClass
    {

        [TestMethod]
        public async Task SettingASingleOwner()
        {
            await xB.CurrentRun.AddScenario(this, 154)
                .Skip("Definig", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task SettingMultipleOwners()
        {
            await xB.CurrentRun.AddScenario(this, 155)
                .Skip("Definig", Assert.Inconclusive);
        }
    }
}

