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
		public async void SingleScenario()
		{
			 await xB.CurrentRun.AddScenario(this)
				.Skip("Not Started");
		}
		
		[ScenarioFact]
		public async void SingleFeatureMultipleScenarios()
		{
			 await xB.CurrentRun.AddScenario(this)
				.Skip("Not Started");
		}
		
		[ScenarioFact]
		public async void SingleAreaMultipleFeatures()
		{
			 await xB.CurrentRun.AddScenario(this)
				.Skip("Not Started");
		}
		
		[ScenarioFact]
		public async void MultipleAreas()
		{
			 await xB.CurrentRun.AddScenario(this)
				.Skip("Not Started");
		}
	}
}