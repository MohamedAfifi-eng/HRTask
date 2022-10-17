using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRTask.Data.Migrations
{
    public partial class updateEmployeeAttendance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "DayCost",
                table: "EmployeeAttendances",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "calculatedPonus",
                table: "EmployeeAttendances",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "discount",
                table: "EmployeeAttendances",
                type: "decimal(18,2)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DayCost",
                table: "EmployeeAttendances");

            migrationBuilder.DropColumn(
                name: "calculatedPonus",
                table: "EmployeeAttendances");

            migrationBuilder.DropColumn(
                name: "discount",
                table: "EmployeeAttendances");
        }
    }
}
