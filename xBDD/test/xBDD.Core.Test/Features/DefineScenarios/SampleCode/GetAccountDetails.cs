using System.Threading.Tasks;
using xBDD;

// The namespace will be converted to an Area name with spaces added 
// between capitalized words and the periods replaced with 
// dashes.
namespace MyApp.API.Test.Features.Accounts
{
	// Attributes can be used to define the 
	// value, actor, and action for the feature
	[InOrderTo("review the details of a specific account")]
	[AsA("administrator")]
	[IWouldLikeTo("be able to get the details of any account from the api by account id")]
	// The class name will be converted to a feature with 
	// spaces added between capitalized words
	public class GetAccountDetails
	{
		// The containing method will be used to 
		// set the scenario name by adding spaces
		// between the capitalized words and numbers.
		// Usually this method will be attributed to 
		// identify it as a unit test that will be run 
		// by the unit testing framework you are using.
		public async Task WhenUnauthenticated()
		{
			// xB is the static class that provides access to the
			// current test run.
			await xB.CurrentRun
				// AddScenario adds a new scenario to the test run.
				.AddScenario(this)
				// Adds a new step to the scenario.  Given, When, Then, and And
				// all do the same thing.  There are no requirements in how you use them.
				// The only impact of one versus the other is that the full name for the 
				// step will start with the Given, When, Then or And based on 
				// Which one you use.
				.GivenAsync("the client is not authenticated", async (s) => {
					//async code to ensure the user session is not authenticated.
					//await client.logOff();
					await Task.Run(() => { });
				})
				.WhenAsync("the client gets to the account details resource 'http://<site>/api/Accounts/99'", async (s) => {
					//code to issue get request.
					//var response = await client.Get('http://<site>/api/Accounts/99');
					//the line below is just to get the example to compile...
					await Task.Run(() => { });
				})
				.Then("the client should get a 401 response", (s) => {
					//code to validate response 
					//no need for asynchronous code here
				})
				// To execute the scenario you need to call Run() or RunAsync()
				// This will execute each step in order that you added them
				// to the scenario.
				.Run();
		}
	}
}