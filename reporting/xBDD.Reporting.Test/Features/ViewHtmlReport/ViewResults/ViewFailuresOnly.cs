using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
//using Xunit;
//using Xunit.Abstractions;

namespace xBDD.Reporting.Test.Features.ViewHtmlReport.ViewResults
{
	[TestClass]
	public class ViewFailureOnly
	{
		private readonly TestContextWriter outputWriter;

		public ViewFailureOnly()
		{
			outputWriter = new TestContextWriter();
		}
		
		[TestMethod]
		public async Task SingleScenario()
		{
			 await xB.CurrentRun.AddScenario(this)
				.Skip("Not Started");
		}
		
		[TestMethod]
		public async Task SingleFeatureMultipleScenarios()
		{
			 await xB.CurrentRun.AddScenario(this)
				.Skip("Not Started");
		}
		
		[TestMethod]
		public async Task SingleAreaMultipleFeatures()
		{
			 await xB.CurrentRun.AddScenario(this)
				.Skip("Not Started");
		}
		
		[TestMethod]
		public async Task MultipleAreas()
		{
			 await xB.CurrentRun.AddScenario(this)
				.Skip("Not Started");
		}
	}
}