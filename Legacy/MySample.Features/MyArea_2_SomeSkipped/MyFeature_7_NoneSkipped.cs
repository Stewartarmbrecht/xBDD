
namespace MySample.Features.MyArea_2_SomeSkipped
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
	using System.Threading.Tasks;
	using xBDD;

    [TestClass]
    [AsA("sample user")]
    [YouCan("have my feature 7 value")]
    [By("execute my feature 7")]
    public class MyFeature_7_NoneSkipped: FeatureTestClass
    {

        [TestMethod]
        public async Task MyScenario_17()
        {
            await xB.CurrentRun.AddScenario(this, 1)
                .Given("my step 49", (s) => {  })
                .When("my step 50", (s) => {  })
                .Then("my step 51", (s) => {  })
                .Run();
        }

        [TestMethod]
        public async Task MyScenario_18()
        {
            await xB.CurrentRun.AddScenario(this, 2)
                .Given("my step 52", (s) => {  })
                .When("my step 53", (s) => {  })
                .Then("my step 54", (s) => {  })
                .Run();
        }

        [TestMethod]
        public async Task MyScenario_19()
        {
            await xB.CurrentRun.AddScenario(this, 3)
                .Given("my step 55", (s) => {  })
                .When("my step 56", (s) => {  })
                .Then("my step 57", (s) => {  })
                .Run();
        }
    }
}

