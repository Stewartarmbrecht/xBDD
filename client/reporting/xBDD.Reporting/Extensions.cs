using System.Threading.Tasks;
using xBDD.Model;
using xBDD.Reporting;
using xBDD.Reporting.Html;
using xBDD.Reporting.TextFile;

namespace xBDD
{
    public static class xBDDExtensions
    {
        public static async Task<string> WriteToText(this TestRun testRun)
        {
            ReportingFactory factory = new ReportingFactory();
            TextWriter saver = factory.GetTextFileWriter();
            return await saver.WriteToString(testRun);
        }
        public static async Task<string> WriteToHtml(this TestRun testRun)
        {
            ReportingFactory factory = new ReportingFactory();
            HtmlWriter saver = factory.GetHtmlFileWriter();
            return await saver.WriteToString(testRun);
        }
    }
}
