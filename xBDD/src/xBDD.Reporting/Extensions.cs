using xBDD.Model;
using xBDD.Reporting;
using xBDD.Reporting.Html;
using xBDD.Reporting.TextFile;

namespace xBDD
{
    public static class xBDDExtensions
    {
        public static string WriteToText(this TestRun testRun)
        {
            ReportingFactory factory = new ReportingFactory();
            TextWriter saver = factory.GetTextFileWriter();
            return saver.WriteToString(testRun);
        }
        public static string WriteToHtml(this TestRun testRun)
        {
            ReportingFactory factory = new ReportingFactory();
            HtmlWriter saver = factory.GetHtmlFileWriter();
            return saver.WriteToString(testRun);
        }
    }
}
