namespace xBDD.Browser
{
    using xBDD.Model;
    using xBDD.Browser;
    using OpenQA.Selenium;

    /// <summary>
    /// Provides steps for performing user actions in a browser.
    /// </summary>
    public class BrowserUser 
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

        /// <summary>
        /// Waits till the specified element condition is true.
        /// </summary>
        /// <param name="pageElement">The page element to wait on.</param>
        /// <returns>PageElementSteps object that contains methods for getting the steps for different conditions.</returns>
        public PageElementSteps WaitTill(PageElement pageElement)
        {
            return new PageElementSteps(this.browser, pageElement, "you wait till ");
        }
        /// <summary>
        /// Verifies the specified element condition is true.
        /// </summary>
        /// <param name="description">The page element description to add to the step name.</param>
        /// <param name="selector">The page element selector to use to find the page element.</param>
        /// <returns>PageElementSteps object that contains methods for getting the steps for different conditions.</returns>
        public PageElementSteps WillSee(string description, string selector)
        {
            var pageElement = new PageElement(description, selector);
            return new PageElementSteps(this.browser, pageElement, "you will see ");
        }
        /// <summary>
        /// Verifies the specified element condition is true.
        /// </summary>
        /// <param name="pageElement">The page element to wait on.</param>
        /// <returns>PageElementSteps object that contains methods for getting the steps for different conditions.</returns>
        public PageElementSteps WillSee(PageElement pageElement)
        {
            return new PageElementSteps(this.browser, pageElement, "you will see ");
        }
        /// <summary>
        /// Clicks a page element after a condition is true.
        /// </summary>
        /// <param name="pageElement">The page element to click.</param>
        /// <returns>PageElementSteps object that contains methods for getting the steps for different conditions.</returns>
        public PageElementSteps ClickWhen(PageElement pageElement)
        {
            return new PageElementSteps(this.browser, pageElement, "you click when ", true);
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
        public TextSteps EnterTheText(string text)
        {
            return new TextSteps(browser, text);
        }

        /// <summary>
        /// Sends the enter key press event to the specified page element.
        /// </summary>
        /// <param name="description">The description of the page element to add to the step name.</param>
        /// <param name="selector">The selector to use to find the page element.</param>
        /// <param name="waitTillVisibleMilliseconds">Overrides the default 2 second wait time to a value you set in milliseconds.</param>
        /// <param name="captureOutput">Tells the system to capture the page in the step output after the action. 
        /// The system will do this by default if the step fails.</param>
        /// <returns>The step you can add to your scenario.</returns>
        public Step PressTheEnterKey(string description, string selector, int waitTillVisibleMilliseconds = -1, bool captureOutput = false)
        {
            var pageElement = new PageElement(description, selector);
            return PressTheEnterKey(pageElement, waitTillVisibleMilliseconds, captureOutput);
        }
        /// <summary>
        /// Sends the enter key press event to the specified page element.
        /// </summary>
        /// <param name="pageElement">The page element to select before hitting the eneter key..</param>
        /// <param name="waitTillVisibleMilliseconds">Overrides the default 2 second wait time to a value you set in milliseconds.</param>
        /// <param name="captureOutput">Tells the system to capture the page in the step output after the action. 
        /// The system will do this by default if the step fails.</param>
        /// <returns>The step you can add to your scenario.</returns>
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
        /// <summary>
        /// Verifies you are viewing a page with the provided title.
        /// </summary>
        /// <param name="text">The title property for the page. Controls the text displayed in the browser tab.</param>
        /// <returns>Step to add to your scenario.</returns>
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