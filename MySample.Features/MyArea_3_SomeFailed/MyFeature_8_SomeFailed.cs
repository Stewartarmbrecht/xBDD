
namespace MySample.Features.MyArea_3_SomeFailed
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
	using System.Threading.Tasks;
	using xBDD;

    [TestClass]
    [AsA("sample user")]
    [YouCan("have my feature 7 value")]
    [By("execute my feature 7")]
    public class MyFeature_8_SomeFailed: FeatureTestClass
    {

        [TestMethod]
        public async Task MyScenario_20_Failed()
        {
            await xB.CurrentRun.AddScenario(this, 1)
                .Given("my step 58", (s) => {  })
                .When("my failed step 59", (s) => { throw new Exception(); })
                .Then("my step 60", (s) => {  })
                .Run();
        }

        [TestMethod]
        public async Task MyScenario_21_Failed()
        {
            await xB.CurrentRun.AddScenario(this, 2)
                .Given("my step 61", (s) => {  })
                .When("my step 62", (s) => {
                    try {
                        throw new Exception("My Exception");
                    } catch( Exception ex) {
                        throw new AggregateException(ex);
                    }
                 })
                .Then("my step 63", (s) => {  })
                .Run();
        }

        [TestMethod]
        public async Task MyScenario_22_Passed()
        {
            await xB.CurrentRun.AddScenario(this, 3)
                .Given("my step 64", (s) => {  })
                .When("my step 65", (s) => {  })
                .Then("my step 66", (s) => {  })
                .Run();
        }
    }
}

