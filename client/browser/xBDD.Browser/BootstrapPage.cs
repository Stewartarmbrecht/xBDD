using System;
using System.Diagnostics;
using System.Threading.Tasks;
using OpenQA.Selenium;
namespace xBDD.Browser

{
    public static class BootstrapPage
    {
        public static int DefaultWait = 500;
        public static Task WaitTillCollapsed(string webElementName, IWebElement webElement, int waitMilliseconds = -1)
        {
            if(waitMilliseconds == -1)
                waitMilliseconds = DefaultWait;
            if(webElement == null)
                throw new Exception("The web element (" + webElementName + ") was not collapsed.");
            return Task.Run(() =>
            {
                var hidden = false;
                Stopwatch sw = new Stopwatch();
                sw.Start();
                while (sw.ElapsedMilliseconds < waitMilliseconds && hidden == false)
                {
                    var className = webElement.GetAttribute("class"); 
                    if (className.Contains("collapse") && !className.Contains("collapse in"))
                        hidden = true;
                }
                if(!hidden)
                    throw new Exception("The web element (" + webElementName + ") was not hidden.");
            });
        }
        public static Task WaitTillExpanded(string webElementName, IWebElement webElement, int waitMilliseconds = -1)
        {
            if(waitMilliseconds == -1)
                waitMilliseconds = DefaultWait;
            if(webElement == null)
                throw new Exception("The web element (" + webElementName + ") was not expanded.");
            return Task.Run(() =>
            {
                var visible = false;
                Stopwatch sw = new Stopwatch();
                sw.Start();
                while (sw.ElapsedMilliseconds < waitMilliseconds && visible == false)
                {
                    if (webElement.GetAttribute("class").Contains("collapse in"))
                        visible = true;
                }
                if(!visible)
                    throw new Exception("The web element ("+webElementName+") was not expanded");
            });
        }
    }
}