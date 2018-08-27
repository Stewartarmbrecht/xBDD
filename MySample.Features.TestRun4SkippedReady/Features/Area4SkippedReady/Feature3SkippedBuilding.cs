
namespace MySample.Features.TestRun4SkippedReady.Area4SkippedReady
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
	using System.Threading.Tasks;
	using xBDD;

    [TestClass]
    [AsA("")]
    [YouCan("")]
    [By("")]
    public class Feature3SkippedBuilding: FeatureTestClass
    {

        [TestMethod]
        public async Task Scenario1Passing()
        {
            await xB.CurrentRun.AddScenario(this, 55)
                .Given("Step 1 Passing", (s) => {  })
                .When("Step 2 Passing", (s) => {  })
                .Then("Step 3 Passing", (s) => {  })
                .Run();
        }

        [TestMethod]
        public async Task Scenario2SkippedUntested()
        {
            await xB.CurrentRun.AddScenario(this, 59)
                .Skip("Untested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task Scenario3SkippedBuilding()
        {
            await xB.CurrentRun.AddScenario(this, 60)
                .Given("Step 1 Skipped", (s) => {  })
                .When("Step 2 Skipped", (s) => {  })
                .Then("Step 3 Skipped", (s) => {  })
                .Skip("Building", Assert.Inconclusive);
        }
    }
}

