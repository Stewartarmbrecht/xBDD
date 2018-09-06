namespace xBDD.Features.GeneratingReports.HTMLSummaryReport.Generating
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System;
	using System.Threading.Tasks;
	using System.Linq;
	using System.Linq.Expressions;
	using xBDD;
	using xBDD.Utility;
	using xBDD.Features.Common;

	[TestCategory("Now")]
	[TestClass]
	[Assignments("Stewart")]
	public partial class GenerateAReport: xBDDFeatureBase
	{
		Developer you = new Developer();

		string directory = "./../../../../";

		string[] jsonReports => new[] {
			"./MySamle.Features.TestRun1Passing/test-results/MySamle.Features.TestRun1Passing.json",
			"./MySamle.Features.TestRun2SkippedUntested/test-results/MySamle.Features.TestRun2SkippedUntested.json",
			"./MySamle.Features.TestRun3SkippedBuilding/test-results/MySamle.Features.TestRun3SkippedBuilding.json",
			"./MySamle.Features.TestRun4SkippedReady/test-results/MySamle.Features.TestRun4SkippedReady.json",
			"./MySamle.Features.TestRun5SkippedDefining/test-results/MySamle.Features.TestRun5SkippedReady.json",
			"./MySamle.Features.TestRun6Failed/test-results/MySamle.Features.TestRun6Failed.json"
		};
		string jsonReportString => string.Join($",{Environment.NewLine}", jsonReports);
		string[] xbddSummaryCommand => new[] { "dotnet", "xbdd", "solution", "summary" };
		string[] xbddFullSummaryCommend => xbddSummaryCommand.Concat(jsonReports).ToArray();
		string xbddFullSummaryCommandString => string.Join($",{Environment.NewLine}", xbddFullSummaryCommend);

		[TestMethod]
		public async Task WithFullTestRun()
		{
			Wrapper<string> output = new Wrapper<string>();
			await xB.AddScenario(this, 1000)
				.Given("you have the following json test run reports",
					(s) => { 
						try {
							System.IO.Directory.SetCurrentDirectory("./../../../../");
							foreach(string jsonFilePath in jsonReports) {
								Assert.IsTrue(System.IO.File.Exists(jsonFilePath), 
									$"The file ('{jsonFilePath}') does not exist.");
							}
							System.IO.Directory.SetCurrentDirectory("./../../../../");
						} catch {
							System.IO.Directory.SetCurrentDirectory("./../../../../");
						}
					},
					this.jsonReportString,
					TextFormat.text)
				.When(you.RunTheXbddToolsCommand(this.xbddFullSummaryCommend, directory, output))
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
				.Run();
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