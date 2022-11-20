using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MilliKutuphaneDataAccess.Migrations
{
    public partial class AddedUserHistoryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Gates",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    GateId = table.Column<int>(type: "int", nullable: false),
                    PassageWayTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EntranceType = table.Column<int>(type: "int", maxLength: 1, nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    LastModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    isDelete = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserHistory_Gates_GateId",
                        column: x => x.GateId,
                        principalTable: "Gates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserHistory_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Gates_UserId",
                table: "Gates",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserHistory_GateId",
                table: "UserHistory",
                column: "GateId");

            migrationBuilder.CreateIndex(
                name: "IX_UserHistory_UserId",
                table: "UserHistory",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Gates_Users_UserId",
                table: "Gates",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gates_Users_UserId",
                table: "Gates");

            migrationBuilder.DropTable(
                name: "UserHistory");

            migrationBuilder.DropIndex(
                name: "IX_Gates_UserId",
                table: "Gates");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Gates");
        }
    }
}
