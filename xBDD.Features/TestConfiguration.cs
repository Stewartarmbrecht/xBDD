using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
using xBDD;
using System.IO;
using System.Threading.Tasks;

namespace xBDD.Features
{
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
        public static string DatabaseConnectionString 
        {
            get 
            {
                var connectionString = config["Data:DefaultConnection:ConnectionString"];
                if(connectionString == null)
                {
                    throw new System.Exception("You must set an environment variable named 'Data:DefaultConnection:ConnectionString' to a valid databsae connection string.\n In powershell run the following command: '$env:Data:DefaultConnection:ConnectionString=\"<Connection String>\"'");
                }
                return connectionString;
            }
        }
        public static string xBDDPublishURL 
        {
            get 
            {
                var connectionString = config["Data:xBDDPublishUrl:Url"];
                if(connectionString == null)
                {
                    throw new System.Exception("You must set an environment variable named 'Data:xBDDPublishUrl:Url' to a valid xBDD publishing service.\n In powershell run the following command: '$env:Data:xBDDPublishUrl:Url=\"<Url>\"'");
                }
                return connectionString;
            }
        }
        public static bool Publish 
        {
            get 
            {
                return config["Environment"] == "Publish";
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
    }
}
