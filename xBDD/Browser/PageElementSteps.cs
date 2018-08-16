namespace xBDD.Browser
{
    using xBDD.Model;
    
    /// <summary>
    /// Creates steps for performing actions on a provided page element. 
    /// This class is returned by the User class to help create a fluent style
    /// for writing out user actions.
    /// </summary>
    public class PageElementSteps
    {
        private PageElement pageElement;
        private WebBrowser webBrowser;
        private string stepNamePrefix;
        private bool click;
        internal PageElementSteps(WebBrowser webBrowser, PageElement pageElement, string stepNamePrefix, bool click = false)
        {
            this.pageElement = pageElement;
            this.webBrowser = webBrowser;
            this.stepNamePrefix = stepNamePrefix;
            this.click = click;
        }

        /// <summary>
        /// Verifies the page element has the text provided.
        /// </summary>
        /// <param name="text">The text to verify the page element has.</param>
        /// <param name="waitMilliseconds">The amount of time to wait.  If not provided the system will wait the default value (2 seconds).</param>
        /// <remarks>The default wait time could be overridden.</remarks>
        /// <param name="captureOutput">Triggers the system to capture the web page source in the output of the step after the actions. 
        /// The system will automatically do thie if there is an error or the step fails.</param>
        /// <returns></returns>
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
        /// <param name="waitMilliseconds">The amount of time to wait.  If not provided the system will wait the default value (2 seconds).</param>
        /// <remarks>The default wait time could be overridden.</remarks>
        /// <param name="captureOutput">Triggers the system to capture the web page source in the output of the step after the actions. 
        /// The system will automatically do thie if there is an error or the step fails.</param>
        /// <returns>Step to add to your scenario.</returns>
        public Step Style(string description, string regexMatch, int waitMilliseconds = -1, bool captureOutput = false)
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
        /// <summary>
        /// Verifies the page element has a title attribute that matches the value provided.
        /// Title attributes control the hover text for an element.
        /// </summary>
        /// <param name="text">The text value of the title.</param>
        /// <param name="waitMilliseconds">The amount of time to wait.  If not provided the system will wait the default value (2 seconds).</param>
        /// <remarks>The default wait time could be overridden.</remarks>
        /// <param name="captureOutput">Triggers the system to capture the web page source in the output of the step after the actions. 
        /// The system will automatically do thie if there is an error or the step fails.</param>
        /// <returns>Step to add to your scenario.</returns>
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
        /// <summary>
        /// Verifies a page element matching the CSS selector exists and is visible.
        /// </summary>
        /// <param name="waitMilliseconds">The amount of time to wait.  If not provided the system will wait the default value (2 seconds).</param>
        /// <remarks>The default wait time could be overridden.</remarks>
        /// <param name="captureOutput">Triggers the system to capture the web page source in the output of the step after the actions. 
        /// The system will automatically do thie if there is an error or the step fails.</param>
        /// <returns>Step to add to your scenario.</returns>
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
        /// <summary>
        /// Verifies a page element matching the CSS selector exists but is not visible.
        /// </summary>
        /// <param name="waitMilliseconds">The amount of time to wait.  If not provided the system will wait the default value (2 seconds).</param>
        /// <remarks>The default wait time could be overridden.</remarks>
        /// <param name="captureOutput">Triggers the system to capture the web page source in the output of the step after the actions. 
        /// The system will automatically do thie if there is an error or the step fails.</param>
        /// <returns>Step to add to your scenario.</returns>
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
        /// <summary>
        /// Verifies a page element matching the CSS selector for the page element is not found.
        /// </summary>
        /// <param name="waitMilliseconds">The amount of time to wait.  If not provided the system will wait the default value (2 seconds).</param>
        /// <remarks>The default wait time could be overridden.</remarks>
        /// <param name="captureOutput">Triggers the system to capture the web page source in the output of the step after the actions. 
        /// The system will automatically do thie if there is an error or the step fails.</param>
        /// <returns>Step to add to your scenario.</returns>
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