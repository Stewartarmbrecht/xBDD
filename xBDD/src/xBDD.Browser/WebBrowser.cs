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
            driver.Url = location.Url;
        }
        
        public string GetPageSource()
        {
            return driver.PageSource;
        }
        public void HasTitle(string title)
        {
            if(driver.Title != title)
                throw new Exception("The brower title was not '" + title + "' it was '" + driver.Title + "'");
        }

        public void ElementHasText(PageElement element, string text)
        {
            IWebElement webElement = driver.FindElement(By.CssSelector(element.Selector));
            if (webElement == null)
                throw new Exception("The web element (" + element.Description + " - " + element.Selector + ") was not found.");
            else
            {
                var foundText = webElement.Text;
                if(foundText.CompareTo(text) != 0)
                   throw new Exception("The web element (" + element.Description + " - " + element.Selector + ") did not have text '" + text + "' it was '" + foundText + "'.");
                
            }
        }

        public void ElementStyleMatches(PageElement element, string styleRegEx)
        {
            IWebElement webElement = driver.FindElement(By.CssSelector(element.Selector));
            if (webElement == null)
                throw new Exception("The web element (" + element.Description + " - " + element.Selector + ") was not found.");
            else
            {
                string styleFound = webElement.GetAttribute("style"); 
                if(!System.Text.RegularExpressions.Regex.Match(styleFound, styleRegEx).Success)
                   throw new Exception("The web element (" + element.Description + " - " + element.Selector + ") did not have a style that matched '" + styleRegEx + "' it was '" + styleFound + "'.");
            }
        }

        public void ElementHasTitle(PageElement element, string title)
        {
            IWebElement webElement = driver.FindElement(By.CssSelector(element.Selector));
            if (webElement == null)
                throw new Exception("The web element (" + element.Description + " - " + element.Selector + ") was not found.");
            else
            {
                string titleFound = webElement.GetAttribute("title"); 
                if(titleFound != title)
                   throw new Exception("The web element (" + element.Description + " - " + element.Selector + ") did not have text '" + title + "' it was '" + titleFound + "'.");
            }
        }

        public Task WaitTillNotVisible(PageElement element, int waitMilliseconds = -1)
        {
            if (waitMilliseconds == -1)
                waitMilliseconds = DefaultWait;
            IWebElement webElement = driver.FindElement(By.CssSelector(element.Selector));
            if (webElement == null)
                throw new Exception("The web element (" + element.Description + " - " + element.Selector + ") was not found.");
            return Task.Run(() =>
            {
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
            });
        }

        public void ValidateNotExist(PageElement element)
        {
            var webElement = driver.FindElements(By.CssSelector(element.Selector));
            if (webElement.Count != 0)
                throw new Exception("The web element (" + element.Description + " - " + element.Selector + ") was found.");
        }

        public Task WaitTillVisible(PageElement element, int waitMilliseconds = -1)
        {
            return Task.Run(() =>
            {
                if (waitMilliseconds == -1)
                    waitMilliseconds = DefaultWait;
                IWebElement webElement = driver.FindElement(By.CssSelector(element.Selector));
                var visible = false;
                Stopwatch sw = new Stopwatch();
                sw.Start();
                while (sw.ElapsedMilliseconds < waitMilliseconds && visible == false)
                {
                    if(webElement == null)
                        webElement = driver.FindElement(By.CssSelector(element.Selector));
                    if(webElement != null)
                        if (webElement.Displayed)
                            visible = true;
                }
                if (webElement == null)
                    throw new Exception("The web element (" + element.Description + " - " + element.Selector + ") was not found.");

                if (!visible)
                    throw new Exception("The web element (" + element.Description + " - " + element.Selector + ") was not visible");
            });
        }
        public Task ClickWhenVisible(PageElement element, bool throwException = true, int waitMilliseconds = -1)
        {
            if (waitMilliseconds == -1)
                waitMilliseconds = DefaultWait;
            return Task.Run(() =>
            {
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
            });
        }
    }
}