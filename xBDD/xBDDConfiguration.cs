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
	}
}