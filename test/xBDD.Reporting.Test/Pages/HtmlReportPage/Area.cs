using xBDD.Browser;

namespace xBDD.Reporting.Test.Pages.HtmlReportPage
{
    public class Area
    {
        public static PageElement Name(int areaNumber)
        {
            return new PageElement("area title line","#area-" + areaNumber + " h2 span.name");
        }
        public static PageElement NameGreen(int areaNumber)
        {
            return new PageElement("area " + areaNumber + " with green name", "#area-" + areaNumber + " h2.text-success");   
        }
        public static PageElement NameYellow(int areaNumber)
        {
            return new PageElement("area " + areaNumber + " with yelow name", "#area-" + areaNumber + " h2.text-warning");   
        }
        public static PageElement NameRed(int areaNumber)
        {
            return new PageElement("area " + areaNumber + " with red name", "#area-" + areaNumber + " h2.text-danger");   
        }
        public static PageElement NameGray(int areaNumber)
        {
            return new PageElement("area " + areaNumber + " with grey name", "#area-" + areaNumber + " h2.text-muted");   
        }
        public static PageElement Features(int areaNumber)
        {
            return new PageElement("area " + areaNumber + " features", "#area-" + areaNumber + "-features");   
        }
    }
}