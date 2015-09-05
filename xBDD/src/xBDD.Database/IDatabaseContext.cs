using Microsoft.Data.Entity;

namespace xBDD.Database.Core
{
    public interface IDatabaseContext
    {
        DbSet<Scenario> Scenarios { get; set; }
        DbSet<Step> Steps { get; set; }
        DbSet<TestRun> TestRuns { get; set; }

        int SaveChanges();
        bool EnsureDatabase();
    }
}