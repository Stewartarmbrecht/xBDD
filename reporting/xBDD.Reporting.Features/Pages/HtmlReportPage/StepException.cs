using xBDD.Browser;

namespace xBDD.Reporting.Features.Pages.HtmlReportPage
{
    public class StepException
    {
        public PageElement Section(int stepNumber)
        {
            return  new PageElement("exception", "#step-" + stepNumber + " dl.exception");
        }

        public PageElement Type(int stepNumber)
        {
            return  new PageElement("exception type", "#step-" + stepNumber + " dl.exception dd.error-type");
        }

        public PageElement Message(int stepNumber)
        {
            return  new PageElement("exception message", "#step-" + stepNumber + " dl.exception dd.error-message");
        }

        public PageElement StackTrace(int stepNumber)
        {
            return  new PageElement("exception stack trace", "#step-" + stepNumber + " dl.exception dd.error-stack");
        }

        public PageElement InnerException(int stepNumber)
        {
            var selector = "#step-" + stepNumber + " dl.exception>dd.inner-exception>dl.exception";
            return  new PageElement("inner exception", selector);
        }

        public PageElement InnerExceptionType(int stepNumber)
        {
            var selector = "#step-" + stepNumber + " dl.exception>dd.inner-exception>dl.exception>dd.error-type";
            return  new PageElement("inner exception type", selector);
        }

        public PageElement InnerExceptionMessage(int stepNumber)
        {
            var selector = "#step-" + stepNumber + " dl.exception>dd.inner-exception>dl.exception>dd.error-message";
            return  new PageElement("inner exception message", selector);
        }

        public PageElement InnerExceptionStackTrace(int stepNumber)
        {
            var selector = "#step-" + stepNumber + " dl.exception>dd.inner-exception>dl.exception>dd.error-stack";
            return  new PageElement("inner exception stack trace", selector);
        }
    }
}