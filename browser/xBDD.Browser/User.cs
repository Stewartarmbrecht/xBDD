using xBDD.Model;
using xBDD.Browser;

namespace xBDD.Browser
{
    public static class StepExtensions
    {
        public static Step Because(this Step step, string explanation)
        {
            step.AppendToName($" because {explanation}");
            return step;
        }
    }

    public class User 
    {
        private WebBrowser browser;

        public User()
        {
            this.browser = new WebBrowser(WebDriver.Current);
        }

        public Step NavigateTo(PageLocation pageLocation)
        {
            var step = xB.CreateStep(
                $"you navigate to {pageLocation.Description}",
                (s) => {
                    browser.Load(pageLocation);
                    return;
                });
            return step;
        }

        public PageElementConditions WaitTill(PageElement pageElement)
        {
            return new PageElementConditions(this.browser, pageElement, "you wait till ");
        }
        public PageElementConditions WillSee(PageElement pageElement)
        {
            return new PageElementConditions(this.browser, pageElement, "you will see ");
        }
        public PageElementConditions ClickWhen(PageElement pageElement)
        {
            return new PageElementConditions(this.browser, pageElement, "you click when ", true);
        }
        public Step Click(PageElement pageElement, int waitTillVisibleMilliseconds = -1)
        {
            var step = xB.CreateAsyncStep(
                $"you click the {pageElement.Description}",
                async (s) => {
                    try {
                        await this.browser.WaitTillVisible(pageElement, waitTillVisibleMilliseconds);
                        this.browser.Click(pageElement);
                    } catch (System.Exception) {
                        s.Output = this.browser.GetPageSource();
                        s.OutputFormat = TextFormat.htmlpreview;
                        throw;
                    }
                });
            return step;
        }
        public Step AreViewingAPageWithTheTitle(string text)
        {
            var step = xB.CreateStep(
                $"you are viewing a page with the title '{text}'",
                (s) => {
                    this.browser.HasTitle(text);
                });
            return step;
        }
    }
}