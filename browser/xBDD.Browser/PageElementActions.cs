using xBDD.Model;

namespace xBDD.Browser
{
    
    public class PageElementConditions
    {
        private PageElement pageElement;
        private WebBrowser webBrowser;
        private string stepNamePrefix;
        public PageElementConditions(WebBrowser webBrowser, PageElement pageElement, string stepNamePrefix)
        {
            this.pageElement = pageElement;
            this.webBrowser = webBrowser;
            this.stepNamePrefix = stepNamePrefix;
        }

        public Step IsVisible(int waitMilliseconds = -1)
        {
            return xB.CreateAsyncStep(
                $"{this.stepNamePrefix}{this.pageElement.Description} is visible",
                async (s) => {
                    await this.webBrowser.WaitTillVisible(this.pageElement, waitMilliseconds);
                    s.Output = this.webBrowser.GetPageSource();
                    s.OutputFormat = TextFormat.htmlpreview;
                }
            );
        }
        public Step IsNotVisible(int waitMilliseconds = -1)
        {
            return xB.CreateAsyncStep(
                $"{this.stepNamePrefix}{this.pageElement.Description} is not visible",
                async (s) => {
                    try {
                        await this.webBrowser.WaitTillNotVisible(this.pageElement, waitMilliseconds);
                        s.Output = this.webBrowser.GetPageSource();
                        s.OutputFormat = TextFormat.htmlpreview;
                    } catch(System.Exception ex)
                    {
                        s.Output = this.webBrowser.GetPageSource();
                        s.OutputFormat = TextFormat.htmlpreview;
                        throw;
                    }
                }
            );
        }
    }
}