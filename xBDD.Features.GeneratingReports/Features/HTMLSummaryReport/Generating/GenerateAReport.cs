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

		string directory = $"{System.IO.Directory.GetCurrentDirectory()}/../../../../MySample/";

		string summaryReportName = "MySample.TestSummary.WithFullTestRun.html";

		string[] jsonReportFilePaths => new[] {
			"./MySample.Features.TestRun1Passing/test-results/MySample.Features.TestRun1Passing.Results.json",
			"./MySample.Features.TestRun2SkippedUntested/test-results/MySample.Features.TestRun2SkippedUntested.Results.json",
			"./MySample.Features.TestRun3SkippedCommitted/test-results/MySample.Features.TestRun3SkippedCommitted.Results.json",
			"./MySample.Features.TestRun4SkippedReady/test-results/MySample.Features.TestRun4SkippedReady.Results.json",
			"./MySample.Features.TestRun5SkippedDefining/test-results/MySample.Features.TestRun5SkippedDefining.Results.json",
			"./MySample.Features.TestRun6Failed/test-results/MySample.Features.TestRun6Failed.Results.json"
		};
		string jsonReports => string.Join($",{Environment.NewLine}", jsonReportFilePaths);
		string[] xbddSummaryCommandStart => new[] { "solution", "summarize", 
			"--output", summaryReportName, 
			"--name", "My Sample - Features",
			"--testrun-name-clip", "My Sample - Features - ", 
			"--reason-order", "Untested, Committed, Ready, Defining"};
		string[] xbddSummaryCommandArgs => xbddSummaryCommandStart.Concat(jsonReportFilePaths).ToArray();
		string xbddSummaryCommand => $"dotnet xbdd {string.Join(" ", xbddSummaryCommandStart)} `{Environment.NewLine}{string.Join($" `{Environment.NewLine}", jsonReportFilePaths)}";

		[TestMethod]
		public async Task WithFullTestRun()
		{
			var outputTemplate = "./../../../Features/HTMLSummaryReport/Generating/GenerateAReport.WithFullTestRun.tmpl";
			Wrapper<string> output = new Wrapper<string>();
			await xB.AddScenario(this, 1000)
				.Given("you have the following json test run reports",
					(s) => { 
						var currentDirectory = System.IO.Directory.GetCurrentDirectory();
						try {
							System.IO.Directory.SetCurrentDirectory("./../../../../MySample/");
							foreach(string jsonFilePath in jsonReportFilePaths) {
								Assert.IsTrue(System.IO.File.Exists(jsonFilePath), 
									$"The file ('{jsonFilePath}') does not exist.");
							}
							System.IO.Directory.SetCurrentDirectory(currentDirectory);
						} catch {
							System.IO.Directory.SetCurrentDirectory(currentDirectory);
						}
					},
					this.jsonReports,
					TextFormat.text)
				.When(you.RunTheXbddToolsCommand(this.xbddSummaryCommandArgs, directory, output))
				.Then(you.WillSeeOutput(outputTemplate, output, true))
				.And(you.WillFind($"a new HTML Report created at './{summaryReportName}'", TextFormat.htmlpreview, $"{directory}{summaryReportName}"))
				.Run();
		}

		[TestMethod]
		public async Task WithNoJsonFiles()
		{
			var outputTemplate = "./../../../Features/HTMLSummaryReport/Generating/GenerateAReport.WithNoJsonFiles.Output.tmpl";
			var reportTemplate = "./../../../Features/HTMLSummaryReport/Generating/GenerateAReport.WithNoJsonFiles.Report.tmpl";
			var summaryReportPath = "./MySample.TestSummary.WithNoJsonFiles.html";
			string[] xbddSummaryCommandWithNoFiles = new[] { 
				"solution", 
				"summarize", 
				"--output", summaryReportPath, 
				"--name", "My Sample - Features",
				"--testrun-name-clip", "My Sample - Features - ", 
				"--reason-order", "Untested, Committed, Ready, Defining"};
			Wrapper<string> output = new Wrapper<string>();
			await xB.AddScenario(this, 2000)
				.Given(you.DoNotHave("a summary report file", summaryReportPath))
				.When(you.RunTheXbddToolsCommand(xbddSummaryCommandWithNoFiles, directory, output))
				.Then(you.WillSeeOutput(outputTemplate, output, true))
				.And(you.WillFindAMatchingFile($"{directory}{summaryReportPath}", reportTemplate, TextFormat.html))
				.Run();
		}

		[TestMethod]
		public async Task WithASingleJsonFile()
		{
			var outputTemplate = "./../../../Features/HTMLSummaryReport/Generating/GenerateAReport.WithASingleJsonFile.Output.tmpl";
			var reportTemplate = "./../../../Features/HTMLSummaryReport/Generating/GenerateAReport.WithASingleJsonFile.Report.tmpl";
			var summaryReportPath = "./MySample.TestSummary.WithASingleJsonFile.html";
			string[] xbddSummaryCommandWithNoFiles = new[] { 
				"solution", 
				"summarize", 
				"--output", summaryReportPath, 
				"--name", "My Sample - Features",
				"--testrun-name-clip", "My Sample - Features - ", 
				"--reason-order", "Untested, Committed, Ready, Defining",
				"./MySample.Features.TestRun1Passing/test-results/MySample.Features.TestRun1Passing.Results.json"};
			Wrapper<string> output = new Wrapper<string>();
			await xB.AddScenario(this, 2000)
				.Given(you.DoNotHave("a summary report file", summaryReportPath))
				.When(you.RunTheXbddToolsCommand(xbddSummaryCommandWithNoFiles, directory, output))
				.Then(you.WillSeeOutput(outputTemplate, output, true))
				.And(you.WillFindAMatchingFile($"{directory}/{summaryReportPath}", reportTemplate, TextFormat.html))
				.Run();
		}

		[TestMethod]
		public async Task WithAMissingJsonFile()
		{
			var outputTemplate = "./../../../Features/HTMLSummaryReport/Generating/GenerateAReport.WithAMissingJsonFile.Output.tmpl";
			var summaryReportPath = "./MySample.TestSummary.WithAMissingJsonFile.html";
			string[] xbddSummaryCommandWithNoFiles = new[] { 
				"solution", 
				"summarize", 
				"--output", summaryReportPath, 
				"--name", "My Sample - Features",
				"--testrun-name-clip", "My Sample - Features - ", 
				"--reason-order", "Untested, Committed, Ready, Defining",
				"./Missing.json"};
			Wrapper<string> output = new Wrapper<string>();
			await xB.AddScenario(this, 2000)
				.Given(you.DoNotHave("a summary report file", summaryReportPath))
				.When(you.RunTheXbddToolsCommand(xbddSummaryCommandWithNoFiles, directory, output))
				.Then(you.WillSeeOutput(outputTemplate, output, true))
				.And(you.WillNotFind("the html report", $"{directory}{summaryReportPath}"))
				.Run();
		}

	}
}