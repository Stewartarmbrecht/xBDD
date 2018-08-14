using xBDD.Browser;

namespace xBDD.Features.Pages.HtmlReportPage
{
    public partial class FeatureScenarioDistro
    {
        public PageElement BadgeDistro(int featureNumber)
        {
            return new PageElement("feature badge and distribution chart", $"#feature-{featureNumber}-badge-distro");
        }
        public PageElement Chart(int featureNumber)
        {
            return new PageElement("feature scenario distribution chart", $"#feature-{featureNumber}-distro");
        }
        public PageElement PassedBar(int featureNumber)
        {
            return new PageElement("feature scenario distribution passed bar","#feature-"+featureNumber+"-distro div.distro.bg-success");
        }
        public PageElement SkippedBar(int featureNumber)
        {
            return new PageElement("feature scenario distribution skipped bar","#feature-"+featureNumber+"-distro div.distro.bg-warning");
        }
        public PageElement FailedBar(int featureNumber)
        {
            return new PageElement("feature scenario distribution failed bar","#feature-"+featureNumber+"-distro div.distro.bg-danger");
        }
    }
}