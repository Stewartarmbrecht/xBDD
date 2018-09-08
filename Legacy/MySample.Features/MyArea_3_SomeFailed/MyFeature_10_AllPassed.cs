
namespace MySample.Features.MyArea_3_SomeFailed
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
	using System.Threading.Tasks;
	using xBDD;

    [TestClass]
    [AsA("sample user")]
    [YouCan("have my feature 9 value")]
    [By("execute my feature 9")]
    public class MyFeature_10_AllPassed: FeatureTestClass
    {

        [TestMethod]
        public async Task MyScenario_26_Passed()
        {
            await xB.CurrentRun.AddScenario(this, 1)
                .Given("my step 76", (s) => {  })
                .When("my step 77", (s) => {  })
                .Then("my step 78", (s) => {  })
                .Run();
        }

        [TestMethod]
        public async Task MyScenario_27_Passed()
        {
            await xB.CurrentRun.AddScenario(this, 2)
                .Given("my step 79", (s) => {  })
                .When("my step 80", (s) => {  })
                .Then("my step 81", (s) => {  })
                .Run();
        }

        [TestMethod]
        public async Task MyScenario_28_Passed()
        {
            await xB.CurrentRun.AddScenario(this, 3)
                .Given("my step 82", (s) => {  })
                .When("my step 83", (s) => {  })
                .Then("my step 84", (s) => {  })
                .Run();
        }
    }
}

