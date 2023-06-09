using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PLD.Blazor.DataAccess.Migrations
{
    public partial class ModifyCaseTableMay0820230604 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "DMT_CASE");

            migrationBuilder.AddColumn<int>(
                name: "Status_Id",
                table: "DMT_CASE",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DMT_CASE_Status_Id",
                table: "DMT_CASE",
                column: "Status_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DMT_CASE_DMT_CASE_STATUS_Status_Id",
                table: "DMT_CASE",
                column: "Status_Id",
                principalTable: "DMT_CASE_STATUS",
                principalColumn: "Status_Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DMT_CASE_DMT_CASE_STATUS_Status_Id",
                table: "DMT_CASE");

            migrationBuilder.DropIndex(
                name: "IX_DMT_CASE_Status_Id",
                table: "DMT_CASE");

            migrationBuilder.DropColumn(
                name: "Status_Id",
                table: "DMT_CASE");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "DMT_CASE",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }
    }
}
