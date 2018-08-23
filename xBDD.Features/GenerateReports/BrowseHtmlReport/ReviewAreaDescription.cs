namespace xBDD.Features.GenerateReports.BrowseHtmlReport
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System.Threading.Tasks;
	using xBDD.Features.Actors;
	using xBDD.Features.Pages;

	[TestClass]
	public class ReviewAreaDescription: FeatureTestClass
	{
		[TestMethod]
		public async Task Expand()
		{
			 await xB.CurrentRun.AddScenario(this, 1)
				.Skip("Definig", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task ExpandAll()
		{
			 await xB.CurrentRun.AddScenario(this, 2)
				.Skip("Definig", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task Collapse()
		{
			 await xB.CurrentRun.AddScenario(this, 3)
				.Skip("Definig", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task CollapseAll()
		{
			 await xB.CurrentRun.AddScenario(this, 4)
				.Skip("Definig", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task DefaultCollapsedWhenMoreThan5()
		{
			 await xB.CurrentRun.AddScenario(this, 5)
				.Skip("Definig", Assert.Inconclusive);
		}
	}
}
