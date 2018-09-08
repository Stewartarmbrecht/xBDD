using xBDD.Browser;

namespace xBDD.Features.Pages.HtmlReportPage
{
    public partial class AreaFeatureStats
    {
        
        public PageElement Section(int areaNumber)
        {
            return new PageElement($"the area {areaNumber} feature stats","#area-"+areaNumber+"-feature-stats");
        }
        public PageElement BarChart(int areaNumber)
        {
            return new PageElement($"the area {areaNumber} feature stats bar chart","#area-"+areaNumber+"-feature-stats td.outcome-bar-chart");
        }
        public PageElement SuccessBar(int areaNumber)
        {
            return new PageElement($"the area {areaNumber} feature success bar","#area-"+areaNumber+"-feature-stats td.passed-bar");
        }
        public PageElement SkippedBar(int areaNumber)
        {
            return new PageElement($"the area {areaNumber} feature skipped bar","#area-"+areaNumber+"-feature-stats td.skipped-bar");
        }
        public PageElement FailedBar(int areaNumber)
        {
            return new PageElement($"the area {areaNumber} feature failed bar","#area-"+areaNumber+"-feature-stats td.failed-bar");
        }
        public PageElement Total(int areaNumber)
        {
            return new PageElement($"the area {areaNumber} feature total","#area-"+areaNumber+" span.badge.total");
        }
        public PageElement Passed(int areaNumber)
        {
            return new PageElement($"the area {areaNumber} feature passed count","#area-"+areaNumber+"-feature-stats td.passed");
        }
        public PageElement Skipped(int areaNumber)
        {
            return new PageElement($"the area {areaNumber} feature skipped count","#area-"+areaNumber+"-feature-stats td.skipped");
        }
        public PageElement Failed(int areaNumber)
        {
            return new PageElement($"the area {areaNumber} feature failed count","#area-"+areaNumber+"-feature-stats td.failed");
        }
    }
}