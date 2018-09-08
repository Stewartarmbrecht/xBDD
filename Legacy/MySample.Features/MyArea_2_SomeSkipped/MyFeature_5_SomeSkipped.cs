
namespace MySample.Features.MyArea_2_SomeSkipped
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
	using System.Threading.Tasks;
	using xBDD;

    [TestClass]
    [AsA("sample user")]
    [YouCan("have my feature 5 value")]
    [By("execute my feature 5")]
    public class MyFeature_5_SomeSkipped: FeatureTestClass
    {

        [TestMethod]
        public async Task MyScenario_11()
        {
            await xB.CurrentRun.AddScenario(this, 1)
                .Given("my step 31", (s) => {  })
                .When("my step 32", (s) => {  })
                .Then("my step 33", (s) => {  })
                .Skip("Deferred", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task MyScenario_12()
        {
            await xB.CurrentRun.AddScenario(this, 2)
                .Given("my step 34", (s) => {  })
                .When("my step 35", (s) => {  })
                .Then("my step 36", (s) => {  })
                .Skip("Deferred", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task MyScenario_13()
        {
            await xB.CurrentRun.AddScenario(this, 3)
                .Given("my step 37", (s) => {  })
                .When("my step 38", (s) => {  })
                .Then("my step 39", (s) => {  })
                .Run();
        }
    }
}

