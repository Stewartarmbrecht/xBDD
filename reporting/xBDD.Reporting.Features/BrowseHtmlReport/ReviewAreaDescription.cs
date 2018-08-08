namespace xBDD.Reporting.Features.BrowseHtmlReport
{
	using xBDD.Test;
	using xBDD.Browser;
	using xBDD.Reporting.Features.Pages.HtmlReportPage;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using xBDD.Reporting.Features.Steps;
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
			 await xB.CurrentRun.AddScenario(this)
				.Skip("Not Started");
		}

		[TestMethod]
		public async Task ExpandAll()
		{
			 await xB.CurrentRun.AddScenario(this)
				.Skip("Not Started");
		}

		[TestMethod]
		public async Task Collapse()
		{
			 await xB.CurrentRun.AddScenario(this)
				.Skip("Not Started");
		}

		[TestMethod]
		public async Task CollapseAll()
		{
			 await xB.CurrentRun.AddScenario(this)
				.Skip("Not Started");
		}

		[TestMethod]
		public async Task DefaultCollapsedWhenMoreThan5()
		{
			 await xB.CurrentRun.AddScenario(this)
				.Skip("Not Started");
		}
	}
}
