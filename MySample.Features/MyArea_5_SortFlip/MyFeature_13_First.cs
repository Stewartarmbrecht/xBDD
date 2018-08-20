
namespace MySample.Features.MyArea_5_SortFlip
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
	using System.Threading.Tasks;
	using xBDD;

    [TestClass]
    [AsA("sample user")]
    [YouCan("have my feature B value")]
    [By("execute my feature B")]
    public class MyFeature_13_First: FeatureTestClass
    {

        [TestMethod]
        public async Task MyScenario_33_Unsorted_32_Sorted()
        {
            await xB.CurrentRun.AddScenario(this, 3)
                .Given("my step 97 94", (s) => {  })
                .When("my step 98 95", (s) => {  })
                .Then("my step 99 96", (s) => {  })
                .Run();
        }

        [TestMethod]
        public async Task MyScenario_34_Unsorted_31_Sorted()
        {
            await xB.CurrentRun.AddScenario(this, 2)
                .Given("my step 100 91", (s) => {  })
                .When("my step 101 92", (s) => {  })
                .Then("my step 102 93", (s) => {  })
                .Run();
        }

        [TestMethod]
        public async Task MyScenario_35_Unsorted_30_Sorted()
        {
            await xB.CurrentRun.AddScenario(this, 1)
                .Given("my step 103 88", (s) => {  })
                .When("my step 104 89", (s) => {  })
                .Then("my step 105 90", (s) => {  })
                .Run();
        }
    }
}

