namespace xBDD.Features.AutomatingUITesting.Clicking
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System;
	using System.Threading.Tasks;
	using xBDD;
	using xBDD.Utility;

	[TestClass]
	public partial class LeftClickWhenOtherCondition: xBDDFeatureBase
	{

		[TestMethod]
		[Explanation(@"
			Split out Wait conditions from click conditions
			Use class inheritance",3)]
		public async Task MakeImpossible()
		{
			await xB.AddScenario(this, 1000)
				.Skip("Removing", Assert.Inconclusive);
		}

	}
}