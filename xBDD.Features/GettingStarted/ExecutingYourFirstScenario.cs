namespace xBDD.Features.GettingStarted
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System.Threading.Tasks;
	using xBDD.Features.Actors;
	using xBDD.Features.Pages;

	[TestClass]
	[AsA("developer")]
	[YouCan("automate a basic scenario")]
	[By("using xB.AddScenario and the Given, When, Then, and And operations.")]
	public class ExecutingYourFirstScenario: xBDDFeatureBase
	{
		private Developer you = new Developer();

		[TestMethod]
		public async Task ThatPasses()
		{
			var pathToFeatureClass = "../MySample.Features/MyFirstArea/MyFirstFeature.cs";
			var pathToOutputFile = "../MySample.Features/test-results/MySample.Features.Results.FirstPassing.txt";
			var pathToTemplateFile = "../xBDD.Features/GettingStarted/ExecutingYourFirstScenario.ThatPasses.txt";
			await xB.AddScenario(this, 1)
				.Given(you.HaveTheFollowingClass("that defines your first scenario", pathToFeatureClass))
				.When(you.ExecuteTheTestRun())
				.Then(you.WillSeeTheOutputMatches(pathToTemplateFile, pathToOutputFile))
				.Run();
		}
		[TestMethod]
		[TestCategory("Long")]
		public async Task ThatFailed()
		{
			var pathToFeatureClass = "../MySample.Features/MyFirstArea/MyFirstFailingFeature.cs";
			var pathToOutputFile = "../MySample.Features/test-results/MySample.Features.Results.FirstFailing.txt";
			var pathToTemplateFile = "../xBDD.Features/GettingStarted/ExecutingYourFirstScenario.ThatFailed.txt";
			await xB.AddScenario(this, 1)
				.Given(you.HaveTheFollowingClass("that defines your first failing scenario", pathToFeatureClass))
				.When(you.ExecuteTheTestRun())
				.Then(you.WillSeeTheOutputMatches(pathToTemplateFile, pathToOutputFile))
				.Run();
		}
	}
}