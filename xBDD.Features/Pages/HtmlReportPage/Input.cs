using xBDD.Browser;

namespace xBDD.Features.Pages.HtmlReportPage
{
    public class Input
    {
        public PageElement Text(int stepNumber)
        {
            return new PageElement("step text input", "#input-" + stepNumber + ".mp");
        }
        public PageElement Code(int stepNumber)
        {
            return new PageElement("step text input", "#input-" + stepNumber + "[class=\"code prettify\"]");
        }
        public PageElement Html(int stepNumber)
        {
            return new PageElement("step text input", "#input-" + stepNumber + "[class=\"code prettify lang-html\"]");
        }
        public PageElement HtmlPreview(int stepNumber)
        {
            return new PageElement("step text input", "#input-preview-" + stepNumber);
        }

        public PageElement Link(int stepNumber)
        {
            return new PageElement("step input link", "#step-" + stepNumber + " a.step-input-link");
        }
        public PageElement Section(int stepNumber)
        {
            return new PageElement("step input", "#step-" + stepNumber + " div.input");
        }
    }
}