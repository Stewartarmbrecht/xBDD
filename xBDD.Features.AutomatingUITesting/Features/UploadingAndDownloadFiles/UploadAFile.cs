
namespace xBDD.Features.AutomatingUITesting.UploadingAndDownloadFiles
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
	using System.Threading.Tasks;
	using xBDD;

    [TestClass]
    [AsA("")]
    [YouCan("")]
    [By("")]
    public class UploadAFile: FeatureTestClass
    {

        [TestMethod]
        public async Task Successful()
        {
            await xB.CurrentRun.AddScenario(this, 120)
                .Skip("Definig", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task Unsuccessful()
        {
            await xB.CurrentRun.AddScenario(this, 121)
                .Skip("Definig", Assert.Inconclusive);
        }
    }
}

