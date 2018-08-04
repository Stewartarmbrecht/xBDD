using xBDD.Browser;

namespace xBDD.Reporting.Test.Pages.HtmlReportPage
{
    public class Step
    {
        public static PageElement Name(int stepNumber)
        {
            return new PageElement("step name","#step-" + stepNumber + " h5 span.name");
        }
        public static PageElement BadgeGreen(int stepNumber)
        {
            return new PageElement("step " + stepNumber + " with green name", "#step-" + stepNumber + " h5 span.badge-success");   
        }
        public static PageElement BadgeYellow(int stepNumber)
        {
            return new PageElement("step " + stepNumber + " with yellow name", "#step-" + stepNumber + " h5 span.badge-warning");   
        }
        public static PageElement BadgeRed(int stepNumber)
        {
            return new PageElement("step " + stepNumber + " with red name", "#step-" + stepNumber + " h5 span.badge-danger");   
        }
    }
}