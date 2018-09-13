namespace xBDD.Reporting
{
	using System.Collections.Generic;

	public class TestRunGroupReportConfiguration: ITestRunReportConfiguration
	{
		public string ReportName { get; set; }
		public string FileName { get; set; }
		public string RootNameSkip { get; set; }
		public List<TestRunGroupReportTestRunConfiguration> TestRunConfigurations { get; set; }
	}
}