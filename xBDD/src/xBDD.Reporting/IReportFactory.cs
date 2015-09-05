using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace xBDD.Reporting

{
    public interface IReportFactory
    {
        IReportWriter GetHtmlReportWriter();
    }
}
