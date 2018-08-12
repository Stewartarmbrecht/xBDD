namespace Amazon.Features.SearchingProducts
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Threading.Tasks;
    using xBDD;
    using xBDD.Browser;

	[TestClass]
	[AsA("anonymous user")]
	[YouCan("search across all amazon products")]
	[By("using primary search bar on the home page")]
	public class SearchingAllProducts_Failing: IFeature
	{
		private User you = new User();
		public IOutputWriter OutputWriter { get; private set; }

		public SearchingAllProducts_Failing()
		{
			OutputWriter = new TestContextWriter();
		}
		
		[TestMethod]
		public async Task SearchWithSearchButton_Failing()
		{
			await xB.AddScenario(this)
				.Given(you.NavigateTo("the amazon home page","https://www.amazon.com"))
				.When(you.EnterTheText("echo").In("the search box", "#twotabsearchtextbox"))
				.And(you.Click("the search button", "input[type=submit]"))
				.Then(you.WillSee("the search results section", "#BAD_SELECTOR").IsVisible())
				.Run();
		}
	}
}