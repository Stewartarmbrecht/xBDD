using System;
using System.Collections.Generic;

namespace xBDD.Reporting
{

	public class TestRunReportConfiguration: ITestRunReportConfiguration
	{
		public string ReportName { get; set; }
		public string ReportFolder { get; set; }
		public string FileName { get; set; }
		public bool FailuresOnly { get; set; }
		public string RootNameSkip { get; set; }
	}
}