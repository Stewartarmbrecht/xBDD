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
		public void Collapse()
		{
			 xB.CurrentRun.AddScenario(this)
				.Skip("Not Started");
		}
		[ScenarioFact]
		public void CollapseAll()
		{
			 xB.CurrentRun.AddScenario(this)
				.Skip("Not Started");
		}
		[ScenarioFact]
		public void Expand()
		{
			 xB.CurrentRun.AddScenario(this)
				.Skip("Not Started");
		}
		[ScenarioFact]
		public void ExpandAll()
		{
			 xB.CurrentRun.AddScenario(this)
				.Skip("Not Started");
		}
		[ScenarioFact]
		public void DefaultCollapsedWhenMoreThan5()
		{
			 xB.CurrentRun.AddScenario(this)
				.Skip("Not Started");
		}
	}
}