using xBDD.Browser;

namespace xBDD.Reporting.Test.Pages.HtmlReportPage
{
    public class Step
    {
        public static PageElement Name(int stepNumber)
        {
            return new PageElement("step name","#step-" + stepNumber + " h5 span.name");
        }
        public static PageElement Green(int stepNumber)
        {
            return new PageElement("step " + stepNumber + " with green name", "#step-" + stepNumber + ".text-success");   
        }
        public static PageElement Yellow(int stepNumber)
        {
            return new PageElement("step " + stepNumber + " with yellow name", "#step-" + stepNumber + ".text-warning");   
        }
        public static PageElement Red(int stepNumber)
        {
            return new PageElement("step " + stepNumber + " with red name", "#step-" + stepNumber + ".text-danger");   
        }
    }
}