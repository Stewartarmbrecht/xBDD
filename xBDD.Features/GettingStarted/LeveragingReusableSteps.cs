namespace xBDD.Features.GettingStarted
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using Amazon.Features.SearchingProducts;
	using System;
	using System.Collections.Generic;
	using System.Threading.Tasks;
	using xBDD.Features.Actors;
	using xBDD.Features.Pages;
	using xBDD.Model;

	[TestClass]
	[AsA(Developer.Name)]
	[YouCan("simplify the development of tests")]
	[By("using a library of reusable steps")]
	public class LeveragingReusableSteps
	{
		Developer you = new Developer();
		private readonly TestContextWriter outputWriter;

		public LeveragingReusableSteps()
		{
			outputWriter = new TestContextWriter();
		}
		
		[TestMethod]
		public async Task ByInheritingFromTheUserClass()
		{
			var pathToActorClass = "../Amazon.Features/Actors/AnonymousUser.cs";
			var pathToFeatureClass = "../Amazon.Features/SearchingProducts/SearchingAllProducts_ReusableSteps.cs";
			List<Func<Task>> scenarios = new List<Func<Task>>();
			var feature = new SearchingAllProducts_ReusableSteps();
			scenarios.Add(feature.SearchWithSearchButton_ReusableSteps);
			scenarios.Add(feature.SearchWithEnter_ReusableSteps);
			xBDDMock xBMock = new xBDDMock();
			await xB.AddScenario(this, 1)
				.Given(you.HaveTheFollowingClass("for defining reusable steps", pathToActorClass))
				.And(you.HaveTheFollowingClass("that defines a feature using the reusable steps", pathToFeatureClass))
				.When(you.RunTheTests(scenarios, xBMock))
				.Then("you will execute the scenarios and get the results", step => {
					Assert.AreEqual(xBMock.CurrentRun.TestRun.Outcome, Outcome.Passed);
					Assert.AreEqual(xBMock.CurrentRun.TestRun.Scenarios.Count, 2);
					Assert.AreEqual(xBMock.CurrentRun.TestRun.Scenarios[0].Outcome, Outcome.Passed);
					Assert.AreEqual(xBMock.CurrentRun.TestRun.Scenarios[1].Outcome, Outcome.Passed);
					step.Output = xBMock.CurrentRun.TestRun.WriteToJson(true);
					step.OutputFormat = TextFormat.js;
				})
				.Run();
		}
	}
}