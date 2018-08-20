
namespace MySample.Features.MyArea_4_CompleteFailure
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
	using System.Threading.Tasks;
	using xBDD;

    [TestClass]
    [AsA("sample user")]
    [YouCan("have my feature 11 value")]
    [By("execute my feature 11")]
    public class MyFeature_11_CompleteFailure: FeatureTestClass
    {

        [TestMethod]
        public async Task MyScenario_29_CompleteFailure()
        {
            await xB.CurrentRun.AddScenario(this, 1)
                .Given("my step 85", (s) => {  })
                .When("my failed step 86", (s) => { throw new Exception(); })
                .Then("my step 87", (s) => {  })
                .Run();
        }
    }
}

