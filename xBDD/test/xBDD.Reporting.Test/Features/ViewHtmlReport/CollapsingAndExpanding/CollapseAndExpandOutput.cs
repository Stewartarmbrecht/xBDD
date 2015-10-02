using xBDD.xUnit;
using Xunit;
using Xunit.Abstractions;

namespace xBDD.Reporting.Test.Features.ViewHtmlReport.CollapsingAndExpanding
{
	[Collection("xBDDReportingTest")]
	public class CollapseAndExpandOutput
	{
		private readonly OutputWriter outputWriter;

		public CollapseAndExpandOutput(ITestOutputHelper output)
		{
			outputWriter = new OutputWriter(output);
		}
		
		[ScenarioFact]
		[Trait("category", "today")]
		public void Collapse()
		{
			 xBDD.CurrentRun.AddScenario(this)
				.Skip("Not Started");
		}
		[ScenarioFact]
		public void CollapseAll()
		{
			 xBDD.CurrentRun.AddScenario(this)
				.Skip("Not Started");
		}
		[ScenarioFact]
		public void Expand()
		{
			 xBDD.CurrentRun.AddScenario(this)
				.Skip("Not Started");
		}
		[ScenarioFact]
		public void ExpandAll()
		{
			 xBDD.CurrentRun.AddScenario(this)
				.Skip("Not Started");
		}
		[ScenarioFact]
		public void DefaultCollapsedWhenMoreThan5()
		{
			 xBDD.CurrentRun.AddScenario(this)
				.Skip("Not Started");
		}
	}
}