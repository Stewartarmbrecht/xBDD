using xBDD.Model;
using xBDD.Browser;

namespace xBDD.Browser
{

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
        public Step Click(PageElement pageElement, int waitTillVisibleMilliseconds = -1)
        {
            var step = xB.CreateAsyncStep(
                $"you click the {pageElement.Description}",
                async (s) => {
                    await this.browser.WaitTillVisible(pageElement, waitTillVisibleMilliseconds);
                    s.Output = this.browser.GetPageSource();
                    s.OutputFormat = TextFormat.htmlpreview;
                    await this.browser.Click(pageElement);
                });
            return step;
        }
    }
}