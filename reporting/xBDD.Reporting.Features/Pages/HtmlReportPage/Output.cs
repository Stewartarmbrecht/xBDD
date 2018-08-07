using xBDD.Browser;

namespace xBDD.Reporting.Features.Pages.HtmlReportPage
{
    public class Output
    {
        public static PageElement Text(int stepNumber)
        {
            return new PageElement("step text output", "#output-" + stepNumber + ".text");
        }
        public static PageElement Code(int stepNumber)
        {
            return new PageElement("step text output", "#output-" + stepNumber + "[class=\"code prettify\"]");
        }
        public static PageElement Html(int stepNumber)
        {
            return new PageElement("step text output", "#output-" + stepNumber + "[class=\"code prettify lang-html\"]");
        }
        public static PageElement HtmlPreview(int stepNumber)
        {
            return new PageElement("step text output", "#output-preview-" + stepNumber);
        }

        public static PageElement Link(int stepNumber)
        {
            return new PageElement("step output link", "#step-" + stepNumber + " a.step-output-link");
        }
        public static PageElement Section(int stepNumber)
        {
            return new PageElement("step output", "#step-" + stepNumber + " div.output");
        }
    }
}