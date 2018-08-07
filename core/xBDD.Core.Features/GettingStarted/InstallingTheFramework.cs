using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;
using System.Threading.Tasks;
using xBDD;
using xBDD.Test;

namespace xBDD.Core.Features.GettingStarted
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
			await xB.AddScenario(this)
				.Given("you create an MSTest project by following the directions here:",
					(s) => {}, "https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-mstest")
				.And("you execute the following commands:", (s) => {}, "dotnet add package xBDD", TextFormat.sh)
				.And("you install the xBDD nuget package by executing:", (s) => {}, "dotnet add package xBDD", TextFormat.sh)
				.And("you modify the default test class to look like:", (s) => {}, "...add code.", TextFormat.cs)
				.When("you run the test project using:",null,"dotnet test -v n")
				.Run();
		}
		[TestMethod]
		public async Task ForAnXunitProject()
		{
		}
		[TestMethod]
		public async Task ForAnNUnitProject()
		{
		}
	}
}