using Microsoft.VisualStudio.TestTools.UnitTesting;
using xBDD;

//Area
namespace MyApp.StandardUserFeatures.AccessAccountInformationOffline
{
	//Feature
	[AsA("user")]
	[YouCan("setup your machine to access account information offline")]
	[By("installing the sync tool")]
	// [TestClass] - for MSTest
	// [TestFixture] - for nUnit
	public class InstallSyncTool
	{
		//Scenario
		// [Fact] - for xUnit
		// [Test] - for nUnit
		public async void OnWindows10()
		{
			await xB.AddScenario(this)
				.Given("you have a windows 10 machine")
				.And("you have installed the latest updates")
				.When("you download and install the sync tool from 'https://myinstallsite.com/thesynctool'")
				.Then("you will see a sync tool icon in your system tray")
				.Document();
		}
	}
}