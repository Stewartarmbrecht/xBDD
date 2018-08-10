using xBDD.Model;

namespace xBDD.Browser
{
    using System.Collections.Generic;
    using OpenQA.Selenium;

    /// <summary>
    /// Contains methods to call to finalize
    /// a step for entering text.
    /// </summary>    
    public class TextActions
    {
        private WebBrowser browser;

        private List<string> text;
        private bool hitEnter;

        internal TextActions(WebBrowser browser, string text)
        {
            this.browser = browser;
            this.text = new List<string>();
            this.text.Add(text);
        }

        /// <summary>
        /// Adds pressing the enter key to the text command.
        /// </summary>
        /// <returns>The TextActions for a fluent interface.</returns>
        public TextActions AndHitEnter()
        {
            this.text.Add(Keys.Enter);
            return this;
        }

        /// <summary>
        /// Returns a step that enters text into the specified page element.
        /// </summary>
        /// <param name="description">The description of the page element to add to the step name.</param>
        /// <param name="selector">The select to use to find the page element.  xBDD will try for up to 2 seconds to find the visible element.</param>
        /// <param name="waitTillVisibleMilliseconds">Overrides the default 2 second wait time to a value you set in milliseconds.</param>
        /// <param name="captureOutput"></param>
        /// <returns></returns>
        public Step In(string description, string selector, int waitTillVisibleMilliseconds = -1, bool captureOutput = false)
        {
            var pageElement = new PageElement(description, selector);
            return this.In(pageElement, waitTillVisibleMilliseconds, captureOutput);
        }
        /// <summary>
        /// Returns a step that enters text into the specified page element.
        /// </summary>
        /// <param name="pageElement">The page element with the description and selector to use to find the element and set the step name.</param>
        /// <param name="waitTillVisibleMilliseconds">Overrides the default 2 second wait time to a value you set in milliseconds.</param>
        /// <param name="captureOutput"></param>
        /// <returns></returns>
        public Step In(PageElement pageElement, int waitTillVisibleMilliseconds = -1, bool captureOutput = false)
        {
            return xB.CreateAsyncStep(
                $"you enter the text {this.text} into the {pageElement.Description} input",
                async (s) => {
                    try {
                        await this.browser.WaitTillVisible(pageElement, waitTillVisibleMilliseconds);
                        text.ForEach(entry => {
                            this.browser.SendKeys(pageElement, entry);
                        });
                        if(s.Outcome == Outcome.Failed || captureOutput)
                        {
                            s.Output = this.browser.GetPageSource();
                            s.OutputFormat = TextFormat.htmlpreview;
                        }
                    } catch (System.Exception) {
                        s.Output = this.browser.GetPageSource();
                        s.OutputFormat = TextFormat.htmlpreview;
                        throw;
                    }
                });
        }
    }
}