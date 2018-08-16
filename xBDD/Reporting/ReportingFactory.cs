using xBDD.Reporting.Html;
using xBDD.Reporting.TextFile;

namespace xBDD.Reporting
{
    public class ReportingFactory
    {
        public TextWriter GetTextFileWriter()
        {
            return new TextWriter();
        }

        internal HtmlWriter GetHtmlFileWriter(string removeFromAreaNameStart, bool failuresOnly)
        {
            return new HtmlWriter(removeFromAreaNameStart, failuresOnly);
        }
    }
}
