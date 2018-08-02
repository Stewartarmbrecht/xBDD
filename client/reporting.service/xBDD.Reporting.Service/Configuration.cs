using Microsoft.Extensions.Configuration;
using xBDD;
using System.IO;
using System.Threading.Tasks;

namespace xBDD.Reporting.Service
{
    public class Configuration
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
        public static string ServiceUrl 
        {
            get 
            {
                var connectionString = config["Service:DefaultConnection:Url"];
                if(connectionString == null)
                {
                    throw new System.Exception("You must set an environment variable named 'Service:DefaultConnection:Url' to a valid xBDD publishing service.\n In powershell run the following command: '$env:Service:DefaultConnection:Url=\"<Url>\"'");
                }
                return connectionString;
            }
        }
    }
}
