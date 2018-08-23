
namespace xBDD.Features.DefiningFeatures.DefiningFeatures
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
	using System.Threading.Tasks;
	using xBDD;

    [TestClass]
    [AsA("")]
    [YouCan("")]
    [By("")]
    public class SettingTheFeatureStatement: FeatureTestClass
    {

        [TestMethod]
        public async Task UsingStandardAttributes()
        {
            await xB.CurrentRun.AddScenario(this, 65)
                .Skip("Untested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task UsingASingleAttribute()
        {
            await xB.CurrentRun.AddScenario(this, 66)
                .Skip("Untested", Assert.Inconclusive);
        }
    }
}

