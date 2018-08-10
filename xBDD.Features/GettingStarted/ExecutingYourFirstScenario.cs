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
		public async Task ThatWillTestAWebInterface()
		{
			var codePath = "..\\..\\Amazon.Features\\SearchingProducts\\SearchingAllProducts.cs";
			var outputFilePath = "..\\..\\Amazon.Features\\bin\\debug\\netcoreapp2.1\\Amazon.Features.TestOutput.txt";
			var templateFilePath = "..\\GettingStarted\\SampleCode\\MSTestFirstPassingScenarioOutputTemplate.txt";
			
			await xB.AddScenario(this, 1)
				.Given(You.CodeTheFollowingMSTestFeatureDefinition(codePath))
				.When(You.RunTheMSTestProject())
				.Then(You.WillSeeTheOutputMatches(templateFilePath,outputFilePath))
				.Run();

		}
	}
}