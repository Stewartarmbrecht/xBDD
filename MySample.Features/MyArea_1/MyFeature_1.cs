
namespace MySample.Features.MyArea_1
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
	using System.Threading.Tasks;
	using xBDD;

    [TestClass]
    [AsA("sample user")]
    [YouCan("have my feature 1 value")]
    [By("execute my feature 1")]
    public class MyFeature_1: FeatureTestClass
    {

        [TestMethod]
        public async Task MyScenario_1()
        {
            await xB.CurrentRun.AddScenario(this, 1)
                .Given("my step 1", (s) => { 
                    //Add code to perform action.
                 })
                .When("my step 2", (s) => { 
                    //Add code to perform action.
                 })
                .Then("my step 3", (s) => { 
                    //Add code to perform action.
                 })
                .Run();
        }

        [TestMethod]
        public async Task MyScenario_2()
        {
            await xB.CurrentRun.AddScenario(this, 2)
                .Given("my step 4", (s) => {  })
                .When("my step 2", (s) => {  })
                .Then("my step 3", (s) => {  })
                .Run();
        }

        [TestMethod]
        public async Task MyScenario_3()
        {
            await xB.CurrentRun.AddScenario(this, 3)
                .Given("my step 7", (s) => {  })
                .When("my step 2", (s) => {  })
                .Then("my step 3", (s) => {  })
                .Run();
        }
    }
}

