using xBDD.Reporting.TextFile;

namespace xBDD.Reporting
{
    public class ReportingFactory
    {
        public TextWriter GetTextFileWriter()
        {
            return new TextWriter();
        }
    }
}
