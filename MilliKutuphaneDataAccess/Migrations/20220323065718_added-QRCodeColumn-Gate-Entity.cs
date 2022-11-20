using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MilliKutuphaneDataAccess.Migrations
{
    public partial class addedQRCodeColumnGateEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "QrCode",
                table: "Gates",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QrCode",
                table: "Gates");
        }
    }
}
