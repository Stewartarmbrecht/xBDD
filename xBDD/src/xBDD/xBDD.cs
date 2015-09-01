using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using xBDD.Core;
using xBDD.Reporting;

namespace xBDD
{
    public class xBDD
    {
        static ITestRun testRun;
        public static ITestRun CurrentRun
        {
            get
            {
                if (testRun == null)
                {
                    testRun = new TestRun(new Factory());
                }
                return testRun;
            }
        }
        static IReportFactory reportFactory;
        public static IReportFactory ReportFactory
        {
            get
            {
                if (reportFactory == null)
                    reportFactory = new ReportFactory();
                return reportFactory;
            }
        }
    }
}
