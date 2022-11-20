using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MilliKutuphaneDataAccess.Migrations
{
    public partial class ChangedStudentEntitiesName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SchoolNumber",
                table: "Students",
                newName: "StudentNumber");

            migrationBuilder.RenameColumn(
                name: "Depertment",
                table: "Students",
                newName: "Department");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StudentNumber",
                table: "Students",
                newName: "SchoolNumber");

            migrationBuilder.RenameColumn(
                name: "Department",
                table: "Students",
                newName: "Depertment");
        }
    }
}
