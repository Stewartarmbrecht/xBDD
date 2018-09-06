namespace xBDD.MyArea
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System;
	using System.Threading.Tasks;
	using xBDD;
	using xBDD.Utility;

	[TestClass]
	[AsA("sample user")]
	[YouCan("have my feature value")]
	[By("execute my feature")]
	[Explanation(@"
		# My Explanation
		This is a
		multiline explanation of the feature.
		**And it uses markdown!**")]
	public partial class MyFeature: xBDDFeatureBase
	{

		[TestMethod]
		[Explanation("This is an explanation of the scenario.")]
		public async Task MyScenario()
		{
			await xB.CurrentRun.AddScenario(this, 1)
				.Given("my step 1", (s) => { 

					//Add code to perform action.

				})
				.When("my step 2 with multiline input", (s) => { 

					//Add code to perform action.

					}, @"
						Here 
						is 
						my 
						Input!".RemoveIndentation(6, true), TextFormat.text
				)
				.And("my step 3 with an explanation", (s) => { 

					//Add code to perform action.

					}, null, TextFormat.text, @"
						# Step 3 Explanation 
						This is a multiline explanation of 
						Step 3.  It uses markdown.  It will
						be printed out along with the step name in the
						html report."
				)
				.Then("my step 3 with output", (s) => { 

					//Add code to perform action.

					s.Output = "Here is my output.";
					s.OutputFormat = TextFormat.text;

				})
				.Run();
		}
	}
}