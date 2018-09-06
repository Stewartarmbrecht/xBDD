namespace MySample.Features.TestRun1Passing.Area1PassingWithAllFeaturesExercised
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System;
	using System.Threading.Tasks;
	using xBDD;
	using xBDD.Utility;

	[TestClass]
	[AsA("User")]
	[YouCan("derive some value")]
	[By("doing something")]
	[Explanation(@"
		# Feature 1 Explanation
		This is my feature 1 explanation.",2)]
	[Assignments("FeatureAssignment1","FeatureAssignment2")]
	[Tags("FeatureTag1","FeatureTag2")]
	public partial class Feature1Passing: xBDDFeatureBase
	{

		[TestMethod]
		[Explanation(@"
			# Scenario 1 Explanation
			This is my scenario 1 explanation.",3)]
		[Assignments("ScenarioAssignment1","ScenarioAssignment2")]
		[Tags("ScenarioTag1","ScenarioTag2")]
		public async Task Scenario1Passing()
		{
			await xB.AddScenario(this, 1000)
				.Given("Step 1 Passing With Explanation And Input",
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
				.When("Step 2 Passing With Output",
					(s) => { 
						// Enter your code here.
					})
				.Then("Step 3 Passing With Html Preview Output",
					(s) => { 
						// Enter your code here.
					})
				.Run();
		}

	}
}