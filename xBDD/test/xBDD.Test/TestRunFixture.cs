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

        public TestRunFixture()
        {
            var provider = CallContextServiceLocator.Locator.ServiceProvider;
            ApplicationEnvironment = provider.GetRequiredService<IApplicationEnvironment>();
            Console.WriteLine(ApplicationEnvironment.Configuration);
            var hostEnv = new HostingEnvironment();
            hostEnv.EnvironmentName = "Development";
            Startup startup = new Startup(hostEnv, ApplicationEnvironment);
        }
        public void Dispose()
        {
#if PUBLISH
            xBDD.CurrentRun.SaveToDatabase(null);
#endif
        }
    }

    [CollectionDefinition("TestRunCollection")]
    public class TestRunCollection : ICollectionFixture<TestRunFixture>
    {

    }
}
