
namespace xBDD.Features.GeneratingCode.GenerateProjectFiles
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
	using System.Threading.Tasks;
	using xBDD;

    [TestClass]
    [AsA("")]
    [YouCan("")]
    [By("")]
    public class GeneratingANewMSTestProject: FeatureTestClass
    {

        [TestMethod]
        public async Task InAnEmptyDirectory()
        {
            await xB.CurrentRun.AddScenario(this, 4)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task InANonemptyDirectory()
        {
            await xB.CurrentRun.AddScenario(this, 5)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task SkippingFilesWhenOverlapWithExistingFiles()
        {
            await xB.CurrentRun.AddScenario(this, 6)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task OverwritingExistingFiles()
        {
            await xB.CurrentRun.AddScenario(this, 7)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task RemovingExtraFiles()
        {
            await xB.CurrentRun.AddScenario(this, 8)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithATestRunName()
        {
            await xB.CurrentRun.AddScenario(this, 9)
                .Skip("Not Tested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithAreaNameClipping()
        {
            await xB.CurrentRun.AddScenario(this, 10)
                .Skip("Not Tested", Assert.Inconclusive);
        }
    }
}

