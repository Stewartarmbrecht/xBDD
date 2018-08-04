using xBDD.Browser;

namespace xBDD.Reporting.Test.Pages.HtmlReportPage
{
    public class Area
    {
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