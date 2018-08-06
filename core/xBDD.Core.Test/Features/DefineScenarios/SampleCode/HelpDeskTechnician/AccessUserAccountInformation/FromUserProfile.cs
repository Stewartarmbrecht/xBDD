namespace MyApp.Features.HelpDeskTechnician.AccessUserAccountInformation
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System.Threading.Tasks;
	using xBDD;
	using xBDD.Model;

	[AsA("help dedk technician")]
	[YouCan("access user account information")]
	[By("from the user profile page by clicking the account details link next to the user name")]
	// [TestClass] - for MSTest
	// [TestFixture] - for nUnit
	public class FromTheUserProfile
	{
		// [Fact] - for xUnit
		// [Test] - for nUnit
		public async Task IfYouAreLoggedInAsAHelpDeskTechnician()
		{
			await xB.AddScenario(this)
				.Given(You.AreLoggedInAsA("help desk technician"))
				.And(You.NavigateTo("a user profile page", "/user/33/profile"))
				.When(You.Click("the user account information link","#user-account-info"))
				.Then(You.WillBeTakenTo("the user account information page", "/user/33/accountinformation"))
				.Run();
		}
		public async Task IfYouAreNotLoggedInAsAHelpDeskTechnician()
		{
			await xB.AddScenario(this)
				.Given(You.AreLoggedInAsA("standard user"))
				.And(You.NavigateTo("a user profile page", "/user/33/profile"))
				.Then(You.WillNotSee("a link to the user account information page", "#user-account-info"))
				.Run();
		}
	}

	public static class You
	{
		public static Step AreLoggedInAsA(string userType)
		{
            return xB.CreateStep($"you are logged in as a {userType}", (s) => {
				// do something...
			});
		}
		public static Step NavigateTo(string pageName, string pageUrl)
		{
            return xB.CreateStep($"you access a {pageName}", (s) => {
				// do something...
			});
		}
		public static Step Click(string linkName, string )
		{
            return xB.CreateStep($"you click the {linkName}", (s) => {
				// do something...
			});
		}
		public static Step WillBeTakenTo(string locationDescription, string locationUrl)
		{
            return xB.CreateStep($"you will be taken to {locationDescription}", (s) => {
				// validate something
			});
		}
		public static Step WillNotSee(string locationDescription, string locationUrl)
		{
            return xB.CreateStep($"you will be taken to {locationDescription}", (s) => {
				// validate something
			});
		}
	}
}