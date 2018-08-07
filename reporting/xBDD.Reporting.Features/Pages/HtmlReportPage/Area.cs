using xBDD.Browser;

namespace xBDD.Reporting.Features.Pages.HtmlReportPage
{
    public class Area
    {
        public readonly PageElement FirstAreasFeatureList = new PageElement("the first area's feature list", "#area-1-features");
        public readonly PageElement FirstAreasFeatureListNotExpandingOrCollapsing = new PageElement("the first area's feature list that is not expanding or collapsing", "#area-1-features:not(.collapsing)");
        public readonly PageElement ExpandAllAreasLink = new PageElement("the expand all areas link", "#expand-all-areas-button");
        public readonly PageElement MenuButton = new PageElement("the menu button", "#menu-button");
        public readonly PageElement CollapseAllAreasLink = new PageElement("the collapse all areas link", "#collapse-all-areas-button");
        public readonly PageElement SecondAreasFeatureList = new PageElement("the second area's feature list", "#area-2-features");
        public readonly PageElement SecondAreasFeatureListNotExpandingOrCollapsing = new PageElement("the second area's feature list that is not expanding or collapsing", "#area-2-features:not(.collapsing)");
        public readonly PageElement FirstAreaName = new PageElement("the first area name", "#area-1-name");
        public static PageElement Name(int areaNumber)
        {
            return new PageElement("area title line","#area-" + areaNumber + "-name");
        }
        public static PageElement Badge(int areaNumber)
        {
            return new PageElement("area title line","#area-" + areaNumber + "-badge");
        }
        public static PageElement BadgeGreen(int areaNumber)
        {
            return new PageElement("area " + areaNumber + " with green badge", "#area-" + areaNumber + " h2 span.badge-success");   
        }
        public static PageElement BadgeYellow(int areaNumber)
        {
            return new PageElement("area " + areaNumber + " with yelow badge", "#area-" + areaNumber + " h2 span.badge-warning");   
        }
        public static PageElement BadgeRed(int areaNumber)
        {
            return new PageElement("area " + areaNumber + " with red badge", "#area-" + areaNumber + " h2 span.badge-danger");   
        }
        public static PageElement BadgeGray(int areaNumber)
        {
            return new PageElement("area " + areaNumber + " with grey badge", "#area-" + areaNumber + " h2 span.badge-secondary");   
        }
        public static PageElement Features(int areaNumber)
        {
            return new PageElement("area " + areaNumber + " features", "#area-" + areaNumber + "-features");   
        }
    }
}