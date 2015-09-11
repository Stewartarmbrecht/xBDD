using xBDD.Reporting.TextFile;

namespace xBDD.Reporting
{
    public class ReportingFactory : IReportingFactory
    {
        public ITextFileWriter GetTextFileWriter()
        {
            return new TextFileWriter();
        }
    }
}
