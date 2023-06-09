using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PLD.Blazor.DataAccess.Migrations
{
    public partial class ModifyCaseTableMay0820230644 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Case_Type",
                table: "DMT_CASE");

            migrationBuilder.AddColumn<int>(
                name: "Type_Id",
                table: "DMT_CASE",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DMT_CASE_Type_Id",
                table: "DMT_CASE",
                column: "Type_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DMT_CASE_DMT_CASE_TYPE_Type_Id",
                table: "DMT_CASE",
                column: "Type_Id",
                principalTable: "DMT_CASE_TYPE",
                principalColumn: "Type_Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DMT_CASE_DMT_CASE_TYPE_Type_Id",
                table: "DMT_CASE");

            migrationBuilder.DropIndex(
                name: "IX_DMT_CASE_Type_Id",
                table: "DMT_CASE");

            migrationBuilder.DropColumn(
                name: "Type_Id",
                table: "DMT_CASE");

            migrationBuilder.AddColumn<string>(
                name: "Case_Type",
                table: "DMT_CASE",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true);
        }
    }
}
