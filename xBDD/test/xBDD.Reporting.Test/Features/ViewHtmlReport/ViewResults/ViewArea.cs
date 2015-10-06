using xBDD.Reporting.Test.Pages;
using xBDD.Reporting.Test.Steps;
using xBDD.xUnit;
using xBDD.Browser;
using Xunit;
using Xunit.Abstractions;

namespace xBDD.Reporting.Test.Features.ViewHtmlReport.ViewResults
{
	[Collection("xBDDReportingTest")]
	//  [Description("In order to understand how functionality is organized")]
	//  [Description("As a report reviewer")]
	//  [Description("I would like to view the areas in the html report")]
	public class ViewArea
	{
		private readonly OutputWriter outputWriter;

		public ViewArea(ITestOutputHelper output)
		{
			outputWriter = new OutputWriter(output);
		}
		
		[ScenarioFact]
		public async void Single()
		{
            Wrapper<HtmlReportPage> htmlReport = new Wrapper<HtmlReportPage>();
            await xBDD.CurrentRun.AddScenario(this)
                .Given(HtmlReport.OfASinglePassingScenario())
                .When(WebUser.ViewsReport(htmlReport))
                .Then("the report will show the area name in green to indicate all features passed", (s) => {
                    Assert.Equal(Color.Green, htmlReport.Object.GetAreaNameColor(1));
                })
				.AndAsync("the features under the area will be collapsed because it passed", async (s) => {
					await Page.WaitTillNotVisible("area 1 features", htmlReport.Object.AreaFeatures(1));
				})
                .RunAsync();
		}
		[ScenarioFact]
		public void Mulitple()
		{
			 xBDD.CurrentRun.AddScenario(this)
				.Skip("Not Started");
		}
		[ScenarioFact]
		public void Passing()
		{
			 xBDD.CurrentRun.AddScenario(this)
				.Skip("Not Started");
		}
		[ScenarioFact]
		public void Skipped()
		{
			 xBDD.CurrentRun.AddScenario(this)
				.Skip("Not Started");
		}
		[ScenarioFact]
		public void Failing()
		{
			 xBDD.CurrentRun.AddScenario(this)
				.Skip("Not Started");
		}
	}
}