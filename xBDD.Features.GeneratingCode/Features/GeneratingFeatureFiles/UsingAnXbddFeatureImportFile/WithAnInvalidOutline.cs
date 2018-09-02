namespace xBDD.Features.GeneratingCode.GeneratingFeatureFiles.UsingAnXbddFeatureImportFile
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System;
	using System.Threading.Tasks;
	using xBDD;
	using xBDD.Utility;
	using xBDD.Features.GeneratingCode.Actors;
	using xBDD.Features.GeneratingCode.Interfaces;

	[TestClass]
	[AsA("Developer")]
	[YouCan("quickly troubleshoot an invalid feature import outline")]
	[By("reviewing the detailed error messages in the xBDD tools output")]
	public partial class WithAnInvalidOutline: xBDDFeatureBase
	{

		string directory = "./MyGeneratedSample.Features";
		string[] xbddToolsCommandArgs = new[] { "project", "generate", "MSTest" };
		Developer you = new Developer();
		FileSystem an = new FileSystem();
		FileSystem.ExceptionOutputs of = new FileSystem.ExceptionOutputs();

		[TestMethod]
		[TestCategory("Now")]
		public async Task WithNoAreasAKAEmpty()
		{
			await xB.AddScenario(this, 1)
				.Given(you.HaveAnEmptyProjectDirectory())
				.And(you.Add(an.InvalidOutline.WithNoAreasAKAEmpty))
				.When(you.RunTheXbddToolsCommand(xbddToolsCommandArgs, directory))
				.Then(you.WillSeeOutputWithAnException(of.NoAreasAKAEmpty))
				.Run();
		}

		[TestMethod]
		public async Task WithNoFeatures()
		{
			await xB.AddScenario(this, 2)
				.Skip("Defining", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithNoScenarios()
		{
			await xB.AddScenario(this, 3)
				.Skip("Defining", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithAStepWithNoName()
		{
			await xB.AddScenario(this, 4)
				.Skip("Defining", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithAStepWithInvalidCharactersInTheName()
		{
			await xB.AddScenario(this, 5)
				.Skip("Defining", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithAStepWithAnInvalidChildLine()
		{
			await xB.AddScenario(this, 6)
				.Skip("Defining", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithAScenarioWithNoName()
		{
			await xB.AddScenario(this, 7)
				.Skip("Defining", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithAScenarioWithInvalidCharactersInTheName()
		{
			await xB.AddScenario(this, 8)
				.Skip("Defining", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithAScenarioWithAnInvalidChildLine()
		{
			await xB.AddScenario(this, 9)
				.Skip("Defining", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithAFeatureWithNoName()
		{
			await xB.AddScenario(this, 10)
				.Skip("Defining", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithAFeatureWithInvalidCharactersInTheName()
		{
			await xB.AddScenario(this, 11)
				.Skip("Defining", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithAFeatureWithAnInvalidChildLine()
		{
			await xB.AddScenario(this, 12)
				.Skip("Defining", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithAnAreaWithNoName()
		{
			await xB.AddScenario(this, 13)
				.Skip("Defining", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithAnAreaWithInvalidCharactersInTheName()
		{
			await xB.AddScenario(this, 14)
				.Skip("Defining", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithAnAreaWithAnInvalidChildLine()
		{
			await xB.AddScenario(this, 15)
				.Skip("Defining", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithADuplicateFeature()
		{
			await xB.AddScenario(this, 16)
				.Skip("Defining", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithADuplicateScenario()
		{
			await xB.AddScenario(this, 17)
				.Skip("Defining", Assert.Inconclusive);
		}

    }
}
