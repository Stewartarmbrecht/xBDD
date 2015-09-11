using xBDD.Reporting.TextFile;

namespace xBDD.Reporting
{
    public interface IReportingFactory
    {
        ITextFileWriter GetTextFileWriter();
    }
}
