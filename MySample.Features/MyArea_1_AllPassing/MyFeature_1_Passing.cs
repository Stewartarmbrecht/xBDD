namespace MySample.Features.MyArea_1_AllPassing
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
	using System.Threading.Tasks;
	using xBDD;

    [TestClass]
    [AsA("sample user")]
    [YouCan("have my feature 1 value")]
    [By("execute my feature 1")]
    public class MyFeature_1_Passing: FeatureTestClass
    {

        [TestMethod]
        public async Task MyScenario_1()
        {
			var input = $"Here{System.Environment.NewLine} is{System.Environment.NewLine} my{System.Environment.NewLine} Input!";
			var format = TextFormat.text;
            await xB.CurrentRun.AddScenario(this, 1)
                .Given("my step 1", (s) => { 
                    //Add code to perform action.
                 })
                .When("my step 2 with multiline input", (s) => { 
                    //Add code to perform action.
                 }, input, format)
                .Then("my step 3 with output", (s) => { 
                    //Add code to perform action.
                    s.Output = input;
                    s.OutputFormat = format;
                 })
                .Run();
        }

        [TestMethod]
        public async Task MyScenario_2()
        {
            await xB.CurrentRun.AddScenario(this, 2)
                .Given("my step 4", (s) => {  })
                .When("my step 5", (s) => {  })
                .Then("my step 6", (s) => {  })
                .Run();
        }

        [TestMethod]
        public async Task MyScenario_3()
        {
            await xB.CurrentRun.AddScenario(this, 3)
                .Given("my step 7", (s) => {  })
                .When("my step 8", (s) => {  })
                .Then("my step 9", (s) => {  })
                .Run();
        }
    }
}

