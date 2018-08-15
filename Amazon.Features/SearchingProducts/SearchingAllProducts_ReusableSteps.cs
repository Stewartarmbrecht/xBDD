namespace Amazon.Features.SearchingProducts
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System;
	using System.Threading.Tasks;
	using xBDD;
	using xBDD.Model;
	using xBDD.Browser;
	using Amazon.Features.Actors;

	[TestClass]
	[AsA(AnonymousUser.Name)]
	[YouCan("search across all amazon products")]
	[By("using the primary search bar on the home page")]
	public class SearchingAllProducts_ReusableSteps: IFeature
	{
		private AnonymousUser you = new AnonymousUser();
		public IOutputWriter OutputWriter { get; private set; }

		public SearchingAllProducts_ReusableSteps()
		{
			OutputWriter = new TestContextWriter();
		}
		
		[TestMethod]
		public async Task SearchWithSearchButton_ReusableSteps()
		{
			await xB.AddScenario(this)
				.Given(you.NavigateToTheHomePage())
				.When(you.EnterTheSearchText("echo"))
				.And(you.ClickTheSearchButton())
				.Then(you.WillSeeTheSearchResults())
				.Run();
		}
		[TestMethod]
		public async Task SearchWithEnter_ReusableSteps()
		{
			await xB.AddScenario(this)
				.Given(you.NavigateToTheHomePage())
				.When(you.EnterTheSearchText("echo"))
				.And(you.SubmitTheSearchWithTheEnterKey())
				.Then(you.WillSeeTheSearchResults())
				.Run();
		}
	}
}