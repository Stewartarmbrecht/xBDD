namespace xBDD.Features.GeneratingReports.HTMLTestRunReport.ReviewTestRunInformation
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System;
	using System.Threading.Tasks;
	using xBDD;
	using xBDD.Utility;

	[TestClass]
	[Assignments("Stewart")]
	public partial class ReviewTestRunName: xBDDFeatureBase
	{

		[TestMethod]
		public async Task WithName()
		{
			await xB.AddScenario(this, 1000)
//				.Given(you.NavigateTo(aPassingTestRunReport))
//				.Then(you.WillSee(the.TestRunName).HasText("My Sample - Test Run 1 Passing"))
				.Skip("Untested", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithNoName()
		{
			await xB.AddScenario(this, 2000)
//				.Given(you.NavigateTo(aPassingTestRunReport))
//				.Then(you.WillSee(the.TestRunName).HasText("[Missing!]"))
				.Skip("Untested", Assert.Inconclusive);
		}

	}
}