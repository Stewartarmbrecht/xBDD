using xBDD.Browser;

namespace xBDD.Features.Pages.HtmlReportPage
{
    public partial class AreaFeatureDistro
    {
        public PageElement BadgeDistro(int areaNumber)
        {
            return new PageElement($"the area {areaNumber} badge and distribution chart", $"#area-{areaNumber}-badge-distro");
        }
        public PageElement Chart(int areaNumber)
        {
            return new PageElement($"the area {areaNumber} feature distribution chart", $"#area-{areaNumber}-distro");
        }
        public PageElement PassedBar(int areaNumber)
        {
            return new PageElement($"the area {areaNumber} feature distribution passed bar","#area-"+areaNumber+"-distro div.distro.bg-success");
        }
        public PageElement SkippedBar(int areaNumber)
        {
            return new PageElement($"the area {areaNumber} feature distribution skipped bar","#area-"+areaNumber+"-distro div.distro.bg-warning");
        }
        public PageElement FailedBar(int areaNumber)
        {
            return new PageElement($"the area {areaNumber} feature distribution failed bar","#area-"+areaNumber+"-distro div.distro.bg-danger");
        }
    }
}