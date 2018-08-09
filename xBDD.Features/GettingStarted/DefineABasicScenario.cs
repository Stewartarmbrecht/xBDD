using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;
using System.Threading.Tasks;
using xBDD;
using xBDD.Features;

namespace xBDD.Features.GettingStarted
{
	[TestClass]
	[AsA("developer")]
	[YouCan("automate a basic scenario")]
	[By("using xB.AddScenario and the Given, When, Then, and And operations.")]
	public class DefineABasicScenario: IFeature
	{
		public IOutputWriter OutputWriter { get; private set; }

		public DefineABasicScenario()
		{
			OutputWriter = new TestContextWriter();
		}
		
		[TestMethod]
		public async Task WithSynchronousExecution()
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

			var separator = System.IO.Path.DirectorySeparatorChar;
			var scenarioPath = $"{separator}GettingStarted{separator}SampleCode{separator}GetHolidays.cs";

			var testRunBuilder = new xBDD.Core.CoreFactory().CreateTestRunBuilder(null);
            await xB.AddScenario(this, 1)
                .Given(Code.HasTheFollowingScenario(scenarioPath))
                .When("the scenario is executed", (s) =>
                {
					var currentTestRun = xB.CurrentRun;
					xB.CurrentRun = testRunBuilder;
                    new MyApp.API.Test.Features.Calendar.GetHolidays().WhenUSCalendar();
					xB.CurrentRun = currentTestRun;
                })
                .Then("the test run will have the following structure", (s) => {
					var steps = s.MultilineParameter.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
					Assert.AreEqual(steps[1], testRunBuilder.TestRun.Areas[0].Name);
					Assert.AreEqual(steps[3], testRunBuilder.TestRun.Areas[0].Features[0].Name);
					Assert.AreEqual(steps[5].Substring(9,steps[5].Length - 9), testRunBuilder.TestRun.Areas[0].Features[0].Value);
					Assert.AreEqual(steps[6].Substring(5,steps[6].Length - 5), testRunBuilder.TestRun.Areas[0].Features[0].Actor);
					Assert.AreEqual(steps[7].Substring(16,steps[7].Length - 16), testRunBuilder.TestRun.Areas[0].Features[0].Capability);
					Assert.AreEqual(steps[9], testRunBuilder.TestRun.Areas[0].Features[0].Scenarios[0].Name);
					Assert.AreEqual(steps[11], testRunBuilder.TestRun.Areas[0].Features[0].Scenarios[0].Steps[0].FullName);
					Assert.AreEqual(steps[12], testRunBuilder.TestRun.Areas[0].Features[0].Scenarios[0].Steps[1].FullName);
					Assert.AreEqual(steps[13], testRunBuilder.TestRun.Areas[0].Features[0].Scenarios[0].Steps[2].FullName);
				}, sb.ToString(), TextFormat.text)
                .Run();
		}
		[TestMethod]
		public async Task WithAsynchronousExecution()
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
			sb.AppendLine("When the client gets to the account details resource 'https://<site>/api/Accounts/99'");
			sb.AppendLine("Then the client should get a 401 response");

			var separator = System.IO.Path.DirectorySeparatorChar;
			var scenarioPath = $"{separator}Features{separator}DefineScenarios{separator}SampleCode{separator}GetAccountDetails.cs";

			var testRunBuilder = new xBDD.Core.CoreFactory().CreateTestRunBuilder(null);
            await xB.AddScenario(this, 2)
                .SetOutputWriter(OutputWriter)
                .Given(Code.HasTheFollowingScenario(scenarioPath))
                .WhenAsync("the scenario is excuted", async (s) =>
                {
					var currentTestRun = xB.CurrentRun;
					xB.CurrentRun = testRunBuilder;
                    await new MyApp.Features.HelpDeskTechnician.AccessUserAccountInformation.FromTheUserSearch().IfYouAreLoggedInAsAHelpDeskTechnician();
					xB.CurrentRun = currentTestRun;
                })
                .Then("the test run will have the following structure", (s) => {
					var steps = s.MultilineParameter.Split(new string[] { System.Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
					Assert.AreEqual(steps[1], testRunBuilder.TestRun.Areas[0].Name);
					Assert.AreEqual(steps[3], testRunBuilder.TestRun.Areas[0].Features[0].Name);
					Assert.AreEqual(steps[5], testRunBuilder.TestRun.Areas[0].Features[0].Scenarios[0].Name);
					Assert.AreEqual(steps[7], testRunBuilder.TestRun.Areas[0].Features[0].Scenarios[0].Steps[0].FullName);
					Assert.AreEqual(steps[8], testRunBuilder.TestRun.Areas[0].Features[0].Scenarios[0].Steps[1].FullName);
					Assert.AreEqual(steps[9], testRunBuilder.TestRun.Areas[0].Features[0].Scenarios[0].Steps[2].FullName);
				}, sb.ToString())
                .Run();
		}
	}
}