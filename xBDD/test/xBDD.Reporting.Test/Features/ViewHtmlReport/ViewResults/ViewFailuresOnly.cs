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
		[Trait("category", "today")]
		public void SingleScenario()
		{
			 xBDD.CurrentRun.AddScenario(this)
				.Skip("Not Started");
		}
		
		[ScenarioFact]
		[Trait("category", "today")]
		public void SingleFeatureMultipleScenarios()
		{
			 xBDD.CurrentRun.AddScenario(this)
				.Skip("Not Started");
		}
		
		[ScenarioFact]
		[Trait("category", "today")]
		public void SingleAreaMultipleFeatures()
		{
			 xBDD.CurrentRun.AddScenario(this)
				.Skip("Not Started");
		}
		
		[ScenarioFact]
		[Trait("category", "today")]
		public void MultipleAreas()
		{
			 xBDD.CurrentRun.AddScenario(this)
				.Skip("Not Started");
		}
	}
}