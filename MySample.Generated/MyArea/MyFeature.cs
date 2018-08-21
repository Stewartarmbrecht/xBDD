namespace MySample.Generated.MyArea
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
	using System.Threading.Tasks;
	using xBDD;

    [TestClass]
    [AsA("sample user")]
    [YouCan("have my feature value")]
    [By("execute my feature")]
    public class MyFeature: FeatureTestClass
    {

        [TestMethod]
        public async Task MyScenario()
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
    }
}