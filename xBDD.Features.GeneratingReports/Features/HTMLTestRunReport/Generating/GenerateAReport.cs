namespace xBDD.Features.GeneratingReports.HTMLTestRunReport.Generating
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System;
	using System.Threading.Tasks;
	using xBDD;
	using xBDD.Utility;

	[TestClass]
	[Assignments("Stewart")]
	public partial class GenerateAReport: xBDDFeatureBase
	{

		[TestMethod]
		public async Task WithFullTestRun()
		{
			await xB.AddScenario(this, 1000)
				.Given("you have a test run project that creates all outcomes",
					(s) => { 
						// Enter your code here.
					})
				.When("you execute the dotnet test command",
					(s) => { 
						// Enter your code here.
					},
					"dotnet test",
					TextFormat.text)
				.Then("the project will generate an Html test run report that has all features exercised",
					(s) => { 
						// Enter your code here.
					})
				.Skip("Untested", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithNoScenarios()
		{
			await xB.AddScenario(this, 2000)
				.Given("you have a test run project that does not have any scenarios",
					(s) => { 
						// Enter your code here.
					})
				.When("you execute the command",
					(s) => { 
						// Enter your code here.
					},
					"dotnet test",
					TextFormat.text)
				.Then("the project will generate an empty Html test run report",
					(s) => { 
						// Enter your code here.
					})
				.Skip("Untested", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithNoTestsInTheProject()
		{
			await xB.AddScenario(this, 3000)
				.Given("you have a test run project that does not have any tests",
					(s) => { 
						// Enter your code here.
					})
				.When("you execute the command",
					(s) => { 
						// Enter your code here.
					},
					"dotnet test",
					TextFormat.text)
				.Then("the project will generate an empty Html test run report",
					(s) => { 
						// Enter your code here.
					})
				.Skip("Untested", Assert.Inconclusive);
		}

	}
}