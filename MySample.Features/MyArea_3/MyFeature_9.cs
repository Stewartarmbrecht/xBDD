
namespace MySample.Features.MyArea_3
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
	using System.Threading.Tasks;
	using xBDD;

    [TestClass]
    [AsA("sample user")]
    [YouCan("have my feature 9 value")]
    [By("execute my feature 9")]
    public class MyFeature_9: FeatureTestClass
    {

        [TestMethod]
        public async Task MyScenario_25()
        {
            await xB.CurrentRun.AddScenario(this, 1)
                .Given("my step 73", (s) => {  })
                .When("my step 2", (s) => {  })
                .Then("my step 3", (s) => {  })
                .Run();
        }

        [TestMethod]
        public async Task MyScenario_26()
        {
            await xB.CurrentRun.AddScenario(this, 2)
                .Given("my step 76", (s) => {  })
                .When("my step 2", (s) => {  })
                .Then("my step 3", (s) => {  })
                .Run();
        }

        [TestMethod]
        public async Task MyScenario_27()
        {
            await xB.CurrentRun.AddScenario(this, 3)
                .Given("my step 79", (s) => {  })
                .When("my step 2", (s) => {  })
                .Then("my step 3", (s) => {  })
                .Run();
        }
    }
}

