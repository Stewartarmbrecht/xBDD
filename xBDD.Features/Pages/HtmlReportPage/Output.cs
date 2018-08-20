using xBDD.Browser;

namespace xBDD.Features.Pages.HtmlReportPage
{
    public class Output
    {
        public PageElement Text(int stepNumber)
        {
            return new PageElement($"the step {stepNumber} text output", "#output-" + stepNumber + ".text");
        }
        public PageElement Code(int stepNumber)
        {
            return new PageElement($"the step {stepNumber} text output", "#output-" + stepNumber + "[class=\"code prettify\"]");
        }
        public PageElement Html(int stepNumber)
        {
            return new PageElement($"the step {stepNumber} text output", "#output-" + stepNumber + "[class=\"code prettify lang-html\"]");
        }
        public PageElement HtmlPreview(int stepNumber)
        {
            return new PageElement($"the step {stepNumber} text output", "#output-preview-" + stepNumber);
        }

        public PageElement Link(int stepNumber)
        {
            return new PageElement($"the step {stepNumber} output link", "#step-" + stepNumber + " a.step-output-link");
        }
        public PageElement Section(int stepNumber)
        {
            return new PageElement($"the step {stepNumber} output", "#step-" + stepNumber + " div.output");
        }
    }
}