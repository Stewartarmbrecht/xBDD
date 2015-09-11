using xBDD.Reporting;
using xBDD.Reporting.TextFile;

namespace xBDD
{
    public static class xBDDExtensions
    {
        public static void WriteToFile(this ITestRun testRun, string fileName)
        {
            IReportingFactory factory = new ReportingFactory();
            ITextFileWriter saver = factory.GetTextFileWriter();
            saver.WriteToFile(testRun, fileName);
        }
    }
}
