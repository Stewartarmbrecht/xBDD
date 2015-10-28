using xBDD;

//Area
namespace MyApp.API.Test.Features.Calendar
{
	//Feature
	[InOrderTo("to reference culture specific holidays")]
	[AsA("developer")]
	[IWouldLikeTo("get a list of the current user's culture specific holidays")]
	public class GetHolidays
	{
		//Scenario
		public async void WhenUSCalendar()
		{
			await xB.CurrentRun
				.AddScenario(this)
				.Given("a calendar object is initialized with US holidays", (s) => {
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