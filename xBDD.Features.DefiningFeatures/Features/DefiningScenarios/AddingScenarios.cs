namespace xBDD.Features.DefiningFeatures.DefiningScenarios
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System;
	using System.Threading.Tasks;
	using xBDD;
	using xBDD.Utility;

	[TestClass]
	[AsA("Developer")]
	[YouCan("add a scenario to a test method")]
	[SoThat("you can execute an xBDD scenario as part of a standard unit test")]
	[Explanation(@"
		xBDD is designed to run a single scenario within a standard .net unit testing framework test method.  
		To run a test method as an xBDD scenario you call the static ```xB.AddScenario()``` method
		in the unit test method.  For example:
		
		```await xB.AddScenario(this).Run();```
		
		This method is asynchronous so the testing framework must 
		support async test methods.  The ```AddScenario``` method also requires 
		a reference to the parent class because it reflects on the parent class to 
		use it's name and attributes to define the parent feature for the scenario.
	", 2)]
	public partial class AddingScenarios: xBDDFeatureBase
	{
		private xBDD.Core.CoreFactory factory = new xBDD.Core.CoreFactory();
		public async Task SampleTest(xBDD.Core.TestRunBuilder testRunBuilder)
		{
			var run = xB.CurrentRun;
			xB.CurrentRun = testRunBuilder;
			await xB.AddScenario(this)
				.Run();
			xB.CurrentRun = run;
		}

		public async Task SampleTestWithSteps(xBDD.Core.TestRunBuilder testRunBuilder)
		{
			var run = xB.CurrentRun;
			xB.CurrentRun = testRunBuilder;
			var myValue = 0;
			await xB.AddScenario(this)
				.Given("You have 1", s => {
					myValue = 1;
				})
				.When("you add 1", s => {
					myValue++;
				})
				.Then("you will have 2", s => {
					Assert.AreEqual(2, myValue);
				})
				.Run();
			xB.CurrentRun = run;
		}

		[TestMethod]
		[Explanation(@"
			You can create scenarios that do not have any steps.  This allows you
			to inventory scenarios prior to building them.  Typically you set these
			scenarios to ```.Skip()```.",3)]
		public async Task WithoutSteps()
		{
			var testRunBuilder = factory.CreateTestRunBuilder("My Test");
			await xB.AddScenario(this, 1000)
				.Given("you have the following scenario defined in a test method",
					s => {},
					@"
					await xB.AddScenario(this)
						.Run();".RemoveIndentation(5,true))
				.WhenAsync("you call the method", s => {
					return SampleTest(testRunBuilder);
				})
				.Then("the scenario will execute successfully", s => {
					Assert.AreEqual(testRunBuilder.TestRun.Scenarios.Count,1);
					Assert.AreEqual(testRunBuilder.TestRun.Scenarios[0].Outcome, xBDD.Model.Outcome.Passed);
				})
				.Run();
		}

		[TestMethod]
		[Explanation(@"
			Scenarios are broken down into steps that execute in sequence.
			The standard structure for a scenario includes defining: 
			
			1. **Given** - A 'Given' step where the starting condition is defined and setup.
			2. **When** - A 'When' step where the action is performed.  This should only perform one action.  
			If you find you are specifying multiple actions then put the more into the Given section by 
			adding more And steps after the first Given step.
			3. **Then** - A 'Then' step that performs a series of validations.  You can additional And steps after the first
			then step to perform multiple operations.",3)]
		public async Task WithSteps()
		{
			var testRunBuilder = factory.CreateTestRunBuilder("My Test");
			await xB.AddScenario(this, 1000)
				.Given("you have the following scenario defined in a test method",
					s => {},
					@"
					var myValue = 0;
					await xB.AddScenario(this)
						.Given(""You have 1"", s => {
							myValue = 1;
						})
						.When(""you add 1"", s => {
							myValue++;
						})
						.Then(""you will have 2"", s => {
							Assert.AreEqual(2, myValue);
						})
						.Run();".RemoveIndentation(5,true))
				.WhenAsync("you call the method", s => {
					return SampleTestWithSteps(testRunBuilder);
				})
				.Then("the scenario will execute successfully", s => {
					Assert.AreEqual(testRunBuilder.TestRun.Scenarios.Count,1);
					Assert.AreEqual(testRunBuilder.TestRun.Scenarios[0].Outcome, xBDD.Model.Outcome.Passed);
				})
				.Run();
		}

		[TestMethod]
		[Explanation(@"
			To make it easier to add scenarios you can quickly create scenarios 
			in Visual Studio Code using snippets that are available when you install the xBDD
			extension for VS Code.",2)]
		public async Task UsingAVisualStudioCodeSnippet()
		{
			await xB.AddScenario(this, 3000)
				.Skip("Defining", Assert.Inconclusive);
		}

	}
}