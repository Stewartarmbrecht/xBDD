using System;
using OpenQA.Selenium;
using OpenQA.Selenium.PhantomJS;
namespace xBDD.Reporting.Test

{
	public class Browser
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
						webDriver = new PhantomJSDriver();
					}
					return webDriver;
				}
			}
		} 
		
		public static void Close()
		{
			if(webDriver != null)
			{
				Console.WriteLine("Shutting down PhantomJSDriver.");
				webDriver.Close();
				webDriver.Quit();
				webDriver.Dispose();
			}
		}
	}
}