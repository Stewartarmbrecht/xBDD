
namespace MySample.Features.MyArea_2_SomeSkipped
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
	using System.Threading.Tasks;
	using xBDD;

    [TestClass]
    [AsA("sample user")]
    [YouCan("have my feature 6 value")]
    [By("execute my feature 6")]
    public class MyFeature_6_SomeSkipped: FeatureTestClass
    {

        [TestMethod]
        public async Task MyScenario_14()
        {
            await xB.CurrentRun.AddScenario(this, 1)
                .Given("my step 40", (s) => {  })
                .When("my step 41", (s) => {  })
                .Then("my step 42", (s) => {  })
                .Skip("Deferred", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task MyScenario_15()
        {
            await xB.CurrentRun.AddScenario(this, 2)
                .Given("my step 43", (s) => {  })
                .When("my step 44", (s) => {  })
                .Then("my step 45", (s) => {  })
                .Skip("Deferred", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task MyScenario_16()
        {
            await xB.CurrentRun.AddScenario(this, 3)
                .Given("my step 46", (s) => {  })
                .When("my step 47", (s) => {  })
                .Then("my step 48", (s) => {  })
                .Run();
        }
    }
}

