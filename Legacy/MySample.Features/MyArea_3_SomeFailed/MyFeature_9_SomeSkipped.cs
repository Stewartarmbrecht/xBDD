
namespace MySample.Features.MyArea_3_SomeFailed
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
	using System.Threading.Tasks;
	using xBDD;

    [TestClass]
    [AsA("sample user")]
    [YouCan("have my feature 8 value")]
    [By("execute my feature 8")]
    public class MyFeature_9_SomeSkipped: FeatureTestClass
    {

        [TestMethod]
        public async Task MyScenario_23_Failedd()
        {
            await xB.CurrentRun.AddScenario(this, 1)
                .Given("my step 67", (s) => {  })
                .When("my step 68", (s) => { throw new Exception("My exception"); })
                .Then("my step 69", (s) => {  })
                .Run();
        }

        [TestMethod]
        public async Task MyScenario_24_Skipped()
        {
            await xB.CurrentRun.AddScenario(this, 2)
                .Given("my step 70", (s) => {  })
                .When("my step 71", (s) => {  })
                .Then("my step 72", (s) => {  })
                .Skip("Deferred", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task MyScenario_25_Passed()
        {
            await xB.CurrentRun.AddScenario(this, 3)
                .Given("my step 73", (s) => {  })
                .When("my step 74", (s) => {  })
                .Then("my step 75", (s) => {  })
                .Run();
        }
    }
}

