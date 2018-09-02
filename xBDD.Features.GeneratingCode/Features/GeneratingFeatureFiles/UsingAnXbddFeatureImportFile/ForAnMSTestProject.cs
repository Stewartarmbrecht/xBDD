namespace xBDD.Features.GeneratingCode.GeneratingFeatureFiles.UsingAnXbddFeatureImportFile
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System;
	using System.Threading.Tasks;
	using xBDD;
	using xBDD.Utility;

	[TestClass]
	[AsA("Developer")]
	[YouCan("generate a new MS Test Project")]
	[By("executing the 'dotnet xbdd project generate MSTest' command")]
	public partial class ForAnMSTestProject: xBDDFeatureBase
	{
		[TestMethod]
		public async Task WithAnEmptyScenario()
		{
			await xB.AddScenario(this, 1001)
				.Skip("Defining", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithAGivenStep()
		{
			await xB.AddScenario(this, 1002)
				.Skip("Defining", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithAWhenStep()
		{
			await xB.AddScenario(this, 1003)
				.Skip("Defining", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithAThenStep()
		{
			await xB.AddScenario(this, 1004)
				.Skip("Defining", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithAnAndStep()
		{
			await xB.AddScenario(this, 1005)
				.Skip("Defining", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithACodeStep()
		{
			await xB.AddScenario(this, 1006)
				.Skip("Defining", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithAStepInput()
		{
			await xB.AddScenario(this, 1007)
				.Skip("Defining", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithAStepExplanation()
		{
			await xB.AddScenario(this, 1008)
				.Skip("Defining", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithAStepWithTrailingSpaces()
		{
			await xB.AddScenario(this, 1009)
				.Skip("Defining", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithAScenarioExplanation()
		{
			await xB.AddScenario(this, 1010)
				.Skip("Defining", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithAScenarioWithTrailingSpaces()
		{
			await xB.AddScenario(this, 1011)
				.Skip("Defining", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithScenarioReasonTags()
		{
			await xB.AddScenario(this, 1012)
				.Skip("Defining", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithScenarioOwnerTags()
		{
			await xB.AddScenario(this, 1013)
				.Skip("Defining", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithAnExistingFeature()
		{
			await xB.AddScenario(this, 1014)
				.Skip("Defining", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithAFeatureExplanation()
		{
			await xB.AddScenario(this, 1015)
				.Skip("Defining", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithAFeatureWithTrailingSpaces()
		{
			await xB.AddScenario(this, 1016)
				.Skip("Defining", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithAnAreaWithTrailingSpaces()
		{
			await xB.AddScenario(this, 1017)
				.Skip("Defining", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithIgnoredFeatureTags()
		{
			await xB.AddScenario(this, 1018)
				.Skip("Defining", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithIgnoredAreaTags()
		{
			await xB.AddScenario(this, 1019)
				.Skip("Defining", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithAWorkflowyTextExport()
		{
			await xB.AddScenario(this, 1020)
				.Skip("Defining", Assert.Inconclusive);
		}


    }
}
