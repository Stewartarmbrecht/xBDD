
namespace MySample.Features.TestRun6Failed.Area5SkippedDefining
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
	using System.Threading.Tasks;
	using xBDD;

    [TestClass]
    [AsA("")]
    [YouCan("")]
    [By("")]
    public class Feature5SkippedDefining: FeatureTestClass
    {

        [TestMethod]
        public async Task Scenario1Passing()
        {
            await xB.CurrentRun.AddScenario(this, 115)
                .Given("Step 1 Passing", (s) => {  })
                .When("Step 2 Passing", (s) => {  })
                .Then("Step 3 Passing", (s) => {  })
                .Run();
        }

        [TestMethod]
        public async Task Scenario2SkippedUntested()
        {
            await xB.CurrentRun.AddScenario(this, 119)
                .Skip("Untested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task Scenario3SkippedBuilding()
        {
            await xB.CurrentRun.AddScenario(this, 120)
                .Given("Step 1 Skipped", (s) => {  })
                .When("Step 2 Skipped", (s) => {  })
                .Then("Step 3 Skipped", (s) => {  })
                .Skip("Building", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task Scenario4SkippedReady()
        {
            await xB.CurrentRun.AddScenario(this, 124)
                .Given("Step 1 Skipped", (s) => {  })
                .When("Step 2 Skipped", (s) => {  })
                .Then("Step 3 Skipped", (s) => {  })
                .Skip("Ready", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task Scenario5SkippedDefining()
        {
            await xB.CurrentRun.AddScenario(this, 128)
                .Skip("Defining", Assert.Inconclusive);
        }
    }
}

