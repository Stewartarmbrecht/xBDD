
namespace xBDD.Features.AutomatingUITesting.Navigating
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
	using System.Threading.Tasks;
	using xBDD;

    [TestClass]
    [AsA("")]
    [YouCan("")]
    [By("")]
    public class NavigateAsAUser: FeatureTestClass
    {

        [TestMethod]
        public async Task WithSpecificSize()
        {
            await xB.CurrentRun.AddScenario(this, 8)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task ToAValidURL()
        {
            await xB.CurrentRun.AddScenario(this, 9)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task ToAnInvalidURL()
        {
            await xB.CurrentRun.AddScenario(this, 10)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WhenNoInternetConnection()
        {
            await xB.CurrentRun.AddScenario(this, 11)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task ToAValidFile()
        {
            await xB.CurrentRun.AddScenario(this, 12)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task ToANonHtmlTextFile()
        {
            await xB.CurrentRun.AddScenario(this, 13)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task ToABinaryFile()
        {
            await xB.CurrentRun.AddScenario(this, 14)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task ToAMissingFile()
        {
            await xB.CurrentRun.AddScenario(this, 15)
                .Skip("Not Tested", Assert.Inconclusive);
        }
    }
}

