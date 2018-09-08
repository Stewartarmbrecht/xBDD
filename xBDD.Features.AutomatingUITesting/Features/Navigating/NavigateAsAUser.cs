namespace xBDD.Features.AutomatingUITesting.Navigating
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System;
	using System.Threading.Tasks;
	using xBDD;
	using xBDD.Utility;

	[TestClass]
	public partial class NavigateAsAUser: xBDDFeatureBase
	{

		[TestMethod]
		public async Task WithSpecificSizeSettingOnTheBrowserWindow()
		{
			await xB.AddScenario(this, 1000)
				.Skip("Untested", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task ToAValidURL()
		{
			await xB.AddScenario(this, 2000)
				.Skip("Untested", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task ToAnInvalidURL()
		{
			await xB.AddScenario(this, 3000)
				.Skip("Untested", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WhenNoInternetConnection()
		{
			await xB.AddScenario(this, 4000)
				.Skip("Untested", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task ToAValidFile()
		{
			await xB.AddScenario(this, 5000)
				.Skip("Untested", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task ToANonHtmlTextFile()
		{
			await xB.AddScenario(this, 6000)
				.Skip("Untested", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task ToABinaryFile()
		{
			await xB.AddScenario(this, 7000)
				.Skip("Untested", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task ToAMissingFile()
		{
			await xB.AddScenario(this, 8000)
				.Skip("Untested", Assert.Inconclusive);
		}

	}
}