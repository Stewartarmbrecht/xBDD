using System.Diagnostics;
using System.Threading.Tasks;
using OpenQA.Selenium;
namespace xBDD.Browser

{
    public static class Page
    {
        public static Task<bool> WaitTillNotVisible(IWebElement webElement, int waitMilliseconds)
        {
            return Task<bool>.Run(() =>
            {
                var result = false;
                Stopwatch sw = new Stopwatch();
                sw.Start();
                while (sw.ElapsedMilliseconds < waitMilliseconds && result == false)
                {
                    if (!webElement.Displayed)
                        result = true;
                }
                return result;
            });
        }
        public static Task<bool> WaitTillVisible(IWebElement webElement, int waitMilliseconds)
        {
            return Task<bool>.Run(() =>
            {
                var result = false;
                Stopwatch sw = new Stopwatch();
                sw.Start();
                while (sw.ElapsedMilliseconds < waitMilliseconds && result == false)
                {
                    if (webElement.Displayed)
                        result = true;
                }
                return result;
            });
        }
    }
}