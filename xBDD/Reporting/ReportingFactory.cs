using xBDD.Reporting.Html;
using xBDD.Reporting.Text;
using xBDD.Reporting.Code;

namespace xBDD.Reporting
{
    internal class ReportingFactory
    {
        internal TextWriter GetTextFileWriter()
        {
            return new TextWriter();
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
