using System;
using System.Threading.Tasks;
using System.Diagnostics;
using OpenQA.Selenium;

namespace xBDD.Browser
{
    public class WebBrowser
    {
        IWebDriver driver;
        public WebBrowser(IWebDriver driver)
        {
            this.driver = driver;
        }
        public static int DefaultWait = 500;
        
        public void Load(PageLocation location)
        {
            System.Diagnostics.Trace.TraceInformation(DateTime.Now.ToString("HH:mm:ss.fff") + " Load Start " + location.Url.ToString());
            driver.Url = location.Url;
            System.Diagnostics.Trace.TraceInformation(DateTime.Now.ToString("HH:mm:ss.fff") + " Load End " + location.Url.ToString());
        }
        
        public string GetPageSource()
        {
            
            System.Diagnostics.Trace.TraceInformation(DateTime.Now.ToString("HH:mm:ss.fff") + " GetPageSource Start");
            var pageSource =  driver.PageSource;
            System.Diagnostics.Trace.TraceInformation(DateTime.Now.ToString("HH:mm:ss.fff") + " GetPageSource End");
            return pageSource;
        }
        public void HasTitle(string title)
        {
            System.Diagnostics.Trace.TraceInformation(DateTime.Now.ToString("HH:mm:ss.fff") + " HasTitle " + title);
            if(driver.Title != title)
                throw new Exception("The brower title was not '" + title + "' it was '" + driver.Title + "'");
            System.Diagnostics.Trace.TraceInformation(DateTime.Now.ToString("HH:mm:ss.fff") + " HasTitle End");
        }

        public void ElementHasText(PageElement element, string text)
        {
            System.Diagnostics.Trace.TraceInformation(DateTime.Now.ToString("HH:mm:ss.fff") + " ElementHasText " + element.Selector);
            IWebElement webElement = driver.FindElement(By.CssSelector(element.Selector));
            if (webElement == null)
                throw new Exception("The web element (" + element.Description + " - " + element.Selector + ") was not found.");
            else
            {
                var foundText = webElement.Text;
                if(foundText.CompareTo(text) != 0)
                   throw new Exception("The web element (" + element.Description + " - " + element.Selector + ") did not have text '" + text + "' it was '" + foundText + "'.");
                
            }
            System.Diagnostics.Trace.TraceInformation(DateTime.Now.ToString("HH:mm:ss.fff") + " ElementHasText End ");
        }

        public void ElementStyleMatches(PageElement element, string styleRegEx)
        {
            System.Diagnostics.Trace.TraceInformation(DateTime.Now.ToString("HH:mm:ss.fff") + " ElementStyleMatches " + element.Selector);
            IWebElement webElement = driver.FindElement(By.CssSelector(element.Selector));
            if (webElement == null)
                throw new Exception("The web element (" + element.Description + " - " + element.Selector + ") was not found.");
            else
            {
                string styleFound = webElement.GetAttribute("style"); 
                if(!System.Text.RegularExpressions.Regex.Match(styleFound, styleRegEx).Success)
                   throw new Exception("The web element (" + element.Description + " - " + element.Selector + ") did not have a style that matched '" + styleRegEx + "' it was '" + styleFound + "'.");
            }
            System.Diagnostics.Trace.TraceInformation(DateTime.Now.ToString("HH:mm:ss.fff") + " ElementStyleMatches End");
        }

        public void ElementHasTitle(PageElement element, string title)
        {
            System.Diagnostics.Trace.TraceInformation(DateTime.Now.ToString("HH:mm:ss.fff") + " ElementHasTitle " + element.Selector);
            IWebElement webElement = driver.FindElement(By.CssSelector(element.Selector));
            if (webElement == null)
                throw new Exception("The web element (" + element.Description + " - " + element.Selector + ") was not found.");
            else
            {
                string titleFound = webElement.GetAttribute("title"); 
                if(titleFound != title)
                   throw new Exception("The web element (" + element.Description + " - " + element.Selector + ") did not have text '" + title + "' it was '" + titleFound + "'.");
            }
            System.Diagnostics.Trace.TraceInformation(DateTime.Now.ToString("HH:mm:ss.fff") + " ElementHasTitle End");
        }

        public Task WaitTillNotVisible(PageElement element, int waitMilliseconds = -1)
        {
            return Task.Run(() =>
            {
                System.Diagnostics.Trace.TraceInformation(DateTime.Now.ToString("HH:mm:ss.fff") + " WaitTillNotVisible " + element.Selector);
                if (waitMilliseconds == -1)
                    waitMilliseconds = DefaultWait;
                IWebElement webElement = driver.FindElement(By.CssSelector(element.Selector));
                if (webElement == null)
                    throw new Exception("The web element (" + element.Description + " - " + element.Selector + ") was not found.");
                var hidden = false;
                Stopwatch sw = new Stopwatch();
                sw.Start();
                while (sw.ElapsedMilliseconds < waitMilliseconds && hidden == false)
                {
                    if (!webElement.Displayed)
                        hidden = true;
                }
                if (!hidden)
                    throw new Exception("The web element (" + element.Description + " - " + element.Selector + ") was not hidden.");
                System.Diagnostics.Trace.TraceInformation(DateTime.Now.ToString("HH:mm:ss.fff") + " WaitTillNotVisible End ");
            });
        }

