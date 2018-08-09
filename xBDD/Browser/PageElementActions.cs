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
                        this.webBrowser.ElementHasText(this.pageElement, text);
                        if(s.Outcome == Outcome.Failed) {
                            s.Output = this.webBrowser.GetPageSource();
                            s.OutputFormat = TextFormat.htmlpreview;
                        }
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
                        this.webBrowser.ElementStyleMatches(this.pageElement, match);
                        if(s.Outcome == Outcome.Failed) {
                            s.Output = this.webBrowser.GetPageSource();
                            s.OutputFormat = TextFormat.htmlpreview;
                        }
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
                        this.webBrowser.ElementHasTitle(this.pageElement, text);
                        if(s.Outcome == Outcome.Failed) {
                            s.Output = this.webBrowser.GetPageSource();
                            s.OutputFormat = TextFormat.htmlpreview;
                        }
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
                        if(click) {
                            this.webBrowser.Click(this.pageElement);
                        }
                        if(s.Outcome == Outcome.Failed) {
                            s.Output = this.webBrowser.GetPageSource();
                            s.OutputFormat = TextFormat.htmlpreview;
                        }
                    } catch (System.Exception) {
                        s.Output = this.webBrowser.GetPageSource();
                        s.OutputFormat = TextFormat.htmlpreview;
                        throw;
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
                        if(click) {
                            this.webBrowser.Click(this.pageElement);
                        }
                        if(s.Outcome == Outcome.Failed) {
                            s.Output = this.webBrowser.GetPageSource();
                            s.OutputFormat = TextFormat.htmlpreview;
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
        public Step IsNotThere(int waitMilliseconds = -1)
        {
            return xB.CreateStep(
                $"{this.stepNamePrefix}{this.pageElement.Description} is not there",
                (s) => {
                    try {
                        this.webBrowser.ValidateNotExist(this.pageElement);
                        if(s.Outcome == Outcome.Failed) {
                            s.Output = this.webBrowser.GetPageSource();
                            s.OutputFormat = TextFormat.htmlpreview;
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