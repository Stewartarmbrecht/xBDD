
namespace MySample.Features.TestRun6Failed.Area6Failed
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
	using System.Threading.Tasks;
	using xBDD;

    [TestClass]
    [AsA("")]
    [YouCan("")]
    [By("")]
    public class Feature6Failed: FeatureTestClass
    {

        [TestMethod]
        public async Task Scenario1Passing()
        {
            await xB.CurrentRun.AddScenario(this, 181)
                .Given("Step 1 Passing", (s) => {  })
                .When("Step 2 Passing", (s) => {  })
                .Then("Step 3 Passing", (s) => {  })
                .Run();
        }

        [TestMethod]
        public async Task Scenario2SkippedUntested()
        {
            await xB.CurrentRun.AddScenario(this, 185)
                .Skip("Untested", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task Scenario3SkippedBuilding()
        {
            await xB.CurrentRun.AddScenario(this, 186)
                .Given("Step 1 Skipped", (s) => {  })
                .When("Step 2 Skipped", (s) => {  })
                .Then("Step 3 Skipped", (s) => {  })
                .Skip("Building", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task Scenario4SkippedReady()
        {
            await xB.CurrentRun.AddScenario(this, 190)
                .Given("Step 1 Skipped", (s) => {  })
                .When("Step 2 Skipped", (s) => {  })
                .Then("Step 3 Skipped", (s) => {  })
                .Skip("Ready", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task Scenario5SkippedDefining()
        {
            await xB.CurrentRun.AddScenario(this, 194)
                .Skip("Defining", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task Scenario6Failed()
        {
            await xB.CurrentRun.AddScenario(this, 195)
                .Given("Step 1 Passed", (s) => {  })
                .When("Step 2 Failed", (s) => { throw new Exception(); })
                .Then("Step 3 Skipped", (s) => {  })
                .Run();
        }
    }
}

