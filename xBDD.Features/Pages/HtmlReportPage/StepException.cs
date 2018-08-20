using xBDD.Browser;

namespace xBDD.Features.Pages.HtmlReportPage
{
    public class StepException
    {
        public PageElement Link(int stepNumber, int scenarioNumber)
        {
            return new PageElement($"the step {stepNumber} error link", $"#scenario-{scenarioNumber}-steps.collapse.show #step-{stepNumber} a.step-error-link");
        }

        public PageElement Section(int stepNumber)
        {
            return  new PageElement($"the step {stepNumber} exception", "#step-" + stepNumber + " div.error.collapse.show dl.exception");
        }

        public PageElement Type(int stepNumber)
        {
            return  new PageElement($"the step {stepNumber} exception type", "#step-" + stepNumber + " dl.exception dd.error-type");
        }

        public PageElement Message(int stepNumber)
        {
            return  new PageElement($"the step {stepNumber} exception message", "#step-" + stepNumber + " dl.exception dd.error-message");
        }

        public PageElement StackTrace(int stepNumber)
        {
            return  new PageElement($"the step {stepNumber} exception stack trace", "#step-" + stepNumber + " dl.exception dd.error-stack");
        }

        public PageElement InnerException(int stepNumber)
        {
            var selector = "#step-" + stepNumber + " dl.exception>dd.inner-exception>dl.exception";
            return  new PageElement($"the step {stepNumber} inner exception", selector);
        }

        public PageElement InnerExceptionType(int stepNumber)
        {
            var selector = "#step-" + stepNumber + " dl.exception>dd.inner-exception>dl.exception>dd.error-type";
            return  new PageElement($"the step {stepNumber} inner exception type", selector);
        }

        public PageElement InnerExceptionMessage(int stepNumber)
        {
            var selector = "#step-" + stepNumber + " dl.exception>dd.inner-exception>dl.exception>dd.error-message";
            return  new PageElement($"the step {stepNumber} inner exception message", selector);
        }

        public PageElement InnerExceptionStackTrace(int stepNumber)
        {
            var selector = "#step-" + stepNumber + " dl.exception>dd.inner-exception>dl.exception>dd.error-stack";
            return  new PageElement($"the step {stepNumber} inner exception stack trace", selector);
        }
    }
}