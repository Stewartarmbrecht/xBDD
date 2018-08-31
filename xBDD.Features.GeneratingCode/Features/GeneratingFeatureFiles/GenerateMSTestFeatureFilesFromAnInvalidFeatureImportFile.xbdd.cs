namespace xBDD.Features.GeneratingCode.GeneratingFeatureFiles
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System;
	using System.Threading.Tasks;
	using xBDD;
	using xBDD.Utility;

	
	[Generated_AsA("Developer")]
	[Generated_YouCan("generate a new MS Test Project")]
	[Generated_By("executing the 'dotnet xbdd project generate MSTest' command")]
	public partial class GenerateMSTestFeatureFilesFromAnInvalidFeatureImportFile: xBDDFeatureBase
	{

		[TestMethod]
		public async Task WithNoAreasAKAEmpty()
		{
			await xB.AddScenario(this, 1001)
				.Skip("Defining", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithNoFeatures()
		{
			await xB.AddScenario(this, 1002)
				.Skip("Defining", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithNoScenarios()
		{
			await xB.AddScenario(this, 1003)
				.Skip("Defining", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithAStepWithNoName()
		{
			await xB.AddScenario(this, 1004)
				.Skip("Defining", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithAStepWithInvalidCharactersInTheName()
		{
			await xB.AddScenario(this, 1005)
				.Skip("Defining", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithAStepWithAnInvalidChildLine()
		{
			await xB.AddScenario(this, 1006)
				.Skip("Defining", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithAScenarioWithNoName()
		{
			await xB.AddScenario(this, 1007)
				.Skip("Defining", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithAScenarioWithInvalidCharactersInTheName()
		{
			await xB.AddScenario(this, 1008)
				.Skip("Defining", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithAScenarioWithAnInvalidChildLine()
		{
			await xB.AddScenario(this, 1009)
				.Skip("Defining", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithAFeatureWithNoName()
		{
			await xB.AddScenario(this, 1010)
				.Skip("Defining", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithAFeatureWithInvalidCharactersInTheName()
		{
			await xB.AddScenario(this, 1011)
				.Skip("Defining", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithAFeatureWithAnInvalidChildLine()
		{
			await xB.AddScenario(this, 1012)
				.Skip("Defining", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithAnAreaWithNoName()
		{
			await xB.AddScenario(this, 1013)
				.Skip("Defining", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithAnAreaWithInvalidCharactersInTheName()
		{
			await xB.AddScenario(this, 1014)
				.Skip("Defining", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithAnAreaWithAnInvalidChildLine()
		{
			await xB.AddScenario(this, 1015)
				.Skip("Defining", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithADuplicateFeature()
		{
			await xB.AddScenario(this, 1016)
				.Skip("Defining", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithADuplicateScenario()
		{
			await xB.AddScenario(this, 1017)
				.Skip("Defining", Assert.Inconclusive);
		}

    }
}
