using xBDD.Reporting.Html;
using xBDD.Reporting.Text;
using xBDD.Reporting.Code;
using xBDD.Reporting.Outline;

namespace xBDD.Reporting
{
    internal class ReportingFactory
    {
        internal TextWriter GetTextWriter()
        {
            return new TextWriter();
        }

        internal OpmlWriter GetOpmlWriter()
        {
            return new OpmlWriter();
        }

        internal CodeWriter GetCodeWriter()
        {
            return new CodeWriter();
        }

        internal HtmlWriter GetHtmlFileWriter(string removeFromAreaNameStart, bool failuresOnly)
        {
            return new HtmlWriter(removeFromAreaNameStart, failuresOnly);
        }
    }
}
