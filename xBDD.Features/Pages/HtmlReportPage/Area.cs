using xBDD.Browser;

namespace xBDD.Features.Pages.HtmlReportPage
{
    public class Area
    {
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
            return new PageElement("the area " + areaNumber + " features", "#area-" + areaNumber + "-features.collapse.show");   
        }
        public PageElement Duration(int areaNumber)
        {
            return new PageElement("the area " + areaNumber + " duration", "#area-" + areaNumber + " span.area.duration");   
        }
    }
}