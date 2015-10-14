using System;
using System.IO;
using System.Linq;
using Microsoft.AspNet.Hosting;
using Microsoft.Dnx.Runtime;
using Microsoft.Dnx.Runtime.Infrastructure;
using Microsoft.Framework.Configuration;
using Microsoft.Framework.DependencyInjection;
using xBDD.Utility;
using Xunit;

namespace xBDD.Test
{
    public class TestRunFixture : IDisposable
    {
        public IApplicationEnvironment ApplicationEnvironment { get; set; }
        public bool ShouldPublish { get; private set; }
        public string ProjectName { get; private set;}

        public TestRunFixture(string projectName)
        {
            ProjectName = projectName;
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
            xBDD.CurrentRun.TestRun.Name = projectName.Replace(".Test", "").Replace(".", " ");
        }
        public static IConfiguration Configuration { get; set; }
        public virtual void Dispose()
        {
            if(ShouldPublish)
            {
                try
                {
                    Console.WriteLine("Removing SampleCode scenarios.");
                    var scenarios = xBDD.CurrentRun.TestRun.Scenarios.Where(x => x.Feature.Area.Name.Contains("SampleCode")).ToList();
                    Console.WriteLine("Found " + scenarios.Count() + " sample code scenarios.");
                    foreach(var scenario in scenarios)
                    {
                        xBDD.CurrentRun.TestRun.Scenarios.Remove(scenario);
                        Console.WriteLine("Scenario '" + scenario.Name + "' removed.");
                    }
                    Console.WriteLine("SampleCode scenarios have been removed.");

                    Console.WriteLine("Saving to the databse.");
                    var count = xBDD.CurrentRun.TestRun.SaveToDatabase(null);
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
            var baseAreaNameToTrim = (ProjectName + ".Features.").ConvertNamespaceToAreaName(); 
            xBDD.CurrentRun.TestRun.Areas.ForEach(x => { x.Name = x.Name.Replace(baseAreaNameToTrim, ""); });
            File.WriteAllText(ProjectName + ".TestResults.txt", xBDD.CurrentRun.TestRun.WriteToText());
            File.WriteAllText(ProjectName + ".TestResults.html", xBDD.CurrentRun.TestRun.WriteToHtml());
        }
    }
    public class xBDDTestTestRunFixture : TestRunFixture
    {
        public xBDDTestTestRunFixture()
            : base("xBDD.Test")
        {

        }
    }
    [CollectionDefinition("xBDDTest")]
    public class TestRunCollection : ICollectionFixture<xBDDTestTestRunFixture>
    {

    }
}
