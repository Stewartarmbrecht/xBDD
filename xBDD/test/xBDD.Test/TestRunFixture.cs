using Microsoft.Dnx.Runtime.Infrastructure;
using Microsoft.Framework.DependencyInjection;
using System;
using System.Linq;
using System.Linq.Expressions;
using Xunit;
using Microsoft.Dnx.Runtime;
using Microsoft.AspNet.Hosting;
using Microsoft.Framework.Configuration;

namespace xBDD.Test
{
    public class TestRunFixture : IDisposable
    {
        public IApplicationEnvironment ApplicationEnvironment { get; set; }
        public bool ShouldPublish { get; private set; }

        public TestRunFixture()
        {
            var provider = CallContextServiceLocator.Locator.ServiceProvider;
            ApplicationEnvironment = provider.GetRequiredService<IApplicationEnvironment>();
            Console.WriteLine("Currently using the " + ApplicationEnvironment.Configuration + " configuration.");
            var hostEnv = new HostingEnvironment();
            Console.WriteLine("Writing command line arguments");
            var environment = Environment.GetEnvironmentVariable("Environment");

            if (environment == null)
                hostEnv.EnvironmentName = "Development";
            else
                hostEnv.EnvironmentName = environment;
            Console.WriteLine("The hosting environment was set to " + hostEnv.EnvironmentName);

            if (hostEnv.EnvironmentName.ToLower() == "publish")
                ShouldPublish = true;
#if PUBLISH
            ShouldPublish = true;
#endif

            var builder = new ConfigurationBuilder(ApplicationEnvironment.ApplicationBasePath)
                .AddJsonFile("config.json")
                .AddJsonFile($"config.{hostEnv.EnvironmentName}.json", optional: true);

            builder.AddUserSecrets();
            //if (env.IsDevelopment())
            //{
            //    // This reads the configuration keys from the secret store.
            //    // For more details on using the user secret store see http://go.microsoft.com/fwlink/?LinkID=532709
            //    builder.AddUserSecrets();
            //}
            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }
        public static IConfiguration Configuration { get; set; }
        public void Dispose()
        {
            if(ShouldPublish)
            {
                try
                {
                    Console.WriteLine("Removing SampleCode scenarios.");
                    var scenarios = xBDD.CurrentRun.Scenarios.Where(x => x.AreaPath.Contains("SampleCode")).ToList();
                    Console.WriteLine("Found " + scenarios.Count() + " sample code scenarios.");
                    foreach(var scenario in scenarios)
                    {
                        xBDD.CurrentRun.Scenarios.Remove(scenario);
                        Console.WriteLine("Scenario '" + scenario.Name + "' removed.");
                    }
                    Console.WriteLine("SampleCode scenarios have been removed.");

                    Console.WriteLine("Saving to the databse.");
                    var count = xBDD.CurrentRun.SaveToDatabase(null);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
            }
            else
            {
                Console.WriteLine("Saving to the database was skipped.");
            }
        }
    }

    [CollectionDefinition("xBDDTest")]
    public class TestRunCollection : ICollectionFixture<TestRunFixture>
    {

    }
}
