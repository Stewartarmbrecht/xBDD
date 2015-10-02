using xBDD.xUnit;
using Xunit;
using Xunit.Abstractions;

namespace xBDD.Reporting.Test.Features.ViewHtmlReport.ViewResults
{
	[Collection("xBDDReportingTest")]
	public class ViewFeature
	{
		private readonly OutputWriter outputWriter;

		public ViewFeature(ITestOutputHelper output)
		{
			outputWriter = new OutputWriter(output);
		}
		
		[ScenarioFact]
		[Trait("category", "today")]
		public void Name()
		{
			 xBDD.CurrentRun.AddScenario(this)
				.Skip("Not Started");
		}
		[ScenarioFact]
		[Trait("category", "today")]
		public void Description()
		{
			 xBDD.CurrentRun.AddScenario(this)
				.Skip("Not Started");
		}
		[ScenarioFact]
		[Trait("category", "today")]
		public void Passing()
		{
			 xBDD.CurrentRun.AddScenario(this)
				.Skip("Not Started");
		}
		[ScenarioFact]
		[Trait("category", "today")]
		public void Skipped()
		{
			 xBDD.CurrentRun.AddScenario(this)
				.Skip("Not Started");
		}
				[ScenarioFact]
		[Trait("category", "today")]
		public void Failing()
		{
			 xBDD.CurrentRun.AddScenario(this)
				.Skip("Not Started");
		}

	}
}