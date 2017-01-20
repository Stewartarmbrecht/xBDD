using Microsoft.EntityFrameworkCore;
using System;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.Framework.DependencyInjection;

namespace xBDD.Reporting.Database.Core
{
    public class DatabaseContext : DbContext
    {
        string connectionStringName;

        public DatabaseContext()
        {
            connectionStringName = "Filename=./xBDD.db";
        }
        public DatabaseContext(string connectionStringName)
        {
            this.connectionStringName = connectionStringName ?? "Data:DefaultConnection:ConnectionString";
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(connectionStringName);
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
