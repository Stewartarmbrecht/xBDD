using xBDD.Browser;

namespace xBDD.Reporting.Features.Pages.HtmlReportPage
{
    public partial class AreaFeatureStats
    {
        
        public static PageElement Section(int areaNumber)
        {
            return new PageElement("area feature stats","#area-"+areaNumber+"-feature-stats");
        }
        public static PageElement BarChart(int areaNumber)
        {
            return new PageElement("area feature stats bar chart","#area-"+areaNumber+"-feature-stats td.outcome-bar-chart");
        }
        public static PageElement SuccessBar(int areaNumber)
        {
            return new PageElement("area feature success bar","#area-"+areaNumber+"-feature-stats td.passed-bar");
        }
        public static PageElement SkippedBar(int areaNumber)
        {
            return new PageElement("area feature skipped bar","#area-"+areaNumber+"-feature-stats td.skipped-bar");
        }
        public static PageElement FailedBar(int areaNumber)
        {
            return new PageElement("area feature failed bar","#area-"+areaNumber+"-feature-stats td.failed-bar");
        }
        public static PageElement Total(int areaNumber)
        {
            return new PageElement("area feature total","#area-"+areaNumber+" span.badge.total");
        }
        public static PageElement Passed(int areaNumber)
        {
            return new PageElement("area feature passed count","#area-"+areaNumber+"-feature-stats td.passed");
        }
        public static PageElement Skipped(int areaNumber)
        {
            return new PageElement("area feature skipped count","#area-"+areaNumber+"-feature-stats td.skipped");
        }
        public static PageElement Failed(int areaNumber)
        {
            return new PageElement("area feature failed count","#area-"+areaNumber+"-feature-stats td.failed");
        }
    }
}