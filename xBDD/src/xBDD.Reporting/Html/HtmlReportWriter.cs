using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xBDD.Reporting.Html
{
    public class HtmlReportWriter
    {
        HtmlReportWriterFactory factory;
        public HtmlReportWriter(HtmlReportWriterFactory factory)
        {
            this.factory = factory;
        }
        StringBuilder sb = new StringBuilder();
        public void WriteReport(TestRun testRun)
        {
            WriteTestRunSummary(testRun);
            WriteAreas(testRun);
        }

        private void WriteAreas(TestRun testRun)
        {
            //WriteSectionStart();
            //foreach(var area in testRun.Areas)
            //WriteSectionEnd();
        }

        private void WriteTestRunSummary(TestRun testRun)
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
