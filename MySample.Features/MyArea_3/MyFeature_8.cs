
namespace MySample.Features.MyArea_3
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
	using System.Threading.Tasks;
	using xBDD;

    [TestClass]
    [AsA("sample user")]
    [YouCan("have my feature 8 value")]
    [By("execute my feature 8")]
    public class MyFeature_8: FeatureTestClass
    {

        [TestMethod]
        public async Task MyScenario_22()
        {
            await xB.CurrentRun.AddScenario(this, 1)
                .Given("my step 64", (s) => {  })
                .When("my step 2", (s) => {  })
                .Then("my step 3", (s) => {  })
                .Skip("Deferred", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task MyScenario_23()
        {
            await xB.CurrentRun.AddScenario(this, 2)
                .Given("my step 67", (s) => {  })
                .When("my step 2", (s) => {  })
                .Then("my step 3", (s) => {  })
                .Skip("Deferred", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task MyScenario_24()
        {
            await xB.CurrentRun.AddScenario(this, 3)
                .Given("my step 70", (s) => {  })
                .When("my step 2", (s) => {  })
                .Then("my step 3", (s) => {  })
                .Run();
        }
    }
}

