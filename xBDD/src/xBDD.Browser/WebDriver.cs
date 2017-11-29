using System;
using OpenQA.Selenium;
using OpenQA.Selenium.PhantomJS;

namespace xBDD.Browser
{
	public class WebDriver
	{
		static object locker = new object();
		static IWebDriver webDriver;
		public static IWebDriver Current 
		{
			get
			{
				lock(locker)
				{
					if(webDriver == null)
					{
						var sw = new System.Diagnostics.Stopwatch();  
						sw.Start();
						webDriver = new PhantomJSDriver($".{System.IO.Path.DirectorySeparatorChar}");
						sw.Stop();
						System.Diagnostics.Trace.WriteLine("        Created PhantomJSDriver (" + sw.ElapsedMilliseconds.ToString() + "ms)");
					}
					return webDriver;
				}
			}
		} 
		
		public static void Close()
		{
			if(webDriver != null)
			{
						var sw = new System.Diagnostics.Stopwatch();
						sw.Start();
						webDriver.Close();
						webDriver.Quit();
						webDriver.Dispose();
						sw.Stop();
						System.Diagnostics.Trace.WriteLine("        Closed PhantonJSDriver (" + sw.ElapsedMilliseconds.ToString() + "ms)");
			}
		}
	}
}