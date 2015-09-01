using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xBDD.Reporting.Html
{
    public class HtmlReportWriter
    {
        IHtmlReportWriterFactory factory;
        public HtmlReportWriter(IHtmlReportWriterFactory factory)
        {
            this.factory = factory;
        }
        StringBuilder sb = new StringBuilder();
        public void WriteToFile(ITestRun testRun)
        {
            WriteTestRunSummary(testRun);
            WriteAreas(testRun);
        }

        private void WriteAreas(ITestRun testRun)
        {
            //WriteSectionStart();
            //foreach(var area in testRun.Areas)
            //WriteSectionEnd();
        }

        private void WriteTestRunSummary(ITestRun testRun)
        {
            //WriteSectionStart();
            //WriteTitle(testRun);
            //WriteOutcome(testRun);
            //WriteTimeStats(testRun);
            //WriteScenarioStats(testRun);
            //WriteStepStats(testRun);
            //WriteSectionEnd();
        }
    }
}
