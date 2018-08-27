
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
    public class Feature1Passing: FeatureTestClass
    {

        [TestMethod]
        public async Task Scenario1Passing()
        {
            await xB.CurrentRun.AddScenario(this, 44)
                .Given("Step 1 Passing", (s) => {  })
                .When("Step 2 Passing", (s) => {  })
                .Then("Step 3 Passing", (s) => {  })
                .Run();
        }
    }
}

