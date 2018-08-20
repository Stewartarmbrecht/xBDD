namespace xBDD.Features.GettingStarted
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
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
	public class LeveragingReusableSteps: FeatureTestClass
	{
		Developer you = new Developer();

		[TestMethod]
		public async Task ByUsingAnActorClass()
		{
			var pathToActorClass = "../MySample.Features/Actors/MyActor.cs";
			var pathToFeatureClass = "../MySample.Features/MyArea_1_AllPassing/MyFeature_4_Passing_ReusableSteps.cs";
			var pathToOutputFile = "../MySample.Features/test-results/MySample.Features.Results.Passing.txt";
			var pathToTemplateFile = "../xBDD.Features/GettingStarted/LeveragingReusableSteps.ByUsingAnActorClass.template";
			await xB.AddScenario(this, 1)
				.Given(you.HaveTheFollowingClass("for defining reusable steps", pathToActorClass))
				.And(you.HaveTheFollowingClass("that defines a feature using the reusable steps", pathToFeatureClass))
				.When(you.ExecuteTheTestRun())
				.Then(you.WillSeeTheOutputMatches(pathToTemplateFile, pathToOutputFile))
				.Run();
		}
	}
}