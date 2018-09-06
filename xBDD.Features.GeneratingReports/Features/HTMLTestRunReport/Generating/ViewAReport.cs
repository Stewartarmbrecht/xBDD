namespace xBDD.Features.GeneratingReports.HTMLTestRunReport.Generating
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System;
	using System.Threading.Tasks;
	using xBDD;
	using xBDD.Utility;

	[TestClass]
	[Assignments("Stewart")]
	public partial class ViewAReport: xBDDFeatureBase
	{

		[TestMethod]
		public async Task FromAFileServer()
		{
			await xB.AddScenario(this, 1000)
				.Given("you have executed a test run project that creates all outcomes",
					(s) => { 
						// Enter your code here.
					})
				.Then("you can view the html report by loading the following file into your browser",
					(s) => { 
						// Enter your code here.
					},
					"./MySample.Features.TestRun1Passing/test-results/MySample.Features.TestRun1Passing.Results.html",
					TextFormat.text)
				.Skip("Untested", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task FromAWebServer()
		{
			await xB.AddScenario(this, 2000)
				.Skip("Defining", Assert.Inconclusive);
		}

	}
}