namespace xBDD
{
    using Microsoft.Extensions.Configuration;
    using xBDD;
    using System.IO;
    using System.Threading.Tasks;

    internal static class Configuration
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
                        .AddJsonFile("xBDDConfig.json",true)
                        .AddEnvironmentVariables(); // Bool indicates file is optional

                    configHolder = configurationBuilder.Build();
                }
                return configHolder;
            }
        }
        internal static string DatabaseConnectionString 
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
        internal static string xBDDPublishURL 
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
        internal static bool Publish 
        {
            get 
            {
                return config["Environment"] == "Publish";
            }
        }
        internal static bool FailuresOnly 
        {
            get 
            {
                var value = false;
                bool.TryParse(config["xBDD:HtmlReport:FailuresOnly"], out value);
                return value;
            }
        }
        internal static string TestRunName
        {
            get 
            {
                return config["xBDD:TestRunName"];
            }
        }
        internal static bool WatchBrowswer
        {
            get 
            {
                var value = false;
                bool.TryParse(config["xBDD:Browser:Watch"], out value);
                return value;
            }
        }
        internal static string RemoveFromCapabilityNameStart
        {
            get 
            {
                return config["xBDD:HtmlReport:RemoveFromCapabilityNameStart"];
            }
        }
    }
}
