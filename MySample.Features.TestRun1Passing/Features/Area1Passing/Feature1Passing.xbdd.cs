namespace MySample.Features.TestRun1Passing.Area1Passing
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System;
	using System.Threading.Tasks;
	using xBDD;
	using xBDD.Utility;

	
	[Generated_AsA("User")]
	[Generated_YouCan("derive some value")]
	[Generated_By("doing something")]
	[Generated_Explanation(@"
		# Feature 1 Explanation
		This is my feature 1 explanation.",2)]
	public partial class Feature1Passing: xBDDFeatureBase
	{

		[TestMethod]
		[Explanation(@"
			# Scenario 1 Explanation
			This is my scenario 1 explanation.",3)]
		public async Task Scenario1Passing()
		{
			await xB.AddScenario(this, 1001)
				.Given("Step 1 Passing", 
					(s) => { 
						// Enter your code here. 
					},
					@"
						Here 
						is some multiline
						input".RemoveIndentation(6,true), 
					TextFormat.text,
					@"
						# Step 1 Explanation
						This is my step 1 explanation.".RemoveIndentation(6,true))
				.When("Step 2 Passing", 
					(s) => { 
						// Enter your code here. 
					})
				.Then("Step 3 Passing", 
					(s) => { 
						// Enter your code here. 
					})
				.Skip("Defining", Assert.Inconclusive);
		}

    }
}
