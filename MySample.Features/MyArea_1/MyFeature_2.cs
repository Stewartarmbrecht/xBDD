
namespace MySample.Features.MyArea_1
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
	using System.Threading.Tasks;
	using xBDD;

    [TestClass]
    [AsA("sample user")]
    [YouCan("have my feature 2 value")]
    [By("execute my feature 2")]
    public class MyFeature_2: FeatureTestClass
    {

        [TestMethod]
        public async Task MyScenario_4()
        {
            await xB.CurrentRun.AddScenario(this, 1)
                .Given("my step 10", (s) => {  })
                .When("my step 2", (s) => {  })
                .Then("my step 3", (s) => {  })
                .Run();
        }

        [TestMethod]
        public async Task MyScenario_5()
        {
            await xB.CurrentRun.AddScenario(this, 2)
                .Given("my step 13", (s) => {  })
                .When("my step 2", (s) => {  })
                .Then("my step 3", (s) => {  })
                .Run();
        }

        [TestMethod]
        public async Task MyScenario_6()
        {
            await xB.CurrentRun.AddScenario(this, 3)
                .Given("my step 16", (s) => {  })
                .When("my step 2", (s) => {  })
                .Then("my step 3", (s) => {  })
                .Run();
        }
    }
}

