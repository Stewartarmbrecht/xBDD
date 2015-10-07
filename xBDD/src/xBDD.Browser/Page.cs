using System;
using System.Diagnostics;
using System.Threading.Tasks;
using OpenQA.Selenium;
namespace xBDD.Browser

{
    public static class Page
    {
        public static int DefaultWait = 500;
        public static Task WaitTillNotVisible(string webElementName, IWebElement webElement, int waitMilliseconds = -1)
        {
            if(waitMilliseconds == -1)
                waitMilliseconds = DefaultWait;
            if(webElement == null)
                throw new Exception("The web element (" + webElementName + ") was not found.");
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
                if(!hidden)
                    throw new Exception("The web element (" + webElementName + ") was not hidden.");
            });
        }
        public static Task WaitTillVisible(string webElementName, IWebElement webElement, int waitMilliseconds = -1)
        {
            return Task.Run(() =>
            {
                if(waitMilliseconds == -1)
                    waitMilliseconds = DefaultWait;
                if(webElement == null)
                    throw new Exception("The web element (" + webElementName + ") was not found.");
    
                var visible = false;
                Stopwatch sw = new Stopwatch();
                sw.Start();
                while (sw.ElapsedMilliseconds < waitMilliseconds && visible == false)
                {
                    if (webElement.Displayed)
                    {
                        visible = true;
                    }
                }
                if(!visible)
                    throw new Exception("The web element ("+webElementName+") was not visible");
            });
        }
        public static Task ClickWhenVisible(string webElementName, IWebElement webElement, int waitMilliseconds = -1)
        {
            if(waitMilliseconds == -1)
                waitMilliseconds = DefaultWait;
            if(webElement == null)
                throw new Exception("The web element (" + webElementName + ") was not found.");
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
                if(!clicked)
                    throw new Exception("The web element ("+webElementName+") was not visible and was not clicked");
            });
        }
    }
}