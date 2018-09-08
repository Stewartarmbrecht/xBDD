namespace MySample.Features.MyFirstArea
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
	using System.Threading.Tasks;
	using xBDD;

    [TestClass]
    [AsA("sample user")]
    [YouCan("have my first failing feature value")]
    [By("execute my first failing feature")]
    public class MyFirstFailingFeature: FeatureTestClass
    {

        [TestMethod]
        public async Task MyFirstScenario()
        {
            await xB.CurrentRun.AddScenario(this, 1)
                 .Given("my step 1", (s) => { 
                    //Add code to perform action.
                 })
                .When("my step 2", (s) => { 
                    //Add code to perform action.
                    throw new Exception("My first exception.");
                 })
                .Then("my step 3", (s) => { 
                    //Add code to perform action.
                 })
               .Run();
        }
    }
}

