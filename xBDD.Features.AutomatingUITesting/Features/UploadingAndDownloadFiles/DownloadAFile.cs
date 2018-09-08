namespace xBDD.Features.AutomatingUITesting.UploadingAndDownloadFiles
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System;
	using System.Threading.Tasks;
	using xBDD;
	using xBDD.Utility;

	[TestClass]
	public partial class DownloadAFile: xBDDFeatureBase
	{

		[TestMethod]
		public async Task Successful()
		{
			await xB.AddScenario(this, 1000)
				.Skip("Defining", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task Unsuccessful()
		{
			await xB.AddScenario(this, 2000)
				.Skip("Defining", Assert.Inconclusive);
		}

	}
}