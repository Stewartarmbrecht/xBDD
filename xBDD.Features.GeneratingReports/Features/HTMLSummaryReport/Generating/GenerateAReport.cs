namespace xBDD.Features.GeneratingReports.HTMLSummaryReport.Generating
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
				.Given("you have the following json test run reports",
					(s) => { 
						// Enter your code here.
					},
					@"
						./MySamle.Features.TestRun1Passing/test-results/MySamle.Features.TestRun1Passing.json
						./MySamle.Features.TestRun2SkippedUntested/test-results/MySamle.Features.TestRun2SkippedUntested.json
						./MySamle.Features.TestRun3SkippedBuilding/test-results/MySamle.Features.TestRun3SkippedBuilding.json
						./MySamle.Features.TestRun4SkippedReady/test-results/MySamle.Features.TestRun4SkippedReady.json
						./MySamle.Features.TestRun5SkippedDefining/test-results/MySamle.Features.TestRun5SkippedReady.json
						./MySamle.Features.TestRun6Failed/test-results/MySamle.Features.TestRun6Failed.json".RemoveIndentation(6,true),
					TextFormat.text)
				.When("you execute the xBDD Tools Command",
					(s) => { 
						// Enter your code here.
					},
					@"
						dotnet xbdd solution summarize `
						./MySamle.Features.TestRun1Passing/test-results/MySamle.Features.TestRun1Passing.json `
						./MySamle.Features.TestRun2SkippedUntested/test-results/MySamle.Features.TestRun2SkippedUntested.json `
						./MySamle.Features.TestRun3SkippedBuilding/test-results/MySamle.Features.TestRun3SkippedBuilding.json `
						./MySamle.Features.TestRun4SkippedReady/test-results/MySamle.Features.TestRun4SkippedReady.json `
						./MySamle.Features.TestRun5SkippedDefining/test-results/MySamle.Features.TestRun5SkippedReady.json `
						./MySamle.Features.TestRun6Failed/test-results/MySamle.Features.TestRun6Failed.json `".RemoveIndentation(6,true),
					TextFormat.text)
				.Then("the project will generate an Html summary report",
					(s) => { 
						// Enter your code here.
					},
					"./MySample/test-results/MySample.Summary.html",
					TextFormat.text)
				.And("you can view the report in a browser",
					(s) => { 
						// Enter your code here.
					})
				.Skip("Committed", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithNoJsonFiles()
		{
			await xB.AddScenario(this, 2000)
				.Skip("Defining", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithAnInvalidJsonFile()
		{
			await xB.AddScenario(this, 3000)
				.Skip("Defining", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithASingleJsonFile()
		{
			await xB.AddScenario(this, 4000)
				.Skip("Defining", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithAMissingJsonFile()
		{
			await xB.AddScenario(this, 5000)
				.Skip("Defining", Assert.Inconclusive);
		}

	}
}