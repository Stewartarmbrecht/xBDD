
namespace MySample.Features.MyArea_1
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
	using System.Threading.Tasks;
	using xBDD;

    [TestClass]
    [AsA("sample user")]
    [YouCan("have my feature 3 value")]
    [By("execute my feature 3")]
    public class MyFeature_3: FeatureTestClass
    {

        [TestMethod]
        public async Task MyScenario_7()
        {
            await xB.CurrentRun.AddScenario(this, 1)
                .Given("my step 19", (s) => {  })
                .When("my step 2", (s) => {  })
                .Then("my step 3", (s) => {  })
                .Run();
        }

        [TestMethod]
        public async Task MyScenario_8()
        {
            await xB.CurrentRun.AddScenario(this, 2)
                .Given("my step 22", (s) => {  })
                .When("my step 2", (s) => {  })
                .Then("my step 3", (s) => {  })
                .Run();
        }

        [TestMethod]
        public async Task MyScenario_9()
        {
            await xB.CurrentRun.AddScenario(this, 3)
                .Given("my step 25", (s) => {  })
                .When("my step 2", (s) => {  })
                .Then("my step 3", (s) => {  })
                .Run();
        }
    }
}

