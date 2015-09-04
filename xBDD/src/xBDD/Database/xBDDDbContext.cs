using Microsoft.Data.Entity;
using System.Collections.Generic;
using System;

namespace xBDD.Database
{
    public class xBDDDbContext : DbContext, IxBDDDbContext
    {
        string connectionStringName;

        public xBDDDbContext()
        {
            connectionStringName = "Data:DefaultConnection:ConnectionString";
        }
        public xBDDDbContext(string connectionStringName)
        {
            this.connectionStringName = connectionStringName ?? "Data:DefaultConnection:ConnectionString";
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
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
    }
}
