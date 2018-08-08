using xBDD.Model;

namespace xBDD.Browser
{
    
    public class PageElementConditions
    {
        private PageElement pageElement;
        private WebBrowser webBrowser;
        private string stepNamePrefix;
        private bool click;
        public PageElementConditions(WebBrowser webBrowser, PageElement pageElement, string stepNamePrefix, bool click = false)
        {
            this.pageElement = pageElement;
            this.webBrowser = webBrowser;
            this.stepNamePrefix = stepNamePrefix;
            this.click = click;
        }

        public Step HasText(string text, int waitMilliseconds = -1)
        {
            return xB.CreateAsyncStep(
                $"{this.stepNamePrefix}{this.pageElement.Description} is visible",
                async (s) => {
                    try {
                        await this.webBrowser.WaitTillVisible(this.pageElement, waitMilliseconds);
                        s.Output = this.webBrowser.GetPageSource();
                        s.OutputFormat = TextFormat.htmlpreview;
                        this.webBrowser.ElementHasText(this.pageElement, text);
                    } catch (System.Exception) {
                        s.Output = this.webBrowser.GetPageSource();
                        s.OutputFormat = TextFormat.htmlpreview;
                        throw;
                    }
                    if(click) {
                        this.webBrowser.Click(this.pageElement);
                    }
                }
            );
        }
        public Step Style(string text, string match, int waitMilliseconds = -1)
        {
            return xB.CreateAsyncStep(
                $"{this.stepNamePrefix}{this.pageElement.Description} is visible",
                async (s) => {
                    try {
                        await this.webBrowser.WaitTillVisible(this.pageElement, waitMilliseconds);
                        s.Output = this.webBrowser.GetPageSource();
                        s.OutputFormat = TextFormat.htmlpreview;
                        this.webBrowser.ElementStyleMatches(this.pageElement, match);
                    } catch (System.Exception) {
                        s.Output = this.webBrowser.GetPageSource();
                        s.OutputFormat = TextFormat.htmlpreview;
                        throw;
                    }
                    if(click) {
                        this.webBrowser.Click(this.pageElement);
                    }
                }
            );
        }
        public Step HasTitleAKAHoverText(string text, int waitMilliseconds = -1)
        {
            return xB.CreateAsyncStep(
                $"{this.stepNamePrefix}{this.pageElement.Description} is visible",
                async (s) => {
                    try {
                        await this.webBrowser.WaitTillVisible(this.pageElement, waitMilliseconds);
                        s.Output = this.webBrowser.GetPageSource();
                        s.OutputFormat = TextFormat.htmlpreview;
                        this.webBrowser.ElementHasTitle(this.pageElement, text);
                    } catch (System.Exception) {
                        s.Output = this.webBrowser.GetPageSource();
                        s.OutputFormat = TextFormat.htmlpreview;
                        throw;
                    }
                    if(click) {
                        this.webBrowser.Click(this.pageElement);
                    }
                }
            );
        }
        public Step IsVisible(int waitMilliseconds = -1)
        {
            return xB.CreateAsyncStep(
                $"{this.stepNamePrefix}{this.pageElement.Description} is visible",
                async (s) => {
                    try {
                        await this.webBrowser.WaitTillVisible(this.pageElement, waitMilliseconds);
                        s.Output = this.webBrowser.GetPageSource();
                        s.OutputFormat = TextFormat.htmlpreview;
                    } catch (System.Exception) {
                        s.Output = this.webBrowser.GetPageSource();
                        s.OutputFormat = TextFormat.htmlpreview;
                        throw;
                    }
                    if(click) {
                        this.webBrowser.Click(this.pageElement);
                    }
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
                        if(click) {
                            this.webBrowser.Click(this.pageElement);
                        }
                    } catch(System.Exception)
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