namespace xBDD.Features.GeneratingCode.GeneratingSolutionFiles
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System;
	using System.Threading.Tasks;
	using xBDD;
	using xBDD.Utility;

	
	[Generated_AsA("Developer")]
	[Generated_YouCan("generate a new MS Test Project")]
	[Generated_By("executing the 'dotnet xbdd project generate MSTest' command")]
	public partial class GenerateCodeFromASolutionLevelFeatureImportFile: xBDDFeatureBase
	{

		[TestMethod]
		public async Task WithAllTestRunOutcomes()
		{
			await xB.AddScenario(this, 1001)
//				.Given(you.HaveAnEmptySolutionFolder())
//				.And(you.CopyInABacklog(that.HasAllOutcomesAndReasons))
//				.When(you.RunTheBackLogImportUsingTheCommand())
//					Input
//						dotnet xBDD import backlog
//				.Then(you.WillNotFindStandardProjectFiles(at.TestRun1Passing).Because(“passed scenarios are skipped when generating code from a backlog”))
//				.And(you.WillFindStandardProjectFiles(at.TestRun2Untested))
//				.And(you.WillFindStandardProjectFiles(at.TestRun3SkippedCommitted))
//				.And(you.WillFindStandardProjectFiles(at.TestRun4SkippedReady))
//				.And(you.WillFindStandardProjectFiles(at.TestRun5SkippedDefining))
//				.And(you.WillFindStandardProjectFiles(at.TestRun6Failed))
//				.And(you.WillFindAFeatureFile(for.TestRun6Failed.Area6.Feature6Failed.FilePath, thatMatches.TestRun6Failed.Area6Failed.Feature6Failed.FileContent)
//				.And(you.WillNotFindAFeatureFile(for.TestRun2SkippedCommitted.Area1.Feature1Passed.File))
				.Skip("Defining", Assert.Inconclusive);
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
