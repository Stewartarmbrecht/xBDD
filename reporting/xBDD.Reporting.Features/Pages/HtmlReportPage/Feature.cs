using xBDD.Browser;

namespace xBDD.Reporting.Features.Pages.HtmlReportPage
{
    public class Feature
    {
        public static PageElement Name(int featureNumber)
        {
            return new PageElement("feature name","#feature-" + featureNumber + " h3 span.name");
        }
        public static PageElement Badge(int featureNumber)
        {
            return new PageElement("feature name","#feature-" + featureNumber + " h3 span.badge");
        }
        public static PageElement BadgeGreen(int featureNumber)
        {
            return new PageElement("feature " + featureNumber + " with green name", "#feature-" + featureNumber + " h3 span.badge-success");   
        }
        public static PageElement BadgeYellow(int featureNumber)
        {
            return new PageElement("feature " + featureNumber + " with yellow name", "#feature-" + featureNumber + " h3 span.badge-warning");   
        }
        public static PageElement BadgeRed(int featureNumber)
        {
            return new PageElement("feature " + featureNumber + " with red name", "#feature-" + featureNumber + " h3 span.badge-danger");   
        }
        public static PageElement BadgeGray(int featureNumber)
        {
            return new PageElement("feature " + featureNumber + " with grey name", "#feature-" + featureNumber + " h3 span.badge-secondary");   
        }
        public static PageElement Scenarios(int featureNumber)
        {
            return new PageElement("feature " + featureNumber + " scenarios", "#feature-" + featureNumber + "-scenarios");   
        }
        internal static PageElement Statement(int featureNumber)
        {
            return new PageElement("feature " + featureNumber + " scenarios", "#feature-" + featureNumber + "-statement");   
        }
    }
}