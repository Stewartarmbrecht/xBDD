
namespace MySample.Features.MyArea_6_AllSkipped
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
	using System.Threading.Tasks;
	using xBDD;

    [TestClass]
    [AsA("sample user")]
    [YouCan("have my feature 5 value")]
    [By("execute my feature 5")]
    public class MyFeature_15_AllSkipped: FeatureTestClass
    {

        [TestMethod]
        public async Task MyScenario_39_AllSkipped()
        {
            await xB.CurrentRun.AddScenario(this, 1)
                .Given("my step 115", (s) => {  })
                .When("my step 116", (s) => {  })
                .Then("my step 117", (s) => {  })
                .Skip("Deferred", Assert.Inconclusive);
        }
    }
}

