using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using xBDD.Test;

namespace xBDD.Reporting.Features.BrowseHtmlReport
{
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
