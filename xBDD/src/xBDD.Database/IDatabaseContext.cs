using Microsoft.Data.Entity;

namespace xBDD.Database.Core
{
    public interface IDatabaseContext
    {
        DbSet<Scenario> Scenarios { get; set; }
        DbSet<Step> Steps { get; set; }
        DbSet<TestRun> TestRuns { get; set; }
        string ServerName { get; }
        string DatabaseName { get; }

        int SaveChanges();
        bool EnsureDatabase();
    }
}