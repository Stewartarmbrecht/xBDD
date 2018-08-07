using System;
using System.Threading.Tasks;
using System.Diagnostics;
using OpenQA.Selenium;

namespace xBDD.Browser
{
    public class WebBrowser
    {
        IWebDriver driver;
        public WebBrowser()
        {
            this.driver = WebDriver.Current;
        }
        public WebBrowser(IWebDriver driver)
        {
            this.driver = driver;
        }
        public static int DefaultWait = 500;
        
        public void Load(PageLocation location)
        {
            var sw = new System.Diagnostics.Stopwatch();  
            sw.Start();
            driver.Url = location.Url;
            sw.Stop();
            System.Diagnostics.Trace.WriteLine("        Loading Page (" + sw.ElapsedMilliseconds.ToString() + "ms): " + location.Url);
        }
        
        public string GetPageSource()
        {
            
            var sw = new System.Diagnostics.Stopwatch();  
            sw.Start();
            var pageSource =  driver.PageSource;
            sw.Stop();
            System.Diagnostics.Trace.WriteLine("        GetPageSource (" + sw.ElapsedMilliseconds.ToString() + "ms)");
            return pageSource;
        }
        public void HasTitle(string title)
        {
            var sw = new System.Diagnostics.Stopwatch();  
            sw.Start();
            if(driver.Title != title)
                throw new Exception("The brower title was not '" + title + "' it was '" + driver.Title + "'");
            sw.Stop();
            System.Diagnostics.Trace.WriteLine("        HasTitle (" + sw.ElapsedMilliseconds.ToString() + "ms): " + title);
        }

        public void ElementHasText(PageElement element, string text)
        {
            var sw = new System.Diagnostics.Stopwatch();  
            sw.Start();
            IWebElement webElement = driver.FindElement(OpenQA.Selenium.By.CssSelector(element.Selector));
            if (webElement == null)
                throw new Exception("The web element (" + element.Description + " - " + element.Selector + ") was not found.");
            else
            {
                var foundText = webElement.Text;
                if(foundText.CompareTo(text) != 0)
                throw new Exception("The web element (" + element.Description + " - " + element.Selector + ") did not have text '" + text + "' it was '" + foundText + "'.");
                
            }
            sw.Stop();
            System.Diagnostics.Trace.WriteLine("        ElementHasText (" + sw.ElapsedMilliseconds.ToString() + "ms): " + text);
        }

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
                } catch(NoSuchElementException ex) {
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
                        } catch(NoSuchElementException ex) {
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
                } catch(NoSuchElementException ex) {
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
                        } catch(NoSuchElementException ex) {
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
        public Task ClickWhenVisible(PageElement element, bool throwException = true, int waitMilliseconds = -1)
        {
            return Task.Run(() =>
            {
                var sw = new System.Diagnostics.Stopwatch();  
                sw.Start();
                if (waitMilliseconds == -1)
                    waitMilliseconds = DefaultWait;
                IWebElement webElement = driver.FindElement(OpenQA.Selenium.By.CssSelector(element.Selector));
                var clicked = false;
                Stopwatch sw2 = new Stopwatch();
                sw2.Start();
                while (sw2.ElapsedMilliseconds < waitMilliseconds && clicked == false)
                {
                    if (webElement == null)
                    {
                        webElement = driver.FindElement(OpenQA.Selenium.By.CssSelector(element.Selector));
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
        public Task Click(PageElement element)
        {
            return Task.Run(() =>
            {
                var sw = new System.Diagnostics.Stopwatch();  
                sw.Start();
                IWebElement webElement = driver.FindElement(OpenQA.Selenium.By.CssSelector(element.Selector));
                webElement.Click();
                sw.Stop();
                System.Diagnostics.Trace.WriteLine("        ClickWhenVisible (" + sw.ElapsedMilliseconds.ToString() + "ms): " + element.Selector);
            });
        }
    }
}