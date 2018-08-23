
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
    public class SettingAnOwnerForAScenario: FeatureTestClass
    {

        [TestMethod]
        public async Task SettingASingleOwner()
        {
            await xB.CurrentRun.AddScenario(this, 151)
                .Skip("Not Defined", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task SettingMultipleOwners()
        {
            await xB.CurrentRun.AddScenario(this, 152)
                .Skip("Not Defined", Assert.Inconclusive);
        }
    }
}

