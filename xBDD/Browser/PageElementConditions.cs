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

        public Step HasText(string text, int waitMilliseconds = -1, bool captureOutput = false)
        {
            return xB.CreateAsyncStep(
                $"{this.stepNamePrefix}{this.pageElement.Description} has text '{text}'",
                async (s) => {
                    try {
                        await this.webBrowser.WaitTillVisible(this.pageElement, waitMilliseconds);
                        this.webBrowser.ElementHasText(this.pageElement, text);
                        if(s.Outcome == Outcome.Failed || captureOutput) {
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
        /// <summary>
        /// Verifies that the previously selected element's style
        /// matches using the regex expression you provide.
        /// </summary>
        /// <param name="description">The description to display in the step name.</param>
        /// <param name="regexMatch">The regex expressions to use to match against the style property.</param>
        /// <param name="waitMilliseconds">The time in milliseconds to wait until the element is visible.</param>
        /// <param name="captureOutput">Triggers the system to capture the web page source in the output of the step.</param>
        /// <returns>Step to add to your scenario.</returns>
        public Step HasStyle(string description, string regexMatch, int waitMilliseconds = -1, bool captureOutput = false)
        {
            return xB.CreateAsyncStep(
                $"{this.stepNamePrefix}{this.pageElement.Description} {description}",
                async (s) => {
                    try {
                        await this.webBrowser.WaitTillVisible(this.pageElement, waitMilliseconds);
                        this.webBrowser.ElementStyleMatches(this.pageElement, regexMatch);
                        if(s.Outcome == Outcome.Failed || captureOutput) {
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
        public Step Style(string text, string match, int waitMilliseconds = -1, bool captureOutput = false)
        {
            return xB.CreateAsyncStep(
                $"{this.stepNamePrefix}{this.pageElement.Description} is visible",
                async (s) => {
                    try {
                        await this.webBrowser.WaitTillVisible(this.pageElement, waitMilliseconds);
                        this.webBrowser.ElementStyleMatches(this.pageElement, match);
                        if(s.Outcome == Outcome.Failed || captureOutput) {
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
        public Step HasTitleAKAHoverText(string text, int waitMilliseconds = -1, bool captureOutput = false)
        {
            return xB.CreateAsyncStep(
                $"{this.stepNamePrefix}{this.pageElement.Description} has a title attribute of {text}",
                async (s) => {
                    try {
                        await this.webBrowser.WaitTillVisible(this.pageElement, waitMilliseconds);
                        this.webBrowser.ElementHasTitle(this.pageElement, text);
                        if(s.Outcome == Outcome.Failed || captureOutput) {
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
        public Step IsVisible(int waitMilliseconds = -1, bool captureOutput = false)
        {
            return xB.CreateAsyncStep(
                $"{this.stepNamePrefix}{this.pageElement.Description} is visible",
                async (s) => {
                    try {
                        await this.webBrowser.WaitTillVisible(this.pageElement, waitMilliseconds);
                        if(click) {
                            this.webBrowser.Click(this.pageElement);
                        }
                        if(s.Outcome == Outcome.Failed || captureOutput) {
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
        public Step IsNotVisible(int waitMilliseconds = -1, bool captureOutput = false)
        {
            return xB.CreateAsyncStep(
                $"{this.stepNamePrefix}{this.pageElement.Description} is not visible",
                async (s) => {
                    try {
                        await this.webBrowser.WaitTillNotVisible(this.pageElement, waitMilliseconds);
                        if(click) {
                            this.webBrowser.Click(this.pageElement);
                        }
                        if(s.Outcome == Outcome.Failed || captureOutput) {
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
        public Step IsNotThere(int waitMilliseconds = -1, bool captureOutput = false)
        {
            return xB.CreateStep(
                $"{this.stepNamePrefix}{this.pageElement.Description} is not there",
                (s) => {
                    try {
                        this.webBrowser.ValidateNotExist(this.pageElement);
                        if(s.Outcome == Outcome.Failed || captureOutput) {
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