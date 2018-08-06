using Microsoft.VisualStudio.TestTools.UnitTesting;
using xBDD;

//Area
namespace MyApp.API.Test.Features.Calendar
{
	//Feature
	[AsA("developer")]
	[YouCan("find the holidays for the users culture in a specific time range")]
	[By("using the operations exposed by the User object's Calendar property")]
	[TestClass]
	// [TestClass] - for MSTest
	// [TestFixture] - for nUnit
	public class GetHolidays
	{
		//Scenario
		// [Fact] - for xUnit
		// [Test] - for nUnit
		public async void WhenUSCalendar()
		{
			await xB.AddScenario(this)
				.Given("a user object for a user with a US culture", (s) => {
					//code to create calendar
				})
				.When("you call GetHolidays with a date range of 3/10/2015 to 3/18/2015", (s) => {
					//code to issue get request.
				})
				.Then("you should get back a single holiday that is St. Patrick's Day", (s) => {
					//code to validate response
				})
				.Run();
		}
	}
}