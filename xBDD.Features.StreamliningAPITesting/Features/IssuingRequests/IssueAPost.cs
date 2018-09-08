namespace xBDD.Features.StreamliningAPITesting.IssuingRequests
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System;
	using System.Threading.Tasks;
	using xBDD;
	using xBDD.Utility;

	[TestClass]
	public partial class IssueAPost: xBDDFeatureBase
	{

		[TestMethod]
		public async Task Placeholder()
		{
			await xB.AddScenario(this, 1000)
				.Skip("Defining", Assert.Inconclusive);
		}

	}
}