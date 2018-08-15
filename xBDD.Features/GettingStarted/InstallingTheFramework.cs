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
		public async Task ViaANugetPackage()
		{
			await xB.AddScenario(this, 1)
				.Given("you have created a test project", (s) => {})
				.When("you excute the following command in the project directory:", (s) => {}, "dotnet add package xBDD", TextFormat.sh)
				.Then("you will install the xBDD framework")
				.Document();
		}
	}
}