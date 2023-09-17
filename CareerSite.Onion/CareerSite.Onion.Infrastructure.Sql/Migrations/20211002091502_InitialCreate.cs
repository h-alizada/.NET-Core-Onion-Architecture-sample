using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CareerSite.Onion.Infrastructure.Sql.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JobApplications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PositionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PositionLevel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppicantFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicantEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicantLinkedinUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicantSalaryExpectations = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ApplicantYearsOfExperience = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobApplications", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobApplications");
        }
    }
}
