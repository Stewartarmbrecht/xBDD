using xBDD.Test.Utilities;

namespace xBDD.Test.Features
{
    public class WriteResultsToHtml
    {
        public void WriteSimpleTestRun()
        {
            TestRunBuilder tb = new TestRunBuilder();
            ITestRun testRun = tb.BuildPassingTestRun();
            IReportWriter writer = xBDD.ReportFactory.GetHtmlReportWriter();
            writer.WriteReport(testRun);
        }

    }
}
