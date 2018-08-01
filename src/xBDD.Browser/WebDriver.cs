using System;
using OpenQA.Selenium;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Chrome;

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
						// var service = PhantomJSDriverService.CreateDefaultService($".{System.IO.Path.DirectorySeparatorChar}");
						// service.SuppressInitialDiagnosticInformation = true;
						// service.LoadImages = false;
						// service.DiskCache = true;
						// service.LocalStoragePath = $".{System.IO.Path.DirectorySeparatorChar}";
						// service.LocalStorageQuota = 1024000;
						// var options = new PhantomJSOptions();
						// service.AddArgument("--local-to-remote-url-access true");
						// service.AddArgument("--disk-cache true");
						// options.AddAdditionalCapability("takesScreenshot", false);
						// options.AddAdditionalCapability("applicationCacheEnabled", true);

						// options.AddAdditionalCapability("browserConnectionEnabled", true);
						// options.AddAdditionalCapability("webStorageEnabled", true);
						
						// options.PageLoadStrategy = PageLoadStrategy.None;
						
						// webDriver = new PhantomJSDriver(service, options);
						ChromeOptions options = new ChromeOptions();
						options.AddArguments(new string[] {"--start-maximized","--allow-running-insecure-content","--disable-gpu","--headless"});
						System.Threading.Thread.Sleep(500);
						webDriver = new ChromeDriver($".{System.IO.Path.DirectorySeparatorChar}", options);
						System.Threading.Thread.Sleep(500);
						sw.Stop();
						
						System.Diagnostics.Trace.WriteLine("        Created ChromeDriver (" + sw.ElapsedMilliseconds.ToString() + "ms)");
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
				webDriver.Quit();
				sw.Stop();
				System.Diagnostics.Trace.WriteLine("        Closed ChromeDriver (" + sw.ElapsedMilliseconds.ToString() + "ms)");
			}
		}
	}
}