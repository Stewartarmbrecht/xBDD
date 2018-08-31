using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.Extensions.Configuration;

namespace xBDD.Reporting.Database.Core
{
    internal class DatabaseContext : DbContext
    {
        string connectionString;

        internal DatabaseContext()
        {
            this.connectionString = Configuration.DatabaseConnectionString;
        }
        internal DatabaseContext(string connectionString)
        {
            this.connectionString = connectionString ?? Configuration.DatabaseConnectionString;;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            // configurationBuilder.AddJsonFile("Config.json",true); // Bool indicates file is optional

            // System.Diagnostics.Trace.TraceError("hit");

            // var config = configurationBuilder.Build();
            // foreach(var pair in config.AsEnumerable()) 
            // {
            //     System.Diagnostics.Trace.WriteLine(pair.Key + ": " + pair.Value);
            // }
            optionsBuilder.UseSqlServer(connectionString);
        }

        internal bool EnsureDatabase()
        {
            return Database.EnsureCreated();
        }

        internal DbSet<TestRun> TestRuns { get; set; }
        internal DbSet<Scenario> Scenarios { get; set; }
        internal DbSet<Step> Steps { get; set; }

        internal string ServerName
        {
            get
            {
                return Database.GetDbConnection().DataSource;
            }
        }

        internal string DatabaseName
        {
            get
            {
                return Database.GetDbConnection().Database;
            }
        }
    }
}
