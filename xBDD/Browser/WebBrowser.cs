namespace xBDD.Browser
{
    using System;
    using System.Threading.Tasks;
    using System.Diagnostics;
    using OpenQA.Selenium;

    /// <summary>
    /// Provides methods for interacting with a web browser.
    /// </summary>
    public class WebBrowser
    {
        /// <summary>
        /// Set to true if you would like to watch the browser during automation.
        /// </summary>
        public static bool WatchBrowser = false;
        IWebDriver driver;
        /// <summary>
        /// Creates a new web browser and web driver 
        /// if it is has not been created yet.
        /// </summary>
        public WebBrowser()
        {
            this.driver = WebDriver.Current;
        }
        /// <summary>
        /// Creates a new web browser with the web driver 
        /// you provide.
        /// </summary>
        public WebBrowser(IWebDriver driver)
        {
            this.driver = driver;
        }
        /// <summary>
        /// Default time to wait for elements to match
        /// the specified condition when using browser actions.
        /// </summary>
        public static int DefaultWait = 2000;
        /// <summary>
        /// Loads the specified page location into the web browser.
        /// </summary>
        /// <param name="location">The description and url to load.</param>
        public void Load(PageLocation location)
        {
            var sw = new System.Diagnostics.Stopwatch();  
            sw.Start();
            driver.Url = location.Url;
            sw.Stop();
            System.Diagnostics.Trace.WriteLine("        Loading Page (" + sw.ElapsedMilliseconds.ToString() + "ms): " + location.Url);
        }
        /// <summary>
        /// Gets the source of the loaded page in the browser.
        /// </summary>
        /// <returns>Source of the loaded page in the browser</returns>
        public string GetPageSource()
        {
            
            var sw = new System.Diagnostics.Stopwatch();  
            sw.Start();
            var pageSource =  driver.PageSource;
            sw.Stop();
            System.Diagnostics.Trace.WriteLine("        GetPageSource (" + sw.ElapsedMilliseconds.ToString() + "ms)");
            return pageSource;
        }
        /// <summary>
        /// Verifies whether the loaded page in the web browser
        /// has a title matching the string provided.
        /// </summary>
        /// <param name="title">Title to match.</param>
        public void HasTitle(string title)
        {
            var sw = new System.Diagnostics.Stopwatch();  
            sw.Start();
            if(driver.Title != title)
                throw new Exception("The brower title was not '" + title + "' it was '" + driver.Title + "'");
            sw.Stop();
            System.Diagnostics.Trace.WriteLine("        HasTitle (" + sw.ElapsedMilliseconds.ToString() + "ms): " + title);
        }
        /// <summary>
        /// Verifies whether the provided element has the specified text.
        /// </summary>
        /// <param name="element">Element to check.</param>
        /// <param name="text">Text the element should contain.</param>
        public void ElementHasText(PageElement element, string text)
        {
            var sw = new System.Diagnostics.Stopwatch();  
            sw.Start();
            IWebElement webElement = driver.FindElement(OpenQA.Selenium.By.CssSelector(element.Selector));
            if (webElement == null)
                throw new Exception($"The web element ({element.Description} - {element.Selector}) was not found.");
            else
            {
                var foundText = webElement.Text;
                if(foundText.CompareTo(text) != 0)
                throw new Exception($"The web element ({element.Description} - {element.Selector}) did not have text '{text}' it was '{foundText}'.");
                
            }
            sw.Stop();
            System.Diagnostics.Trace.WriteLine($"        ElementHasText ({sw.ElapsedMilliseconds.ToString()}ms): {text}");
        }
        /// <summary>
        /// Verifies the style attribute of the provided element
        /// matches the regular expression provided.
        /// </summary>
        /// <param name="element">The element to check.</param>
        /// <param name="styleRegEx">The regular expression to use.</param>
        public void ElementStyleMatches(PageElement element, string styleRegEx)
        {
            var sw = new System.Diagnostics.Stopwatch();  
            sw.Start();
            IWebElement webElement = driver.FindElement(OpenQA.Selenium.By.CssSelector(element.Selector));
            if (webElement == null)
                throw new Exception("The web element (" + element.Description + " - " + element.Selector + ") was not found.");
            else
            {
                string styleFound = webElement.GetAttribute("style"); 
                if(!System.Text.RegularExpressions.Regex.Match(styleFound, styleRegEx).Success)
                   throw new Exception("The web element (" + element.Description + " - " + element.Selector + ") did not have a style that matched '" + styleRegEx + "' it was '" + styleFound + "'.");
            }
            sw.Stop();
            System.Diagnostics.Trace.WriteLine("        ElementStyleMatches (" + sw.ElapsedMilliseconds.ToString() + "ms): " + styleRegEx);
        }
        /// <summary>
        /// Verifies the provided page element has a titla attribute
        /// matching the value provided.
        /// </summary>
        /// <param name="element">The element to check.</param>
        /// <param name="title">The value the element should have for the title attribute.</param>
        public void ElementHasTitle(PageElement element, string title)
        {
            var sw = new System.Diagnostics.Stopwatch();  
            sw.Start();
            IWebElement webElement = driver.FindElement(OpenQA.Selenium.By.CssSelector(element.Selector));
            if (webElement == null)
                throw new Exception("The web element (" + element.Description + " - " + element.Selector + ") was not found.");
            else
            {
                string titleFound = webElement.GetAttribute("title"); 
                if(titleFound != title)
                   throw new Exception("The web element (" + element.Description + " - " + element.Selector + ") did not have text '" + title + "' it was '" + titleFound + "'.");
            }
            sw.Stop();
            System.Diagnostics.Trace.WriteLine("        ElementHasTitle (" + sw.ElapsedMilliseconds.ToString() + "ms): " + title);
        }
        /// <summary>
        /// Waits until the provided element is not visible.
        /// </summary>
        /// <param name="element">The element to check</param>
        /// <param name="waitMilliseconds">The amount of time to wait.  If not provided the system will wait the default value (2 seconds).</param>
        /// <remarks>The default wait time could be overridden.</remarks>
        /// <returns>Task for executing the operation.</returns>
        public Task WaitTillNotVisible(PageElement element, int waitMilliseconds = -1)
        {
            return Task.Run(() =>
            {
                var sw = new System.Diagnostics.Stopwatch();  
                sw.Start();
                if (waitMilliseconds == -1)
                    waitMilliseconds = DefaultWait;
                IWebElement webElement = null;
                try {
                    webElement = driver.FindElement(OpenQA.Selenium.By.CssSelector(element.Selector));
                } catch(NoSuchElementException) {
                }
                var hidden = false;
                Stopwatch sw2 = new Stopwatch();
                sw2.Start();
                while (sw2.ElapsedMilliseconds < waitMilliseconds && hidden == false)
                {
                    if (webElement == null)
                    {
                        try {
                            webElement = driver.FindElement(OpenQA.Selenium.By.CssSelector(element.Selector));
                        } catch(NoSuchElementException) {
                        }
                    }
                    if (webElement != null && !webElement.Displayed)
                        hidden = true;
                }
                if (!hidden)
                    throw new Exception("The web element (" + element.Description + " - " + element.Selector + ") was not hidden.");
                sw.Stop();
                System.Diagnostics.Trace.WriteLine("        WaitTillNotVisible (" + sw.ElapsedMilliseconds.ToString() + "ms): " + element.Selector);
            });
        }

        /// <summary>
        /// Validates no page element exists for the selector provided.
        /// </summary>
        /// <param name="element">The element to check</param>
        public void ValidateNotExist(PageElement element)
        {
            var sw = new System.Diagnostics.Stopwatch();  
            sw.Start();
            var webElement = driver.FindElements(OpenQA.Selenium.By.CssSelector(element.Selector));
            if (webElement.Count != 0)
                throw new Exception("The web element (" + element.Description + " - " + element.Selector + ") was found.");
            sw.Stop();
            System.Diagnostics.Trace.WriteLine("        ValidateNotExist (" + sw.ElapsedMilliseconds.ToString() + "ms): " + element.Selector);
        }

        /// <summary>
        /// Waits until the provided element is visible.
        /// </summary>
        /// <param name="element">The element to check</param>
        /// <param name="waitMilliseconds">The amount of time to wait.  If not provided the system will wait the default value (2 seconds).</param>
        /// <remarks>The default wait time could be overridden.</remarks>
        /// <returns>Task for executing the operation.</returns>
        public Task WaitTillVisible(PageElement element, int waitMilliseconds = -1)
        {
            return Task.Run(() =>
            {
                var sw = new System.Diagnostics.Stopwatch();  
                sw.Start();
                if (waitMilliseconds == -1)
                    waitMilliseconds = DefaultWait;

                IWebElement webElement = null;
                try {
                    webElement = driver.FindElement(OpenQA.Selenium.By.CssSelector(element.Selector));
                } catch(NoSuchElementException) {
                }

                var visible = false;
                Stopwatch sw2 = new Stopwatch();
                sw2.Start();
                int passCount = 0;
                while (sw2.ElapsedMilliseconds < waitMilliseconds && visible == false)
                {
                    ++passCount;
                    if(webElement == null)
                    {
                        try {
                            webElement = driver.FindElement(OpenQA.Selenium.By.CssSelector(element.Selector));
                        } catch(NoSuchElementException) {
                        }
                    }
                    if(webElement != null)
                    {
                        if (webElement.Displayed)
                            visible = true;
                    }
                }

                if (webElement == null)
                    throw new Exception("The web element (" + element.Description + " - " + element.Selector + ") was not found.");

                if (!visible)
                    throw new Exception("The web element (" + element.Description + " - " + element.Selector + ") was not visible");
                sw.Stop();
                System.Diagnostics.Trace.WriteLine("        WaitTillVisible (" + sw.ElapsedMilliseconds.ToString() + "ms): " + element.Selector);
            });
        }

        /// <summary>
        /// Clicks a page element once it is visible.
        /// </summary>
        /// <param name="element">The element to click</param>
        /// <param name="throwException">Tells the framework to throw an exception if the element is not found or visible.</param>
        /// <param name="waitMilliseconds">The amount of time to wait.  If not provided the system will wait the default value (2 seconds).</param>
        /// <remarks>The default wait time could be overridden.</remarks>
        /// <returns>Task for executing the operation.</returns>
        public Task ClickWhenVisible(PageElement element, bool throwException = true, int waitMilliseconds = -1)
        {
            return Task.Run(() =>
            {
                var sw = new System.Diagnostics.Stopwatch();  
                sw.Start();
                if (waitMilliseconds == -1)
                    waitMilliseconds = DefaultWait;
                IWebElement webElement = null;
                try {
                    webElement = driver.FindElement(OpenQA.Selenium.By.CssSelector(element.Selector));
                } catch(NoSuchElementException) { }
                var clicked = false;
                Stopwatch sw2 = new Stopwatch();
                sw2.Start();
                while (sw2.ElapsedMilliseconds < waitMilliseconds && clicked == false)
                {
                    if (webElement == null)
                    {
                        try {
                            webElement = driver.FindElement(OpenQA.Selenium.By.CssSelector(element.Selector));
                        } catch(NoSuchElementException) {}
                    }
                    if(webElement != null)
                    {
                        if (webElement.Displayed)
                        {
                            webElement.Click();
                            clicked = true;
                        }
                    }
                }
                if(throwException)
                {
                    if (webElement == null)
                        throw new Exception("The web element (" + element.Description + " - " + element.Selector + ") was not found.");
    
                    if (!clicked)
                        throw new Exception("The web element (" + element.Description + " - " + element.Selector + ") was not visible and was not clicked");
                }
                sw.Stop();
                System.Diagnostics.Trace.WriteLine("        ClickWhenVisible (" + sw.ElapsedMilliseconds.ToString() + "ms): " + element.Selector);
            });
        }
        /// <summary>
        /// Clicks the page element you provide.
        /// </summary>
        /// <param name="element">Page element to click.</param>
        public void Click(PageElement element)
        {
            var sw = new System.Diagnostics.Stopwatch();  
            sw.Start();
            IWebElement webElement = driver.FindElement(OpenQA.Selenium.By.CssSelector(element.Selector));
            webElement.Click();
            sw.Stop();
            System.Diagnostics.Trace.WriteLine("        Click (" + sw.ElapsedMilliseconds.ToString() + "ms): " + element.Selector);
        }
        /// <summary>
        /// Sends keys (enters text) to the provided page element
        /// using the text you provide.
        /// </summary>
        /// <param name="element">The element you want to send the keys to.</param>
        /// <param name="text">The text you want to send.</param>
        public void SendKeys(PageElement element, string text)
        {
            var sw = new System.Diagnostics.Stopwatch();  
            sw.Start();
            IWebElement webElement = driver.FindElement(OpenQA.Selenium.By.CssSelector(element.Selector));
            webElement.SendKeys(text);
            sw.Stop();
            System.Diagnostics.Trace.WriteLine($"        SendKeys '{text}' ({sw.ElapsedMilliseconds.ToString()}ms): {element.Selector}");
        }
    }
}