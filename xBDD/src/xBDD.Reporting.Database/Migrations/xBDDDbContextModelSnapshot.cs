using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations.Infrastructure;
using xBDD.Reporting.Database.Core;

namespace xBDDMigrations
{
    [ContextType(typeof(DatabaseContext))]
    partial class xBDDDbContextModelSnapshot : ModelSnapshot
    {
        public override void BuildModel(ModelBuilder builder)
        {
            builder
                .Annotation("ProductVersion", "7.0.0-beta6-13815")
                .Annotation("SqlServer:ValueGenerationStrategy", "IdentityColumn");

            builder.Entity("xBDD.Database.Core.Scenario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AreaPath");

                    b.Property<DateTime>("EndTime");

                    b.Property<string>("FeatureName");

                    b.Property<string>("Name");

                    b.Property<int>("Outcome");

                    b.Property<DateTime>("StartTime");

                    b.Property<int>("TestRunId");

                    b.Property<TimeSpan>("Time");

                    b.Key("Id");
                });

            builder.Entity("xBDD.Database.Core.Step", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("EndTime");

                    b.Property<string>("Exception");

                    b.Property<string>("MultilineParameter");

                    b.Property<string>("Name");

                    b.Property<int>("Outcome");

                    b.Property<string>("Reason");

                    b.Property<int>("ScenarioId");

                    b.Property<DateTime>("StartTime");

                    b.Key("Id");
                });

            builder.Entity("xBDD.Database.Core.TestRun", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Key("Id");
                });

            builder.Entity("xBDD.Database.Core.Scenario", b =>
                {
                    b.Reference("xBDD.Database.Core.TestRun")
                        .InverseCollection()
                        .ForeignKey("TestRunId");
                });

            builder.Entity("xBDD.Database.Core.Step", b =>
                {
                    b.Reference("xBDD.Database.Core.Scenario")
                        .InverseCollection()
                        .ForeignKey("ScenarioId");
                });
        }
    }
}
