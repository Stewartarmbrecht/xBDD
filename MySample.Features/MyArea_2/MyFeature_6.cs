
namespace MySample.Features.MyArea_2
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
	using System.Threading.Tasks;
	using xBDD;

    [TestClass]
    [AsA("sample user")]
    [YouCan("have my feature 6 value")]
    [By("execute my feature 6")]
    public class MyFeature_6: FeatureTestClass
    {

        [TestMethod]
        public async Task MyScenario_16()
        {
            await xB.CurrentRun.AddScenario(this, 1)
                .Given("my step 46", (s) => {  })
                .When("my step 2", (s) => {  })
                .Then("my step 3", (s) => {  })
                .Run();
        }

        [TestMethod]
        public async Task MyScenario_17()
        {
            await xB.CurrentRun.AddScenario(this, 2)
                .Given("my step 49", (s) => {  })
                .When("my step 2", (s) => {  })
                .Then("my step 3", (s) => {  })
                .Run();
        }

        [TestMethod]
        public async Task MyScenario_18()
        {
            await xB.CurrentRun.AddScenario(this, 3)
                .Given("my step 52", (s) => {  })
                .When("my step 2", (s) => {  })
                .Then("my step 3", (s) => {  })
                .Run();
        }
    }
}

