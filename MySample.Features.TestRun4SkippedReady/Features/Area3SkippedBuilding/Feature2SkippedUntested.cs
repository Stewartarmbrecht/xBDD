
namespace MySample.Features.TestRun4SkippedReady.Area3SkippedBuilding
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
	using System.Threading.Tasks;
	using xBDD;

    [TestClass]
    [AsA("")]
    [YouCan("")]
    [By("")]
    public class Feature2SkippedUntested: FeatureTestClass
    {

        [TestMethod]
        public async Task Scenario1Passing()
        {
            await xB.CurrentRun.AddScenario(this, 27)
                .Given("Step 1 Passing", (s) => {  })
                .When("Step 2 Passing", (s) => {  })
                .Then("Step 3 Passing", (s) => {  })
                .Run();
        }

        [TestMethod]
        public async Task Scenario2SkippedUntested()
        {
            await xB.CurrentRun.AddScenario(this, 31)
                .Skip("Untested", Assert.Inconclusive);
        }
    }
}

