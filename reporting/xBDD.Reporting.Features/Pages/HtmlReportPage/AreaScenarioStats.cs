using xBDD.Browser;

namespace xBDD.Reporting.Features.Pages.HtmlReportPage
{
    public partial class AreaScenarioStats
    {
        public PageElement Section(int areaNumber)
        {
            return new PageElement("area scenario stats","#area-"+areaNumber+"-scenario-stats");
        }
        public PageElement BarChart(int areaNumber)
        {
            return new PageElement("area scenario stats bar chart","#area-"+areaNumber+"-scenario-stats td.outcome-bar-chart");
        }
        public PageElement SuccessBar(int areaNumber)
        {
            return new PageElement("area scenario stats success bar","#area-"+areaNumber+"-scenario-stats td.passed-bar");
        }
        public PageElement SkippedBar(int areaNumber)
        {
            return new PageElement("area scenario stats skipped bar","#area-"+areaNumber+"-scenario-stats td.skipped-bar");
        }
        public PageElement FailedBar(int areaNumber)
        {
            return new PageElement("area scenario stats failed bar","#area-"+areaNumber+"-scenario-stats td.failed-bar");
        }
        public PageElement Passed(int areaNumber)
        {
            return new PageElement("area scenario stats passed count","#area-"+areaNumber+"-scenario-stats td.passed");
        }
        public PageElement Skipped(int areaNumber)
        {
            return new PageElement("area scenario stats skipped count","#area-"+areaNumber+"-scenario-stats td.skipped");
        }
        public PageElement Failed(int areaNumber)
        {
            return new PageElement("area scenario stats failed count","#area-"+areaNumber+"-scenario-stats td.failed");
        }
    }
}