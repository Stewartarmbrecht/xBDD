
namespace MySample.Features.MyArea_2
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
	using System.Threading.Tasks;
	using xBDD;

    [TestClass]
    [AsA("sample user")]
    [YouCan("have my feature 4 value")]
    [By("execute my feature 4")]
    public class MyFeature_4: FeatureTestClass
    {

        [TestMethod]
        public async Task MyScenario_10()
        {
            await xB.CurrentRun.AddScenario(this, 1)
                .Given("my step 28", (s) => {  })
                .When("my step 2", (s) => {  })
                .Then("my step 3", (s) => {  })
                .Skip("Deferred", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task MyScenario_11()
        {
            await xB.CurrentRun.AddScenario(this, 2)
                .Given("my step 31", (s) => {  })
                .When("my step 2", (s) => {  })
                .Then("my step 3", (s) => {  })
                .Skip("Deferred", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task MyScenario_12()
        {
            await xB.CurrentRun.AddScenario(this, 3)
                .Given("my step 34", (s) => {  })
                .When("my step 2", (s) => {  })
                .Then("my step 3", (s) => {  })
                .Run();
        }
    }
}

