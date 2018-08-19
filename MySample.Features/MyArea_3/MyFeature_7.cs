
namespace MySample.Features.MyArea_3
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
	using System.Threading.Tasks;
	using xBDD;

    [TestClass]
    [AsA("sample user")]
    [YouCan("have my feature 7 value")]
    [By("execute my feature 7")]
    public class MyFeature_7: FeatureTestClass
    {

        [TestMethod]
        public async Task MyScenario_19()
        {
            await xB.CurrentRun.AddScenario(this, 1)
                .Given("my step 55", (s) => {  })
                .When("my failed step 56", (s) => { throw new Exception(); })
                .Then("my step 3", (s) => {  })
                .Run();
        }

        [TestMethod]
        public async Task MyScenario_20()
        {
            await xB.CurrentRun.AddScenario(this, 2)
                .Given("my step 58", (s) => {  })
                .When("my step 2", (s) => {  })
                .Then("my step 3", (s) => {  })
                .Skip("Deferred", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task MyScenario_21()
        {
            await xB.CurrentRun.AddScenario(this, 3)
                .Given("my step 61", (s) => {  })
                .When("my step 2", (s) => {  })
                .Then("my step 3", (s) => {  })
                .Run();
        }
    }
}

