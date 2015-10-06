using xBDD.Reporting.Test.Pages;
using xBDD.Reporting.Test.Steps;
using xBDD.xUnit;
using Xunit;
using Xunit.Abstractions;

namespace xBDD.Reporting.Test.Features.ViewHtmlReport.ViewResults
{
	[Collection("xBDDReportingTest")]
	//  [Description("In order to understand how functionality is organized")]
	//  [Description("As a report reviewer")]
	//  [Description("I would like to view the areas in the html report")]
	public class ViewStep
	{
		private readonly OutputWriter outputWriter;

		public ViewStep(ITestOutputHelper output)
		{
			outputWriter = new OutputWriter(output);
		}
		
		[ScenarioFact]
		public void Single()
		{
			xBDD.CurrentRun.AddScenario(this)
				.Skip("Not Started");
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
		[ScenarioFact]
		public async void WithException()
		{
            Wrapper<HtmlReportPage> htmlReport = new Wrapper<HtmlReportPage>();
            await xBDD.CurrentRun.AddScenario(this)
                .Given(HtmlReport.OfAFailingStepWithAnException())
				.When(WebUser.ViewsReport(htmlReport))
                .Then("the user should see a section for the exception", (s) => {
					Assert.True(htmlReport.Object.Exception(2).Displayed); 
				})
       			.And("the section should display the exception type", (s) => { 
					Assert.True(htmlReport.Object.ExceptionType(2).Displayed); 
				})
       			.And("the section should display the exception message", (s) => { 
					Assert.True(htmlReport.Object.ExceptionMessage(2).Displayed); 
				})
       			.And("the section should display the exception stack trace", (s) => { 
					Assert.True(htmlReport.Object.ExceptionStackTrace(2).Displayed); 
				})
				.RunAsync();
		}
		[ScenarioFact]
		public async void WithInnerException()
		{
            Wrapper<HtmlReportPage> htmlReport = new Wrapper<HtmlReportPage>();
            await xBDD.CurrentRun.AddScenario(this)
                .Given(HtmlReport.OfAFailingStepWithANestedException())
				.When(WebUser.ViewsReport(htmlReport))
                .Then("the user should see a section for the nsted exception", (s) => {
					Assert.True(htmlReport.Object.InnerException(2).Displayed); 
				})
       			.And("the section should display the exception type", (s) => { 
					Assert.True(htmlReport.Object.InnerExceptionType(2).Displayed); 
				})
       			.And("the section should display the exception message", (s) => { 
					Assert.True(htmlReport.Object.InnerExceptionMessage(2).Displayed); 
				})
       			.And("the section should display the exception stack trace", (s) => { 
					Assert.True(htmlReport.Object.InnerExceptionStackTrace(2).Displayed); 
				})
				.RunAsync();
		}
	}
}