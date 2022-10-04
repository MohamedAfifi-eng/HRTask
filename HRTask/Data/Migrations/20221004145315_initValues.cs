using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRTask.Data.Migrations
{
    public partial class initValues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Groups",
                columns: new string[] { "Name" },
                values: new object[] { "SuperAdmin" }
                );
            migrationBuilder.InsertData(
                table: "Screens",
                columns: new string[] { "Name" },
                values: new object[] {  "Annual Vecation"}
                );
            migrationBuilder.InsertData(
                table: "Screens",
                columns: new string[] { "Name" },
                values: new object[] { "Employee" }
                );
            migrationBuilder.InsertData(
                table: "Screens",
                columns: new string[] { "Name" },
                values: new object[] { "General Settings" }
                );
            migrationBuilder.InsertData(
                table: "Screens",
                columns: new string[] { "Name" },
                values: new object[] { "Screens" }
                );
            migrationBuilder.InsertData(
                table: "Screens",
                columns: new string[] { "Name" },
                values: new object[] { "Users" }
                );
            migrationBuilder.InsertData(
                table: "Screens",
                columns: new string[] { "Name" },
                values: new object[] { "Groups" }
                );
            migrationBuilder.InsertData(
                table: "Screens",
                columns: new string[] { "Name" },
                values: new object[] { "Employee Attendance" }
                );


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
