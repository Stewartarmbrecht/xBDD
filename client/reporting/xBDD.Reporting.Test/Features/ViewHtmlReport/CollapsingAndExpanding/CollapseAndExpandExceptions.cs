using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
//using Xunit;
//using Xunit.Abstractions;

namespace xBDD.Reporting.Test.Features.ViewHtmlReport.CollapsingAndExpanding
{
	[TestClass]
	public class CollapseAndExpandException
	{
		private readonly TestContextWriter outputWriter;

		public CollapseAndExpandException()
		{
			outputWriter = new TestContextWriter();
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
		public async Task DefaultCollapsedWhenMoreThan5()
		{
			 await xB.CurrentRun.AddScenario(this)
				.Skip("Not Started");
		}
	}
}
