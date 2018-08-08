using xBDD.Browser;

namespace xBDD.Reporting.Features.Pages.HtmlReportPage
{
    public class Feature
    {
        public PageElement Name(int featureNumber)
        {
            return new PageElement("the feature name","#feature-" + featureNumber + " h3 span.name");
        }
        public PageElement Badge(int featureNumber)
        {
            return new PageElement("the feature badge","#feature-" + featureNumber + " h3 span.badge");
        }
        public PageElement BadgeGreen(int featureNumber)
        {
            return new PageElement("the feature " + featureNumber + " with green badge", "#feature-" + featureNumber + " h3 span.badge-success");   
        }
        public PageElement BadgeYellow(int featureNumber)
        {
            return new PageElement("the feature " + featureNumber + " with yellow badge", "#feature-" + featureNumber + " h3 span.badge-warning");   
        }
        public PageElement BadgeRed(int featureNumber)
        {
            return new PageElement("the feature " + featureNumber + " with red badge", "#feature-" + featureNumber + " h3 span.badge-danger");   
        }
        public PageElement BadgeGray(int featureNumber)
        {
            return new PageElement("the feature " + featureNumber + " with grey badge", "#feature-" + featureNumber + " h3 span.badge-secondary");   
        }
        public PageElement Scenarios(int featureNumber)
        {
            return new PageElement("the feature " + featureNumber + " scenarios", "#feature-" + featureNumber + "-scenarios");   
        }
        internal PageElement Statement(int featureNumber)
        {
            return new PageElement("the feature " + featureNumber + " statement", "#feature-" + featureNumber + "-statement");   
        }
    }
}