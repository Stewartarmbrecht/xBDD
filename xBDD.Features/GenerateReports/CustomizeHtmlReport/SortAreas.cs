namespace xBDD.Features.GenerateReports.CustomizeHtmlReport
{
	using xBDD.Features;
	using xBDD.Browser;
	using xBDD.Features.Pages.HtmlReportPage;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using xBDD.Features.Steps;
	using System.Threading.Tasks;

    [TestClass]
	[AsA("Developer")]
	[YouCan("control the order areas are displayed")]
	[By("setting an AreaSort attribute on the namespace")]
	public class SortAreas
	{
        private User you = new User();
        private HtmlReport the = new Pages.HtmlReportPage.HtmlReport();
        private ReportLocations theHtmlReport = new Pages.HtmlReportPage.ReportLocations();

		private readonly TestContextWriter outputWriter;

		public SortAreas()
		{
			outputWriter = new TestContextWriter();
		}
		
		[TestMethod]
		public async Task NotSorted()
		{
			 await xB.AddScenario(this)
				.Skip("Not Started");
		}
		[TestMethod]
		public async Task Sorted()
		{
			 await xB.AddScenario(this)
				.Skip("Not Started");
		}
		[TestMethod]
		public async Task PartiallySorted()
		{
			 await xB.AddScenario(this)
				.Skip("Not Started");
		}
	}
}