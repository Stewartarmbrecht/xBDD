
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
                .Skip("In an Empty Directory", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task InANonemptyDirectory()
        {
            await xB.CurrentRun.AddScenario(this, 5)
                .Skip("In a Nonempty Directory", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task SkippingFilesWhenOverlapWithExistingFiles()
        {
            await xB.CurrentRun.AddScenario(this, 6)
                .Skip("Skipping Files When Overlap With Existing Files", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task OverwritingExistingFiles()
        {
            await xB.CurrentRun.AddScenario(this, 7)
                .Skip("Overwriting Existing Files", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task RemovingExtraFiles()
        {
            await xB.CurrentRun.AddScenario(this, 8)
                .Skip("Removing Extra Files", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithATestRunName()
        {
            await xB.CurrentRun.AddScenario(this, 9)
                .Skip("With a Test Run Name", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithAreaNameClipping()
        {
            await xB.CurrentRun.AddScenario(this, 10)
                .Skip("With Area Name Clipping", Assert.Inconclusive);
        }
    }
}

