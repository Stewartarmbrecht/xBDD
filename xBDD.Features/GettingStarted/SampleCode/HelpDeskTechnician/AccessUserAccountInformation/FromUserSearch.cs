using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using xBDD;

namespace MyApp.Features.HelpDeskTechnician.AccessUserAccountInformation
{
	[AsA("help dedk technician")]
	[YouCan("access user account information")]
	[By("from the user search by clicking the account details link next to the user name")]
	// [TestClass] - for MSTest
	// [TestFixture] - for nUnit
	public class FromTheUserSearch
	{
		// [Fact] - for xUnit
		// [Test] - for nUnit
		public async Task IfYouAreLoggedInAsAHelpDeskTechnician()
		{
			await xB.AddScenario(this)
				.GivenAsync("you are logged in as a Help Desk Technician", async (s) => {
					// Replace with actual code that returns a task.
					await Task.Run(() => { });
				})
				.AndAsync("you execute a user search", async (s) => {
					// Replace with actual code that returns a task.
					await Task.Run(() => { });
				})
				.WhenAsync("you click the information icon next to the user name in the search results", async (s) => {
					// Replace with actual code that returns a task.
					await Task.Run(() => { });
				})
				.Then("you will be taken to the user details page", (s) => {
					// Replace with synchronous code.
				})
				.Run();
		}
		public async Task IfYouAreNotLoggedInAsAHelpDeskTechnician()
		{
			await xB.AddScenario(this)
				.GivenAsync("you are logged in as a normal user", async (s) => {
					// Replace with actual code that returns a task.
					await Task.Run(() => { });
				})
				.AndAsync("you execute a user search", async (s) => {
					// Replace with actual code that returns a task.
					await Task.Run(() => { });
				})
				.ThenAsync("you should not see an information icon next to the users name in the search results", async (s) => {
					// Replace with actual code that returns a task.
					await Task.Run(() => { });
				})
				.Run();
		}
	}
}