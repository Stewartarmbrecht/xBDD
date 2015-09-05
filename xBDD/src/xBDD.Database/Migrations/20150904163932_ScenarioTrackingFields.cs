using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Migrations.Builders;
using Microsoft.Data.Entity.Migrations.Operations;

namespace xBDDMigrations
{
    public partial class ScenarioTrackingFields : Migration
    {
        public override void Up(MigrationBuilder migration)
        {
            migration.CreateTable(
                name: "TestRun",
                columns: table => new
                {
                    Id = table.Column(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", "IdentityColumn"),
                    Name = table.Column(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestRun", x => x.Id);
                });
            migration.CreateTable(
                name: "Scenario",
                columns: table => new
                {
                    Id = table.Column(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", "IdentityColumn"),
                    AreaPath = table.Column(type: "nvarchar(max)", nullable: true),
                    EndTime = table.Column(type: "datetime2", nullable: false),
                    FeatureName = table.Column(type: "nvarchar(max)", nullable: true),
                    Name = table.Column(type: "nvarchar(max)", nullable: true),
                    Outcome = table.Column(type: "int", nullable: false),
                    StartTime = table.Column(type: "datetime2", nullable: false),
                    TestRunId = table.Column(type: "int", nullable: false),
                    Time = table.Column(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scenario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Scenario_TestRun_TestRunId",
                        columns: x => x.TestRunId,
                        referencedTable: "TestRun",
                        referencedColumn: "Id");
                });
            migration.CreateTable(
                name: "Step",
                columns: table => new
                {
                    Id = table.Column(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", "IdentityColumn"),
                    EndTime = table.Column(type: "datetime2", nullable: false),
                    Exception = table.Column(type: "nvarchar(max)", nullable: true),
                    Name = table.Column(type: "nvarchar(max)", nullable: true),
                    Outcome = table.Column(type: "int", nullable: false),
                    Reason = table.Column(type: "nvarchar(max)", nullable: true),
                    ScenarioId = table.Column(type: "int", nullable: false),
                    StartTime = table.Column(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Step", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Step_Scenario_ScenarioId",
                        columns: x => x.ScenarioId,
                        referencedTable: "Scenario",
                        referencedColumn: "Id");
                });
        }

        public override void Down(MigrationBuilder migration)
        {
            migration.DropTable("Step");
            migration.DropTable("Scenario");
            migration.DropTable("TestRun");
        }
    }
}
