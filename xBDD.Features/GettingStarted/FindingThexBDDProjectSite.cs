namespace xBDD.Features.GettingStarted
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Threading.Tasks;
    using xBDD;
    using xBDD.Browser;

	[TestClass]
	[AsA("internet user")]
	[YouCan("search for the xBDD project site")]
	[By("using google search to search for 'xBDD C#'")]
	public class FindingThexBDDProjectSite: IFeature
	{
        private User you = new User();
		public IOutputWriter OutputWriter { get; private set; }

		public FindingThexBDDProjectSite()
		{
			OutputWriter = new TestContextWriter();
		}
		
		[TestMethod]
		public async Task SearchForXBDD()
		{
			await xB.AddScenario(this)
				.Given(you.NavigateTo("the google search page","https://www.google.com"))
				.When(you.EnterTheText("xBDD C#").AndHitEnter().In("the search box", "input#lst-ib"))
                .Then(you.WillSee("the first results", "h3.r a").HasText("GitHub - Stewartarmbrecht/xBDD: Behavior Driven Development ..."))
				.Run();
		}
	}
}