using Microsoft.Extensions.Configuration;
using xBDD;
using System.IO;
using System.Threading.Tasks;

namespace xBDD.Reporting.Database
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
    }
}
