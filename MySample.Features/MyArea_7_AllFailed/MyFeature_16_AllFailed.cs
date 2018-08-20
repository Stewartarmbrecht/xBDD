
namespace MySample.Features.MyArea_7_AllFailed
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
	using System.Threading.Tasks;
	using xBDD;

    [TestClass]
    [AsA("sample user")]
    [YouCan("have my feature 7 value")]
    [By("execute my feature 7")]
    public class MyFeature_16_AllFailed: FeatureTestClass
    {

        [TestMethod]
        public async Task MyScenario_40_Failed()
        {
            await xB.CurrentRun.AddScenario(this, 1)
                .Given("my step 118", (s) => {  })
                .When("my step 119 failed", (s) => { throw new Exception("I failed."); })
                .Then("my step 120", (s) => {  })
                .Skip("Deferred", Assert.Inconclusive);
        }
    }
}

