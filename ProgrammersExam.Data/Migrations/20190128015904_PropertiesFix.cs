using Microsoft.EntityFrameworkCore.Migrations;

namespace ProgrammersExam.Data.Migrations
{
    public partial class PropertiesFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Audience",
                table: "PerformanceOrder",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Audience",
                table: "PerformanceOrder");
        }
    }
}
