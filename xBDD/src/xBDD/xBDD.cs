using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using xBDD.Core;
using xBDD.Reporting;
using xBDD.Stats;

namespace xBDD
{
    public class xBDD
    {
        static IFactory factory;
        static ITestRun testRun;
        public static ITestRun CurrentRun
        {
            get
            {
                EnsureFactory();
                if (testRun == null)
                {
                    testRun = factory.CreateTestRun();
                }
                return testRun;
            }
        }
        static void EnsureFactory()
        {
            if (factory == null)
                factory = new Factory();
        }
        static IReportFactory reportFactory;
        public static IReportFactory ReportFactory
        {
            get
            {
                EnsureFactory();
                if (reportFactory == null)
                    reportFactory = factory.CreateReportFactory();
                return reportFactory;
            }
        }
        static IStatsCompiler statsCompiler;
        public static IStatsCompiler StatsCompiler
        {
            get
            {
                EnsureFactory();
                if (statsCompiler == null)
                    statsCompiler = factory.CreateStatsCompiler();
                return statsCompiler;
            }
        }
    }
}