        public void ValidateNotExist(PageElement element)
        {
            System.Diagnostics.Trace.TraceInformation(DateTime.Now.ToString("HH:mm:ss.fff") + " ValidateNotExist " + element.Selector);
            var webElement = driver.FindElements(By.CssSelector(element.Selector));
            if (webElement.Count != 0)
                throw new Exception("The web element (" + element.Description + " - " + element.Selector + ") was found.");
            System.Diagnostics.Trace.TraceInformation(DateTime.Now.ToString("HH:mm:ss.fff") + " ValidateNotExist End");
        }

        public Task WaitTillVisible(PageElement element, int waitMilliseconds = -1)
        {
            return Task.Run(() =>
            {
                System.Diagnostics.Trace.TraceInformation(DateTime.Now.ToString("HH:mm:ss.fff") + " WaitTillVisible Start " + element.Selector);
                // System.Diagnostics.Trace.TraceInformation(DateTime.Now.ToString("HH:mm:ss.fff") + " Set ImplicitWait to 0 Start");
                // driver.Manage().Timeouts().ImplicitWait = new TimeSpan(0);
                // System.Diagnostics.Trace.TraceInformation(DateTime.Now.ToString("HH:mm:ss.fff") + " Set ImplicitWait to 0 End");

                if (waitMilliseconds == -1)
                    waitMilliseconds = DefaultWait;

                System.Diagnostics.Trace.TraceInformation(DateTime.Now.ToString("HH:mm:ss.fff") + " Find Web Element Start " + element.Selector);
                IWebElement webElement = driver.FindElement(By.CssSelector(element.Selector));
                System.Diagnostics.Trace.TraceInformation(DateTime.Now.ToString("HH:mm:ss.fff") + " Find Web Element End");

                var visible = false;
                Stopwatch sw = new Stopwatch();
                sw.Start();
                int passCount = 0;
                while (sw.ElapsedMilliseconds < waitMilliseconds && visible == false)
                {
                    ++passCount;
                    if(webElement == null)
                    {
                        System.Diagnostics.Trace.TraceInformation(DateTime.Now.ToString("HH:mm:ss.fff") + " Find Web Element Start " + element.Selector);
                        webElement = driver.FindElement(By.CssSelector(element.Selector));
                        System.Diagnostics.Trace.TraceInformation(DateTime.Now.ToString("HH:mm:ss.fff") + " Find Web Element End");
                    }
                    if(webElement != null)
                    {
                        System.Diagnostics.Trace.TraceInformation(DateTime.Now.ToString("HH:mm:ss.fff") + " Web Element Displayed Start " + element.Selector);
                        if (webElement.Displayed)
                            visible = true;
                        System.Diagnostics.Trace.TraceInformation(DateTime.Now.ToString("HH:mm:ss.fff") + " Web Element Displayed End");
                    }
                }
                System.Diagnostics.Trace.TraceInformation(DateTime.Now.ToString("HH:mm:ss.fff") + " Pass Count = " + passCount.ToString());

                if (webElement == null)
                    throw new Exception("The web element (" + element.Description + " - " + element.Selector + ") was not found.");

                if (!visible)
                    throw new Exception("The web element (" + element.Description + " - " + element.Selector + ") was not visible");
                System.Diagnostics.Trace.TraceInformation(DateTime.Now.ToString("HH:mm:ss.fff") + " WaitTillVisible End");
            });
        }
        public Task ClickWhenVisible(PageElement element, bool throwException = true, int waitMilliseconds = -1)
        {
            return Task.Run(() =>
            {
                System.Diagnostics.Trace.TraceInformation(DateTime.Now.ToString("HH:mm:ss.fff") + " ClickWhenVisible " + element.Selector);
                if (waitMilliseconds == -1)
                    waitMilliseconds = DefaultWait;
                IWebElement webElement = driver.FindElement(By.CssSelector(element.Selector));
                var clicked = false;
                Stopwatch sw = new Stopwatch();
                sw.Start();
                while (sw.ElapsedMilliseconds < waitMilliseconds && clicked == false)
                {
                    if (webElement == null)
                    {
                        webElement = driver.FindElement(By.CssSelector(element.Selector));
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
                System.Diagnostics.Trace.TraceInformation(DateTime.Now.ToString("HH:mm:ss.fff") + " ClickWhenVisible End");
            });
        }
    }
}