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
			"./MySample.Features.TestRun1Passing/test-results/MySample.Features.TestRun1Passing.Results.html",
			"./MySample.Features.TestRun2SkippedUntested/test-results/MySample.Features.TestRun2SkippedUntested.Results.json",
			"./MySample.Features.TestRun2SkippedUntested/test-results/MySample.Features.TestRun2SkippedUntested.Results.html",
			"./MySample.Features.TestRun3SkippedCommitted/test-results/MySample.Features.TestRun3SkippedCommitted.Results.json",
			"./MySample.Features.TestRun3SkippedCommitted/test-results/MySample.Features.TestRun3SkippedCommitted.Results.html",
			"./MySample.Features.TestRun4SkippedReady/test-results/MySample.Features.TestRun4SkippedReady.Results.json",
			"./MySample.Features.TestRun4SkippedReady/test-results/MySample.Features.TestRun4SkippedReady.Results.html",
			"./MySample.Features.TestRun5SkippedDefining/test-results/MySample.Features.TestRun5SkippedDefining.Results.json",
			"./MySample.Features.TestRun5SkippedDefining/test-results/MySample.Features.TestRun5SkippedDefining.Results.html",
			"./MySample.Features.TestRun6Failed/test-results/MySample.Features.TestRun6Failed.Results.json",
			"./MySample.Features.TestRun6Failed/test-results/MySample.Features.TestRun6Failed.Results.html"
		};
		string jsonReports => string.Join($",{Environment.NewLine}", jsonReportFilePaths);
		[TestMethod]
		public async Task WithFullTestRun()
		{
			var outputTemplate = "./../../../Features/HTMLSummaryReport/Generating/GenerateAReport.WithFullTestRun.tmpl";
			var configFile = "./../xBDD.Features.GeneratingReports/Features/HTMLSummaryReport/Generating/GenerateAReport.WithFullTestRun.Config.json";
			string[] xbddSummaryCommandWithFullTestRun = new[] { 
				"solution", 
				"summarize", 
				"--config-file", configFile};
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
				.When(you.RunTheXbddToolsCommand(xbddSummaryCommandWithFullTestRun, directory, output))
				.Then(you.WillSeeOutput(outputTemplate, output, true))
				.And(you.WillFind($"a new HTML Report created at './{summaryReportName}'", TextFormat.htmlpreview, $"{directory}{summaryReportName}"))
				.Run();
		}

		[TestMethod]
		public async Task WithNoJsonFiles()
		{
			var outputTemplate = "./../../../Features/HTMLSummaryReport/Generating/GenerateAReport.WithNoJsonFiles.Output.tmpl";
			var configFile = "./../xBDD.Features.GeneratingReports/Features/HTMLSummaryReport/Generating/GenerateAReport.WithNoJsonFiles.Config.json";
			var summaryReportPath = "./../../../../MySample/MySample.TestSummary.WithNoJsonFiles.html";
			string[] xbddSummaryCommandWithNoFiles = new[] { 
				"solution", 
				"summarize", 
				"--config-file", configFile};
			Wrapper<string> output = new Wrapper<string>();
			await xB.AddScenario(this, 2000)
				.Given(you.DoNotHave("a summary report file", summaryReportPath))
				.When(you.RunTheXbddToolsCommand(xbddSummaryCommandWithNoFiles, directory, output))
				.Then(you.WillSeeOutput(outputTemplate, output, true))
				.And(you.WillNotFind("a summary report file", summaryReportPath))
				//.And(you.WillFindAMatchingFile($"{directory}{summaryReportPath}", reportTemplate, TextFormat.html))
				.Run();
		}

		[TestMethod]
		public async Task WithASingleJsonFile()
		{
			var outputTemplate = "./../../../Features/HTMLSummaryReport/Generating/GenerateAReport.WithASingleJsonFile.Output.tmpl";
			var reportTemplate = "./../../../Features/HTMLSummaryReport/Generating/GenerateAReport.WithASingleJsonFile.Report.tmpl";
			var summaryReportPath = "./../../../../MySample/MySample.TestSummary.WithASingleJsonFile.html";
			var configFile = "./../xBDD.Features.GeneratingReports/Features/HTMLSummaryReport/Generating/GenerateAReport.WithASingleJsonFile.Config.json";
			string[] xbddSummaryCommandWithNoFiles = new[] { 
				"solution", 
				"summarize", 
				"--config-file", configFile};
			Wrapper<string> output = new Wrapper<string>();
			await xB.AddScenario(this, 2000)
				.Given(you.DoNotHave("a summary report file", summaryReportPath))
				.When(you.RunTheXbddToolsCommand(xbddSummaryCommandWithNoFiles, directory, output))
				.Then(you.WillSeeOutput(outputTemplate, output, true))
				.And(you.WillFindAMatchingFile(summaryReportPath, reportTemplate, TextFormat.html))
				.Run();
		}

		[TestMethod]
		public async Task WithAMissingJsonFile()
		{
			var outputTemplate = "./../../../Features/HTMLSummaryReport/Generating/GenerateAReport.WithAMissingJsonFile.Output.tmpl";
			var summaryReportPath = "./../../../../MySample/MySample.TestSummary.WithAMissingJsonFile.html";
			var configFile = "./../xBDD.Features.GeneratingReports/Features/HTMLSummaryReport/Generating/GenerateAReport.WithAMissingJsonFile.Config.json";
			string[] xbddSummaryCommandWithNoFiles = new[] { 
				"solution", 
				"summarize", 
				"--config-file", configFile};
			Wrapper<string> output = new Wrapper<string>();
			await xB.AddScenario(this, 2000)
				.Given(you.DoNotHave("a summary report file", summaryReportPath))
				.When(you.RunTheXbddToolsCommand(xbddSummaryCommandWithNoFiles, directory, output))
				.Then(you.WillSeeOutput(outputTemplate, output, true))
				.And(you.WillNotFind("the html report", summaryReportPath))
				.Run();
		}

	}
}