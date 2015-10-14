using xBDD.Browser;

namespace xBDD.Reporting.Test.Pages
{
    public class HtmlReportPageArea
    {
        public static PageElement GreenAreaName(int areaNumber)
        {
            return new PageElement("area " + areaNumber + " with green name", "#area-" + areaNumber + " h2.text-success");   
        }
        public static PageElement AreaFeatures(int areaNumber)
        {
            return new PageElement("area " + areaNumber + " features", "#area-" + areaNumber + "-features");   
        }
    }
}