using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.Extensions.Configuration;

namespace xBDD.Reporting.Database.Core
{
    public class DatabaseContext : DbContext
    {
        string connectionString;

        public DatabaseContext()
        {
            this.connectionString = Configuration.DatabaseConnectionString;
        }
        public DatabaseContext(string connectionString)
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
