namespace xBDD.Features.GeneratingReports.HTMLTestRunReport.Generating
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System;
	using System.Threading.Tasks;
	using xBDD;
	using xBDD.Utility;

	[TestClass]
	[Assignments("Stewart")]
	public partial class GenerateAFailuresOnlyReport: xBDDFeatureBase
	{

		[TestMethod]
		public async Task WithFailures()
		{
			await xB.AddScenario(this, 1000)
				.Given("you have a test run project that creates all outcomes",
					(s) => { 
						// Enter your code here.
					})
				.When("you execute the dotnet test command with the failures only environment variable set to true",
					(s) => { 
						// Enter your code here.
					},
					@"
						$Emv:xBDD:HtmlReport:FailuresOnly = ""true""
						dotnet test".RemoveIndentation(6,true),
					TextFormat.text)
				.Then("the project will generate an Html test run report that has only the failed scenarios",
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
				.When("you execute the dotnet test command with the failures only environment variable set to true",
					(s) => { 
						// Enter your code here.
					},
					@"
						$Emv:xBDD:HtmlReport:FailuresOnly = ""true""
						dotnet test".RemoveIndentation(6,true),
					TextFormat.text)
				.Then("the project will generate an empty Html test run report",
					(s) => { 
						// Enter your code here.
					})
				.Skip("Untested", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithNoFailures()
		{
			await xB.AddScenario(this, 3000)
				.Given("you have a test run project that is passing",
					(s) => { 
						// Enter your code here.
					})
				.When("you execute the dotnet test command with the failures only environment variable set to true",
					(s) => { 
						// Enter your code here.
					},
					@"
						$Emv:xBDD:HtmlReport:FailuresOnly = ""true""
						dotnet test".RemoveIndentation(6,true),
					TextFormat.text)
				.Then("the project will generate an Html test run report that has only the failed scenarios",
					(s) => { 
						// Enter your code here.
					})
				.Skip("Untested", Assert.Inconclusive);
		}

	}
}