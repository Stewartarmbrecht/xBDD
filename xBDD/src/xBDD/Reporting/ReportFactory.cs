using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace xBDD.Reporting
{
    public class ReportFactory : IReportFactory
    {
        public IReportWriter GetHtmlReportWriter()
        {
            var factory = new Html.HtmlReportWriterFactory();
            return new Html.HtmlReportWriter(factory);
        }
    }
}
