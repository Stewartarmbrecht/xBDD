
namespace MySample.Features.MyArea_0_Unsorted
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
	using System.Threading.Tasks;
	using xBDD;

    [TestClass]
    [AsA("sample user")]
    [YouCan("have my feature 0 value")]
    [By("execute my feature 0")]
    public class MyFeature_0_Unsorted: FeatureTestClass
    {

        [TestMethod]
        public async Task MyScenario_0_Unsorted()
        {
            await xB.CurrentRun.AddScenario(this)
                .Given("my step 1", (s) => {  })
                .When("my step 2", (s) => {  })
                .Then("my step 3", (s) => {  })
                .Run();
        }
        [TestMethod]
        public async Task MyScenario_1_Sorted()
        {
            await xB.CurrentRun.AddScenario(this, 1)
                .Given("my step 1", (s) => {  })
                .When("my step 2", (s) => {  })
                .Then("my step 3", (s) => {  })
                .Run();
        }
        [TestMethod]
        public async Task MyScenario_2_Sorted()
        {
            await xB.CurrentRun.AddScenario(this, 2)
                .Given("my step 1", (s) => {  })
                .When("my step 2", (s) => {  })
                .Then("my step 3", (s) => {  })
                .Run();
        }
    }
}

