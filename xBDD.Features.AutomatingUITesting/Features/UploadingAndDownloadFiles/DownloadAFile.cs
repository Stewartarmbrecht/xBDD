
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
    public class DownloadAFile: FeatureTestClass
    {

        [TestMethod]
        public async Task Successful()
        {
            await xB.CurrentRun.AddScenario(this, 123)
                .Skip("Definig", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task Unsuccessful()
        {
            await xB.CurrentRun.AddScenario(this, 124)
                .Skip("Definig", Assert.Inconclusive);
        }
    }
}

