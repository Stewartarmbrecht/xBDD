using xBDD.Browser;

namespace xBDD.Features.Pages.HtmlReportPage
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
        public readonly PageElement FirstAreaGreenBadge = new PageElement("the first area green badge", "#area-1-badge.badge-success");
        public readonly PageElement FirstAreaYellowBadge = new PageElement("the first area yellow badge", "#area-1-badge.badge-warning");
        public readonly PageElement FirstAreaRedBadge = new PageElement("the first area red badge", "#area-1-badge.badge-danger");
        public PageElement Name(int areaNumber)
        {
            return new PageElement("the area title line","#area-" + areaNumber + "-name");
        }
        public PageElement Badge(int areaNumber)
        {
            return new PageElement("the area title line","#area-" + areaNumber + "-badge");
        }
        public PageElement BadgeGreen(int areaNumber)
        {
            return new PageElement("the area " + areaNumber + " with green badge", "#area-" + areaNumber + "-badge.badge-success");   
        }
        public PageElement BadgeYellow(int areaNumber)
        {
            return new PageElement("the area " + areaNumber + " with yelow badge", "#area-" + areaNumber + "-badge.badge-warning");   
        }
        public PageElement BadgeRed(int areaNumber)
        {
            return new PageElement("the area " + areaNumber + " with red badge", "#area-" + areaNumber + "-badge.badge-danger");   
        }
        public PageElement BadgeGray(int areaNumber)
        {
            return new PageElement("the area " + areaNumber + " with grey badge", "#area-" + areaNumber + "-badge.badge-secondary");   
        }
        public PageElement Features(int areaNumber)
        {
            return new PageElement("the area " + areaNumber + " features", "#area-" + areaNumber + "-features");   
        }
        public PageElement Duration(int areaNumber)
        {
            return new PageElement("the area " + areaNumber + " duration", "#area-" + areaNumber + " span.area.duration");   
        }
    }
}