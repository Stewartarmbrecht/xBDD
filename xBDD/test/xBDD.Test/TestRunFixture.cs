using Microsoft.Framework.Runtime.Infrastructure;
using Microsoft.Framework.DependencyInjection;
using System;
using Xunit;
using Microsoft.Framework.Runtime;
using Microsoft.AspNet.Hosting;

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
            var args = Environment.GetCommandLineArgs();
            foreach(var arg in args)
            {
                Console.WriteLine(arg);
            }

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

            Startup startup = new Startup(hostEnv, ApplicationEnvironment);
        }
        public void Dispose()
        {
            if(ShouldPublish)
            {
                try
                {
                    Console.WriteLine("Saving to the databse.");
                    var count = xBDD.CurrentRun.SaveToDatabase(null);
                    Console.WriteLine("There were " + count + " objects writtent to the database.");
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

    [CollectionDefinition("TestRunCollection")]
    public class TestRunCollection : ICollectionFixture<TestRunFixture>
    {

    }
}
