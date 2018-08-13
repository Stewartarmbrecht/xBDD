using xBDD.Browser;

namespace xBDD.Features.Pages.HtmlReportPage
{
    public partial class StepStats
    {
        public PageElement Section(int stepNumber)
        {
            return new PageElement("step statistics",$"#step-{stepNumber}");
        }
        public PageElement StartTime(int stepNumber)
        {
            return new PageElement("step start time",$"#step-{stepNumber} span.step-stats-start-time");
        }
        public PageElement EndTime(int stepNumber)
        {
            return new PageElement("step end time",$"#step-{stepNumber} span.step-stats-end-time");
        }
        public PageElement Duration(int stepNumber)
        {
            return new PageElement("step duration",$"#step-{stepNumber} span.step-stats-duration");
        }
    }
}