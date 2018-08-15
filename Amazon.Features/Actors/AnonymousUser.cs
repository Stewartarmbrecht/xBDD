namespace Amazon.Features.Actors
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System;
	using System.Threading.Tasks;
	using xBDD;
	using xBDD.Model;
	using xBDD.Browser;

	public class AnonymousUser: User
	{
		public const string Name = "anonymous user";
		public Step NavigateToTheHomePage()
		{
			return xB.CreateAsyncStep(
				"you navigate to the home page", 
				async step => {
					await Task.Run(() => {
						// some async action...
					});
				}
			);
		}

		public Step EnterTheSearchText(string text)
		{
			return xB.CreateStep(
				$"you enter the search text '{text}'", 
				step => {/* some action... */ }
			);
		}
		public Step ClickTheSearchButton()
		{
			return xB.CreateStep(
				$"you click the search button", 
				step => {/* some action... */ }
			);
		}
		public Step WillSeeTheSearchResults()
		{
			return xB.CreateStep(
				$"you will see the search results", 
				step => {/* some action... */ }
			);
		}
		public Step SubmitTheSearchWithTheEnterKey()
		{
			return xB.CreateStep(
				$"you submit the search by pressing the enter key", 
				step => {/* some action... */ }
			);
		}
	}
}