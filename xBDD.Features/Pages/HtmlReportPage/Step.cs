using xBDD.Browser;

namespace xBDD.Features.Pages.HtmlReportPage
{
    public class Step
    {
        public PageElement Name(int stepNumber)
        {
            return new PageElement("the step name","#step-" + stepNumber + " h5 span.name");
        }
        public PageElement BadgeGreen(int stepNumber)
        {
            return new PageElement("the step " + stepNumber + " with green badge", "#step-" + stepNumber + " h5 span.badge-success");   
        }
        public PageElement BadgeYellow(int stepNumber)
        {
            return new PageElement("the step " + stepNumber + " with yellow badge", "#step-" + stepNumber + " h5 span.badge-warning");   
        }
        public PageElement BadgeRed(int stepNumber)
        {
            return new PageElement("the step " + stepNumber + " with red badge", "#step-" + stepNumber + " h5 span.badge-danger");   
        }
    }
}