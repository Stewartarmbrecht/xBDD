using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations.Infrastructure;
using xBDD.Database;

namespace xBDDMigrations
{
    [ContextType(typeof(xBDDDbContext))]
    partial class ScenarioTrackingFields
    {
        public override string Id
        {
            get { return "20150904163932_ScenarioTrackingFields"; }
        }

        public override string ProductVersion
        {
            get { return "7.0.0-beta6-13815"; }
        }

        public override void BuildTargetModel(ModelBuilder builder)
        {
            builder
                .Annotation("ProductVersion", "7.0.0-beta6-13815")
                .Annotation("SqlServer:ValueGenerationStrategy", "IdentityColumn");

            builder.Entity("xBDD.Database.Scenario", b =>
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

            builder.Entity("xBDD.Database.Step", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("EndTime");

                    b.Property<string>("Exception");

                    b.Property<string>("Name");

                    b.Property<int>("Outcome");

                    b.Property<string>("Reason");

                    b.Property<int>("ScenarioId");

                    b.Property<DateTime>("StartTime");

                    b.Key("Id");
                });

            builder.Entity("xBDD.Database.TestRun", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Key("Id");
                });

            builder.Entity("xBDD.Database.Scenario", b =>
                {
                    b.Reference("xBDD.Database.TestRun")
                        .InverseCollection()
                        .ForeignKey("TestRunId");
                });

            builder.Entity("xBDD.Database.Step", b =>
                {
                    b.Reference("xBDD.Database.Scenario")
                        .InverseCollection()
                        .ForeignKey("ScenarioId");
                });
        }
    }
}
