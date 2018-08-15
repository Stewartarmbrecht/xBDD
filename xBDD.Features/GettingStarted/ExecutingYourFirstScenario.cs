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
	public class ExecutingYourFirstScenario: IFeature
	{
		private Developer you = new Developer();

		public IOutputWriter OutputWriter { get; private set; }

		public ExecutingYourFirstScenario()
		{
			OutputWriter = new TestContextWriter();
		}
		
		[TestMethod]
		[TestCategory("Long")]
		public async Task ExecutingAPassingWebUIScenarioInAnMSTestProject()
		{
			var codePath = "../Amazon.Features/SearchingProducts/SearchingAllProducts.cs";
			var templateFilePath = "./GettingStarted/MSTestFirstPassingScenarioOutputTemplate.txt";

			Wrapper<string> output = new Wrapper<string>();
			
			await xB.AddScenario(this, 1)
				.Given(you.HaveTheFollowingClass("for defining a passing scenario", codePath))
				.When(you.RunTheMSTestProject("dotnet test -v n --filter FullyQualifiedName=Amazon.Features.SearchingProducts.SearchingAllProducts.SearchWithSearchButton", "../../../../Amazon.Features/", output))
				.Then(you.WillSeeTheOutputMatches(templateFilePath,output))
				.Run();

		}
		[TestMethod]
		[TestCategory("Long")]
		public async Task ExecutingAFailingWebUIScenarioInAnMSTestProject()
		{
			var codePath = "../Amazon.Features/SearchingProducts/SearchingAllProducts_Failing.cs";
			var templateFilePath = "./GettingStarted/MSTestFirstFailingScenarioOutputTemplate.txt";

			Wrapper<string> output = new Wrapper<string>();
			
			await xB.AddScenario(this, 2)
				.Given(you.HaveTheFollowingClass("that defines a failing scenario", codePath))
				.When(you.RunTheMSTestProject("dotnet test --filter Name~SearchWithSearchButton_Failing", "../../../../Amazon.Features/", output))
				.Then(you.WillSeeTheOutputMatches(templateFilePath,output))
				.Run();

		}
	}
}