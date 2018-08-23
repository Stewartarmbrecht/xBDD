
namespace xBDD.Features.GeneratingReports.GeneratingReports.HTMLTestRunReport.Generating
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
	using System.Threading.Tasks;
	using xBDD;

    [TestClass]
    [AsA("")]
    [YouCan("")]
    [By("")]
    public class ViewAReport: FeatureTestClass
    {

        [TestMethod]
        public async Task FromAFileServer()
        {
            await xB.CurrentRun.AddScenario(this, 16)
                .Skip("From a File Server", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task FromAWebServer()
        {
            await xB.CurrentRun.AddScenario(this, 17)
                .Skip("From a Web Server", Assert.Inconclusive);
        }
    }
}

