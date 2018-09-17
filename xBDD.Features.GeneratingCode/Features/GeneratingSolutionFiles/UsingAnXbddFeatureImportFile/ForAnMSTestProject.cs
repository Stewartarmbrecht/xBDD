namespace xBDD.Features.GeneratingCode.GeneratingSolutionFiles.UsingAnXbddFeatureImportFile
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System;
	using System.Threading.Tasks;
    using System.Runtime.CompilerServices;
	using xBDD;
	using xBDD.Utility;
	using xBDD.Features.Common;

	[AsA("Developer")]
	[SoThat("generate a new MS Test solution or new feature files for multiple projects from a single outline")]
	[YouCan("executing the 'dotnet xbdd solution generate MSTest' command in a director that has a valid solution outline")]
	[TestClass]
	public partial class ForAnMSTestProject: xBDDFeatureBase
	{

		string directory = "./MyGeneratedSample";
		string templateDirectory = "./../../../Interfaces/Files/SolutionFeatureFileTemplates";
		string[] xbddToolsCommandArgs = new[] { "solution", "generate", "MSTest" };
		Developer you = new Developer();

		private async Task ExecuteScenario(
			int number, 
			string outline, 
			string firstFeatureFilePath, 
			string secondFeatureFilePath,
			[CallerMemberName]string methodName = null) 
		{
			var outputWrapper = new Wrapper<string>();
			var featureOutlineTemplatePath1 = $"{templateDirectory}/xBddFeatureOutline{methodName}1.tmpl";
			var featureOutlineTemplatePath2 = $"{templateDirectory}/xBddFeatureOutline{methodName}2.tmpl";
			await xB.AddScenario(this, number, methodName)
				.Given(you.HaveAnEmptyDirectory("./MyGeneratedSample"))
				.And($"add a scenario outline file with the following content:",
					s => {
						var filePath = "./MyGeneratedSample/xBDDSolutionImport.txt";
						System.IO.File.WriteAllText(filePath, outline);
					}, outline, TextFormat.text)
				.When(you.RunTheXbddToolsCommand(xbddToolsCommandArgs, directory, outputWrapper))
				.Then(you.WillFindAMatchingFile(firstFeatureFilePath, featureOutlineTemplatePath1, TextFormat.cs))
				.And(you.WillFindAMatchingFile(secondFeatureFilePath, featureOutlineTemplatePath2, TextFormat.cs))
				.Run();
		}

		[TestMethod]
		public async Task WithAValidSolutionDefinition()
		{
			var outline = $@"
				Project: MyGeneratedSample.Features.Capability1
					My Capability A - My Sub Capability B
						My Feature C
							My Scenario D 
				Project: MyGeneratedSample.Features.Capability2
					My Capability E - My Sub Capability F
						My Feature G
							My Scenario H".RemoveIndentation(4, true);

			var featureOutlineFilePath1 = $"{directory}/MyGeneratedSample.Features.Capability1/xBddFeatureImport.txt";
			var featureOutlineFilePath2 = $"{directory}/MyGeneratedSample.Features.Capability2/xBddFeatureImport.txt";
			
			await this.ExecuteScenario(100, outline, featureOutlineFilePath1, featureOutlineFilePath2);
		}

		[TestMethod]
		public async Task WithNoProjects()
		{
			await xB.AddScenario(this, 1002)
//				.Given(you.HaveAnEmptySolutionFolder())
//				.And(you.CopyInABacklog(that.HasNoProjects))
//				.When(you.RunTheBackLogImportUsingTheCommand())
//					Input
//						dotnet xBDD import backlog
//				.Then(you.WillSeeOutputThatMatches(the.NoProjectOutputTemplate))
				.Skip("Defining", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithAnExistingProjectThatHasModifiedProjectFiles()
		{
			await xB.AddScenario(this, 1003)
//				.Given(you.HaveAnEmptySolutionFolder())
//				.And(you.CopyInABacklog(that.HasAllOutcomesAndReasons))
//				.And(you.RunTheBackLogImportUsingTheCommand())
//					Input
//						dotnet xBDD import backlog
//				.And(you.ModifyAStandardProjectFile())
//				.When(you.ImportTheBacklog())
//				.Then(you.WillSeeOutputThatMatches(the.AllOutcomeAndReasonsOutputTemplate))
				.Skip("Defining", Assert.Inconclusive);
		}

    }
}
