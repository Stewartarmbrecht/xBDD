using System;
using System.Collections.Generic;
using OpenQA.Selenium;
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
							var watch = Environment.GetEnvironmentVariable("xBDD:Browser:Watch");
							if(!(watch != null && Boolean.Parse(watch))) {
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