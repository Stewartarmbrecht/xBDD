namespace xBDD
{
	using xBDD.Reporting;
	using System.Collections.Generic;

	public class xBDDConfiguration
	{
		public List<ReportReasonConfiguration> SortedReasonConfigurations { get; set; }
		public List<string> SortedFeatureNames { get; set; }
		public TestRunReportConfiguration TestRunReport { get; set; }
		public TestRunGroupReportConfiguration TestRunGroupReport { get; set; }

		public List<ReportReasonConfiguration> StepReasonConfiguration { get {
				return new List<ReportReasonConfiguration>() {
					new ReportReasonConfiguration() { Reason = "Passed", FontColor = "White", BackgroundColor = "Green" },
					new ReportReasonConfiguration() { Reason = "Previous Error", FontColor = "Black", BackgroundColor = "Yellow" },
					new ReportReasonConfiguration() { Reason = "Scenario Skipped", FontColor = "Black", BackgroundColor = "Yellow" },
					new ReportReasonConfiguration() { Reason = "No Action", FontColor = "White", BackgroundColor = "Red" },
					new ReportReasonConfiguration() { Reason = "Exception Thrown", FontColor = "White", BackgroundColor = "Red" }
				};
			}
		}
	}
}