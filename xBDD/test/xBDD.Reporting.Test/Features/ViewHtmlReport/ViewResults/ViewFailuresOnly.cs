using xBDD.xUnit;
using Xunit;
using Xunit.Abstractions;

namespace xBDD.Reporting.Test.Features.ViewHtmlReport.ViewResults
{
	[Collection("xBDDReportingTest")]
	public class ViewFailureOnly
	{
		private readonly OutputWriter outputWriter;

		public ViewFailureOnly(ITestOutputHelper output)
		{
			outputWriter = new OutputWriter(output);
		}
		
		[ScenarioFact]
		public void SingleScenario()
		{
			 xB.CurrentRun.AddScenario(this)
				.Skip("Not Started");
		}
		
		[ScenarioFact]
		public void SingleFeatureMultipleScenarios()
		{
			 xB.CurrentRun.AddScenario(this)
				.Skip("Not Started");
		}
		
		[ScenarioFact]
		public void SingleAreaMultipleFeatures()
		{
			 xB.CurrentRun.AddScenario(this)
				.Skip("Not Started");
		}
		
		[ScenarioFact]
		public void MultipleAreas()
		{
			 xB.CurrentRun.AddScenario(this)
				.Skip("Not Started");
		}
	}
}