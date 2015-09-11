using Microsoft.Data.Entity;
using System;
using Microsoft.Framework.Runtime.Infrastructure;
using Microsoft.Framework.Runtime;
using Microsoft.Framework.DependencyInjection;
using Microsoft.AspNet.Hosting;

namespace xBDD.Reporting.Database.Core
{
    public class DatabaseContext : DbContext, IDatabaseContext
    {
        string connectionStringName;

        public DatabaseContext()
        {
            connectionStringName = "Data:DefaultConnection:ConnectionString";
        }
        public DatabaseContext(string connectionStringName)
        {
            this.connectionStringName = connectionStringName ?? "Data:DefaultConnection:ConnectionString";
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(Startup.Configuration == null)
            {
                var provider = CallContextServiceLocator.Locator.ServiceProvider;
                var appEnv = provider.GetRequiredService<IApplicationEnvironment>();
                Console.WriteLine("Currently using the " + appEnv.Configuration + " configuration.");
                var hostEnv = new HostingEnvironment();
                Console.WriteLine("Writing command line arguments");
                var environment = Environment.GetEnvironmentVariable("Environment");
                var args = Environment.GetCommandLineArgs();
                foreach (var arg in args)
                {
                    Console.WriteLine(arg);
                }

                if (environment == null)
                    hostEnv.EnvironmentName = "Development";
                else
                    hostEnv.EnvironmentName = environment;
                Console.WriteLine("The hosting environment was set to " + hostEnv.EnvironmentName);
                var statup = new Startup(hostEnv, appEnv);
            }
            var connectionString = Startup.Configuration.Get(connectionStringName);
            optionsBuilder.UseSqlServer(connectionString);
        }

        public bool EnsureDatabase()
        {
            return Database.EnsureCreated();
        }

        public DbSet<TestRun> TestRuns { get; set; }
        public DbSet<Scenario> Scenarios { get; set; }
        public DbSet<Step> Steps { get; set; }

        public string ServerName
        {
            get
            {
                return Database.GetDbConnection().DataSource;
            }
        }

        public string DatabaseName
        {
            get
            {
                return Database.GetDbConnection().Database;
            }
        }
    }
}
