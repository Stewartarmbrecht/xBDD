// using Microsoft.VisualStudio.TestTools.UnitTesting;
// using System.Threading.Tasks;
// using xBDD;
// using xBDD.Browser;

// namespace xBDD.SampleApp.Test.Features.HomePage
// {
//     [TestClass]
//     [AsA("new user of xBDD")]
//     [IWouldLikeTo("review information about getting started")]
//     [InOrderTo("start using xBDD")]
//     public class ViewWelcomeMessage
//     {
//         [TestMethod]
//         public async Task AsAPublicUser()
//         {
//             var browser = new xBDD.Browser.WebBrowser();
//             await xB.CurrentRun
//                 .AddScenario(this)
//                 .Given("A public user is on the home home page", (s) => {
//                     browser.Load(new PageLocation("Home Page", "http://localhost:5000"));
//                 })
//                 .ThenAsync("There should be a welcome message to the user that reads 'Welcome to the Sample App!'", async (s) => {
//                     var welcomeMessage = new PageElement("Welcome Message", "#welcome-message");
//                     await browser.WaitTillVisible(welcomeMessage);
//                     browser.ElementHasText(welcomeMessage, "Welcome to the Sample App!");
//                     WebDriver.Close();
//                 })
//                 .Run();
//         }
//     }
// }
