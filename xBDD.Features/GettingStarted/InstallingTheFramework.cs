using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;
using System.Threading.Tasks;
using xBDD;
using xBDD.Features;

namespace xBDD.Features.GettingStarted
{
	[TestClass]
	[AsA("developer")]
	[YouCan("leverage xBDD within your .Net testing projects")]
	[By("installing the xBDD.Core nuget package")]
	public class InstallingTheFramework: IFeature
	{
		public IOutputWriter OutputWriter { get; private set; }

		public InstallingTheFramework()
		{
			OutputWriter = new TestContextWriter();
		}
		
		[TestMethod]
		public async Task IfYouUseAnMSTestProject()
		{
			await xB.AddScenario(this, 1)
				.Then("you create an MSTest project by following the directions here: https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-mstest",
					(s) => {})
				.And("you can install xBDD by executing:", (s) => {}, "dotnet add package xBDD", TextFormat.sh)
				.Document();
		}
		[TestMethod]
		public async Task ForAnXunitProject()
		{
			 await xB.CurrentRun.AddScenario(this, 2)
				.Skip("Not Started", Assert.Inconclusive);
		}
		[TestMethod]
		public async Task ForAnNUnitProject()
		{
			 await xB.CurrentRun.AddScenario(this, 3)
				.Skip("Not Started", Assert.Inconclusive);
		}
	}
}