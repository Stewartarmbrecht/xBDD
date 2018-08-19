namespace MySample.Features
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
    using xBDD;
    using System.IO;
    using System.Threading.Tasks;

    public static class TestConfiguration
    {
        private static IConfigurationRoot configHolder;
        private static IConfigurationRoot config 
        {
            get 
            {
                if(configHolder == null)
                {
                    ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
                    configurationBuilder
                        .AddJsonFile("Config.json",true)
                        .AddEnvironmentVariables(); // Bool indicates file is optional

                    configHolder = configurationBuilder.Build();
                }
                return configHolder;
            }
        }
        public static bool FailuresOnly 
        {
            get 
            {
                var value = false;
                bool.TryParse(config["xBDD:HtmlReport:FailuresOnly"], out value);
                return value;
            }
        }
        public static string TestRunName
        {
            get 
            {
                return config["xBDD:TestRunName"];
            }
        }
        public static bool WatchBrowswer
        {
            get 
            {
                var value = false;
                bool.TryParse(config["xBDD:Browser:Watch"], out value);
                return value;
            }
        }
        public static string RemoveFromAreaNameStart
        {
            get 
            {
                return config["xBDD:HtmlReport:RemoveFromAreaNameStart"];
            }
        }
        public static string HtmlReportFileName
        {
            get 
            {
                return config["xBDD:HtmlReport:FileName"];
            }
        }
        public static string JsonReportFileName
        {
            get 
            {
                return config["xBDD:JsonReport:FileName"];
            }
        }
        public static string TextReportFileName
        {
            get 
            {
                return config["xBDD:TextReport:FileName"];
            }
        }
        public static string OutlineReportFileName
        {
            get 
            {
                return config["xBDD:OutlineReport:FileName"];
            }
        }
    }
}
