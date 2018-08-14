namespace xBDD.Features.GettingStarted
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System;
	using System.Threading.Tasks;
	using xBDD;
	using xBDD.Browser;

	[TestClass]
	[AsA("developer")]
	[YouCan("automate a basic scenario")]
	[By("using xB.AddScenario and the Given, When, Then, and And operations.")]
	public class ExecutingYourFirstScenario: IFeature
	{
		private User you = new User();

		public IOutputWriter OutputWriter { get; private set; }

		public ExecutingYourFirstScenario()
		{
			OutputWriter = new TestContextWriter();
		}
		
		[TestMethod]
		[TestCategory("Long")]
		public async Task RunningASuccessWebUITest()
		{
			var codePath = "../Amazon.Features/SearchingProducts/SearchingAllProducts.cs";
			var templateFilePath = "./GettingStarted/SampleCode/MSTestFirstPassingScenarioOutputTemplate.txt";

			Wrapper<string> output = new Wrapper<string>();
			
			await xB.AddScenario(this, 1)
				.Given(You.CodeTheFollowingMSTestFeatureDefinition(codePath))
				.When(You.RunTheMSTestProject("dotnet test --no-build -v n --filter FullyQualifiedName=Amazon.Features.SearchingProducts.SearchingAllProducts.SearchWithSearchButton", "../../../../Amazon.Features/", output))
				.Then(You.WillSeeTheOutputMatches(templateFilePath,output))
				.Run();

		}
		[TestMethod]
		[TestCategory("Long")]
		public async Task RunningAFailingWebUITest()
		{
			var codePath = "../Amazon.Features/SearchingProducts/SearchingAllProducts_Failing.cs";
			var templateFilePath = "./GettingStarted/SampleCode/MSTestFirstFailingScenarioOutputTemplate.txt";

			Wrapper<string> output = new Wrapper<string>();
			
			await xB.AddScenario(this, 2)
				.Given(You.CodeTheFollowingMSTestFeatureDefinition(codePath))
				.When(You.RunTheMSTestProject("dotnet test --no-build --filter Name~SearchWithSearchButton_Failing", "../../../../Amazon.Features/", output))
				.Then(You.WillSeeTheOutputMatches(templateFilePath,output))
				.Run();

		}
	}
}