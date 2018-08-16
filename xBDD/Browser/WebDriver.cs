using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace xBDD.Browser
{
	/// <summary>
	/// Singleton for holding a reference to the current web dirver.
	/// </summary>
	/// <remarks>
	/// Launching an instance of a browser through the web driver is expensive and can take up to 2 seconds.
	/// For that reason we reuse the same web browser across tests.  This means your tests can not run concurrently.
	/// To achieve test concurrency run multiple test runs at the same time by passing different filters into the 
	/// same test project.
	/// </remarks>
	public class WebDriver
	{
		static object locker = new object();
		static IWebDriver webDriver;
		/// <summary>
		/// The current web driver used by all tests.
		/// </summary>
		/// <value></value>
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
						ChromeOptions options = new ChromeOptions();
						List<string> chromeArgs = new List<string>();
						var userArgs = Environment.GetEnvironmentVariable("xBDD:Browser:ChromeArgs");
						if(userArgs != null){
							chromeArgs.AddRange(userArgs.Split(';'));
						} else {
							var windowSize = Environment.GetEnvironmentVariable("xBDD:Browser:WindowSize");
							if(windowSize != null) {
								chromeArgs.Add($"--window-size={windowSize}");
							} else {
								chromeArgs.Add("--window-size=1024,768");
							}
							chromeArgs.Add("--allow-running-insecure-content");
							chromeArgs.Add("--disable-gpu");
							if(!WebBrowser.WatchBrowser) {
								chromeArgs.Add("--headless");
							}
						}
						options.AddArguments(chromeArgs.ToArray());
						webDriver = new ChromeDriver($".{System.IO.Path.DirectorySeparatorChar}", options);
						sw.Stop();
						
						System.Diagnostics.Trace.WriteLine("        Created ChromeDriver (" + sw.ElapsedMilliseconds.ToString() + "ms)");
					}
					return webDriver;
				}
			}
		} 
		/// <summary>
		/// Closes the web driver.  
		/// BE SURE to use this method in the AssmblyCleanup method for the test project.
		/// </summary>
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
				System.Diagnostics.Trace.WriteLine("        Closed ChromeDriver (" + sw.ElapsedMilliseconds.ToString() + "ms)");
			}
		}
	}
}