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

        public Task WaitTillNotVisible(PageElement element, int waitMilliseconds = -1)
        {
            if (waitMilliseconds == -1)
                waitMilliseconds = DefaultWait;
            IWebElement webElement = driver.FindElement(By.CssSelector(element.Selector));
            if (webElement == null)
                throw new Exception("The web element (" + element.Description + ") was not found.");
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
                    throw new Exception("The web element (" + element.Description + ") was not hidden.");
            });
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
                    throw new Exception("The web element (" + element.Description + ") was not found.");

                if (!visible)
                    throw new Exception("The web element (" + element.Description + ") was not visible");
            });
        }
        public Task ClickWhenVisible(PageElement element, int waitMilliseconds = -1)
        {
            if (waitMilliseconds == -1)
                waitMilliseconds = DefaultWait;
                IWebElement webElement = driver.FindElement(By.CssSelector(element.Selector));
            if (webElement == null)
                throw new Exception("The web element (" + element.Description + ") was not found.");
            return Task.Run(() =>
            {
                var clicked = false;
                Stopwatch sw = new Stopwatch();
                sw.Start();
                while (sw.ElapsedMilliseconds < waitMilliseconds && clicked == false)
                {
                    if (webElement.Displayed)
                    {
                        webElement.Click();
                        clicked = true;
                    }
                }
                if (!clicked)
                    throw new Exception("The web element (" + element.Description + ") was not visible and was not clicked");
            });
        }
    }
}