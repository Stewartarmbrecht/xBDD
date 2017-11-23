using System;
using OpenQA.Selenium;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Chrome;
namespace xBDD.Reporting.Test

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
			            System.Diagnostics.Trace.TraceInformation(DateTime.Now.ToString("HH:mm:ss.fff") + " Start Load PhantomJSDriver");
						//webDriver = new ChromeDriver(".\\");

						webDriver = new PhantomJSDriver(".\\");
			            System.Diagnostics.Trace.TraceInformation(DateTime.Now.ToString("HH:mm:ss.fff") + " End Load PhantomJSDriver");
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