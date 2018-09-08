
namespace MySample.Features.MyArea_5_SortFlip
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
	using System.Threading.Tasks;
	using xBDD;

    [TestClass]
    [AsA("sample user")]
    [YouCan("have my feature C value")]
    [By("execute my feature C")]
    public class MyFeature_14_Second: FeatureTestClass
    {

        [TestMethod]
        public async Task MyScenario_36_Unsorted_35_Sorted()
        {
            await xB.CurrentRun.AddScenario(this, 1)
                .Given("my step 106 103", (s) => {  })
                .When("my step 107 104", (s) => {  })
                .Then("my step 108 105", (s) => {  })
                .Run();
        }

        [TestMethod]
        public async Task MyScenario_37_Unsorted_34_Sorted()
        {
            await xB.CurrentRun.AddScenario(this, 2)
                .Given("my step 109 100", (s) => {  })
                .When("my step 110 101", (s) => {  })
                .Then("my step 111 102", (s) => {  })
                .Run();
        }

        [TestMethod]
        public async Task MyScenario_38_Unsorted_33_Sorted()
        {
            await xB.CurrentRun.AddScenario(this, 3)
                .Given("my step 112 97", (s) => {  })
                .When("my step 113 98", (s) => {  })
                .Then("my step 114 99", (s) => {  })
                .Run();
        }
    }
}

