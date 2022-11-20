using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MilliKutuphaneDataAccess.Migrations
{
    public partial class EditedGate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gates_Users_UserId",
                table: "Gates");

            migrationBuilder.DropIndex(
                name: "IX_Gates_UserId",
                table: "Gates");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Gates");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Gates",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Gates_UserId",
                table: "Gates",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Gates_Users_UserId",
                table: "Gates",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
