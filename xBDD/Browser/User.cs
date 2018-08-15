using xBDD.Model;
using xBDD.Browser;
using OpenQA.Selenium;

namespace xBDD.Browser
{
    public class User 
    {
        private WebBrowser browserHolder;
        private WebBrowser browser { 
            get {
                if(browserHolder == null)
                    browserHolder = new WebBrowser(WebDriver.Current);
                return browserHolder;
            }
        }

        /// <summary>
        /// Creates a step that navigates to a url using the
        /// chrome driver.
        /// </summary>
        /// <param name="description">The text to display for the step.</param>
        /// <param name="url">The url to load in the browser.</param>
        /// <returns>xBDD Step to add to a scneario.</returns>
        public Step NavigateTo(string description, string url)
        {
            var pageLocation = new PageLocation(description, url);
            return NavigateTo(pageLocation);
        }

        /// <summary>
        /// Navigates the browser the location specified.
        /// </summary>
        /// <param name="pageLocation">The location to load into the browser.</param>
        /// <returns>Step to add to the scenario.</returns>
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

        /// <summary>
        /// Simulates a user waiting.
        /// </summary>
        /// <param name="milliseconds">The number of milliseconds the user should wait.</param>
        /// <returns>Step to add to the scenario.</returns>
        public Step Wait(int milliseconds)
        {
            var step = xB.CreateStep(
                $"you wait {milliseconds} milliseconds",
                (s) => {
                    System.Threading.Thread.Sleep(milliseconds);
                    return;
                });
            return step;
        }

        public PageElementConditions WaitTill(PageElement pageElement)
        {
            return new PageElementConditions(this.browser, pageElement, "you wait till ");
        }
        public PageElementConditions WillSee(string description, string selector)
        {
            var pageElement = new PageElement(description, selector);
            return new PageElementConditions(this.browser, pageElement, "you will see ");
        }
        public PageElementConditions WillSee(PageElement pageElement)
        {
            return new PageElementConditions(this.browser, pageElement, "you will see ");
        }
        public PageElementConditions ClickWhen(PageElement pageElement)
        {
            return new PageElementConditions(this.browser, pageElement, "you click when ", true);
        }

        /// <summary>
        /// Clicks on the element you select (by the selector)
        /// once it is visible. By default it will try to find
        /// the visible element up to 2 seconds.
        /// </summary>
        /// <param name="description">The text to display for the step.</param>
        /// <param name="selector">The CSS selector to use to find the step.</param>
        /// <param name="waitTillVisibleMilliseconds">Overrides the default 2 second wait time to the milliseconds you specify.</param>
        /// <returns>The step to add to the xBDD scenario.</returns>
        public Step Click(string description, string selector, int waitTillVisibleMilliseconds = -1)
        {
            var pageElement = new PageElement(description, selector);
            return Click(pageElement);
        }
        /// <summary>
        /// Clicks on the page element you provide
        /// once it is visible. By default it will try to find
        /// the visible element up to 2 seconds.
        /// </summary>
        /// <param name="pageElement">The page element to click.</param>
        /// <param name="waitTillVisibleMilliseconds">Overrides the default 2 second wait time to the milliseconds you specify.</param>
        /// <returns>The step to add to the xBDD scenario.</returns>
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
        /// <summary>
        /// Clicks on the element you select (by the selector)
        /// once it is visible. By default it will try to find
        /// the visible element up to 2 seconds.
        /// </summary>
        /// <param name="text">The text to enter.</param>
        /// <returns>The step to add to the xBDD scenario.</returns>
        public TextActions EnterTheText(string text)
        {
            return new TextActions(browser, text);
        }

        public Step PressTheEnterKey(string description, string selector, int waitTillVisibleMilliseconds = -1, bool captureOutput = false)
        {
            var pageElement = new PageElement(description, selector);
            return PressTheEnterKey(pageElement, waitTillVisibleMilliseconds, captureOutput);
        }
        public Step PressTheEnterKey(PageElement pageElement, int waitTillVisibleMilliseconds = -1, bool captureOutput = false)
        {
            return xB.CreateAsyncStep(
                $"you press the enter key with the focus on the {pageElement.Description}",
                async (s) => {
                    try {
                        await this.browser.WaitTillVisible(pageElement, waitTillVisibleMilliseconds);
                        this.browser.SendKeys(pageElement, Keys.Enter);
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