
namespace MySample.Features.MyArea_2
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
	using System.Threading.Tasks;
	using xBDD;

    [TestClass]
    [AsA("sample user")]
    [YouCan("have my feature 5 value")]
    [By("execute my feature 5")]
    public class MyFeature_5: FeatureTestClass
    {

        [TestMethod]
        public async Task MyScenario_13()
        {
            await xB.CurrentRun.AddScenario(this, 1)
                .Given("my step 37", (s) => {  })
                .When("my step 2", (s) => {  })
                .Then("my step 3", (s) => {  })
                .Skip("Deferred", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task MyScenario_14()
        {
            await xB.CurrentRun.AddScenario(this, 2)
                .Given("my step 40", (s) => {  })
                .When("my step 2", (s) => {  })
                .Then("my step 3", (s) => {  })
                .Skip("Deferred", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task MyScenario_15()
        {
            await xB.CurrentRun.AddScenario(this, 3)
                .Given("my step 43", (s) => {  })
                .When("my step 2", (s) => {  })
                .Then("my step 3", (s) => {  })
                .Run();
        }
    }
}

