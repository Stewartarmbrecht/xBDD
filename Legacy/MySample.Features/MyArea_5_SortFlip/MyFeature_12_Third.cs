namespace MySample.Features.MyArea_5_SortFlip
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
	using System.Threading.Tasks;
	using xBDD;

    [TestClass]
    [AsA("sample user")]
    [YouCan("have my feature 12 value")]
    [By("execute my feature 12")]
    public class MyFeature_12_Third: FeatureTestClass
    {

        [TestMethod]
        public async Task MyScenario_30_Unsorted_38_Sorted()
        {
            await xB.CurrentRun.AddScenario(this, 3)
                .Given("my step 88 112", (s) => {  })
                .When("my step 89 113 failed", (s) => { throw new Exception(); })
                .Then("my step 90 114", (s) => {  })
                .Run();
        }

        [TestMethod]
        public async Task MyScenario_31_Unsorted_37_Sorted()
        {
            await xB.CurrentRun.AddScenario(this, 2)
                .Given("my step 91 109", (s) => {  })
                .When("my step 92 110", (s) => {  })
                .Then("my step 93 111", (s) => {  })
                .Run();
        }

        [TestMethod]
        public async Task MyScenario_32_Unsorted_36_Sorted()
        {
            await xB.CurrentRun.AddScenario(this, 1)
                .Given("my step 94 106", (s) => {  })
                .When("my step 95 107", (s) => {  })
                .Then("my step 96 108", (s) => {  })
                .Run();
        }
    }
}

