namespace xBDD.Features.GenerateReports.BrowseHtmlReport
{
	using xBDD.Features;
	using xBDD.Browser;
	using xBDD.Features.Pages.HtmlReportPage;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using xBDD.Features.Steps;
	using System.Threading.Tasks;

	[TestClass]
	public class ReviewAreaDescription
	{
		private readonly TestContextWriter outputWriter;

		public ReviewAreaDescription()
		{
			outputWriter = new TestContextWriter();
		}

		[TestMethod]
		public async Task Expand()
		{
			 await xB.CurrentRun.AddScenario(this, 1)
				.Skip("Not Started");
		}

		[TestMethod]
		public async Task ExpandAll()
		{
			 await xB.CurrentRun.AddScenario(this, 2)
				.Skip("Not Started");
		}

		[TestMethod]
		public async Task Collapse()
		{
			 await xB.CurrentRun.AddScenario(this, 3)
				.Skip("Not Started");
		}

		[TestMethod]
		public async Task CollapseAll()
		{
			 await xB.CurrentRun.AddScenario(this, 4)
				.Skip("Not Started");
		}

		[TestMethod]
		public async Task DefaultCollapsedWhenMoreThan5()
		{
			 await xB.CurrentRun.AddScenario(this, 5)
				.Skip("Not Started");
		}
	}
}
