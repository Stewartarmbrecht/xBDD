using System;
using System.Text;
using xBDD;
using xBDD.Test;
using xBDD.xUnit;
using Xunit;
using Xunit.Abstractions;

[assembly: TestRunName("My App - API")]

namespace xBDD.Core.Test.Features.DefineScenarios
{
	[Collection("xBDDCoreTest")]
	public class DefineABasicScenario
	{
		private readonly OutputWriter outputWriter;

		public DefineABasicScenario(ITestOutputHelper output)
		{
			outputWriter = new OutputWriter(output);
		}
		
		[ScenarioFact]
		[Trait("category", "now")]
		public void WithSynchronousExecution()
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendLine("Area:");
			sb.AppendLine("My App - API - Test - Features - Calendar");
			sb.AppendLine();
			sb.AppendLine("Feature:");
			sb.AppendLine("Get Holidays");
			sb.AppendLine();
			sb.AppendLine("Feature Description:");
			sb.AppendLine("In order to reference culture specific holidays");
			sb.AppendLine("As a developer");
			sb.AppendLine("I would like to get a list of the current user's culture specific holidays");
			sb.AppendLine();
			sb.AppendLine("Scenario:");
			sb.AppendLine("When US Calendar");
			sb.AppendLine();
			sb.AppendLine("Steps:");
			sb.AppendLine("Given a calendar object is initialized with US holidays");
			sb.AppendLine("When you call GetHolidays with a date range of 3/10/2015 to 3/18/2015");
			sb.AppendLine("Then you should get back a single holiday that is St. Patrick's Day");

			var testRunBuilder = new CoreFactory().CreateTestRunBuilder(null);
            xB.CurrentRun
                .AddScenario(this)
                .SetOutputWriter(outputWriter)
                .Given(Code.HasTheFollowingScenario("\\Features\\DefineScenarios\\SampleCode\\GetHolidays.cs"))
                .When("the scenario is executed", (s) =>
                {
					var currentTestRun = xB.CurrentRun;
					xB.CurrentRun = testRunBuilder;
                    new MyApp.API.Test.Features.Calendar.GetHolidays().WhenUSCalendar();
					xB.CurrentRun = currentTestRun;
                })
                .Then("the test run will have the following structure", (s) => {
					var steps = s.MultilineParameter.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
					Assert.Equal(steps[1], testRunBuilder.TestRun.Areas[0].Name);
					Assert.Equal(steps[3], testRunBuilder.TestRun.Areas[0].Features[0].Name);
					Assert.Equal(steps[5].Substring(9,steps[5].Length - 9), testRunBuilder.TestRun.Areas[0].Features[0].Value);
					Assert.Equal(steps[6].Substring(5,steps[6].Length - 5), testRunBuilder.TestRun.Areas[0].Features[0].Actor);
					Assert.Equal(steps[7].Substring(16,steps[7].Length - 16), testRunBuilder.TestRun.Areas[0].Features[0].Capability);
					Assert.Equal(steps[9], testRunBuilder.TestRun.Areas[0].Features[0].Scenarios[0].Name);
					Assert.Equal(steps[11], testRunBuilder.TestRun.Areas[0].Features[0].Scenarios[0].Steps[0].FullName);
					Assert.Equal(steps[12], testRunBuilder.TestRun.Areas[0].Features[0].Scenarios[0].Steps[1].FullName);
					Assert.Equal(steps[13], testRunBuilder.TestRun.Areas[0].Features[0].Scenarios[0].Steps[2].FullName);
				}, sb.ToString())
                .Run();
		}
		[ScenarioFact]
		[Trait("category", "now")]
		public async void WithAsynchronousExecution()
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendLine("Area:");
			sb.AppendLine("My App - API - Test - Features - Accounts");
			sb.AppendLine();
			sb.AppendLine("Feature:");
			sb.AppendLine("Get Account Details");
			sb.AppendLine();
			sb.AppendLine("Scenario:");
			sb.AppendLine("When Unauthenticated");
			sb.AppendLine();
			sb.AppendLine("Steps:");
			sb.AppendLine("Given the client is not authenticated");
			sb.AppendLine("When the client gets to the account details resource 'http://<site>/api/Accounts/99'");
			sb.AppendLine("Then the client should get a 401 response");

			var testRunBuilder = new CoreFactory().CreateTestRunBuilder(null);
            await xB.CurrentRun
                .AddScenario(this)
                .SetOutputWriter(outputWriter)
                .Given(Code.HasTheFollowingScenario("\\Features\\DefineScenarios\\SampleCode\\GetAccountDetails.cs"))
                .WhenAsync("the scenario is excuted", async (s) =>
                {
					var currentTestRun = xB.CurrentRun;
					xB.CurrentRun = testRunBuilder;
                    await new MyApp.API.Test.Features.Accounts.GetAccountDetails().WhenUnauthenticated();
					xB.CurrentRun = currentTestRun;
                })
                .Then("the test run will have the following structure", (s) => {
					var steps = s.MultilineParameter.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
					Assert.Equal(steps[1], testRunBuilder.TestRun.Areas[0].Name);
					Assert.Equal(steps[3], testRunBuilder.TestRun.Areas[0].Features[0].Name);
					Assert.Equal(steps[5], testRunBuilder.TestRun.Areas[0].Features[0].Scenarios[0].Name);
					Assert.Equal(steps[7], testRunBuilder.TestRun.Areas[0].Features[0].Scenarios[0].Steps[0].FullName);
					Assert.Equal(steps[8], testRunBuilder.TestRun.Areas[0].Features[0].Scenarios[0].Steps[1].FullName);
					Assert.Equal(steps[9], testRunBuilder.TestRun.Areas[0].Features[0].Scenarios[0].Steps[2].FullName);
				}, sb.ToString())
                .RunAsync();
		}
	}
}