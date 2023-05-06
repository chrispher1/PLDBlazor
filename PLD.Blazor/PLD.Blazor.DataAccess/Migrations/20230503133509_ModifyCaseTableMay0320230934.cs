using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PLD.Blazor.DataAccess.Migrations
{
    public partial class ModifyCaseTableMay0320230934 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Prod_Typ_Id",
                table: "DMT_CASE",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DMT_CASE_Prod_Typ_Id",
                table: "DMT_CASE",
                column: "Prod_Typ_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DMT_CASE_DMT_PROD_TYP_Prod_Typ_Id",
                table: "DMT_CASE",
                column: "Prod_Typ_Id",
                principalTable: "DMT_PROD_TYP",
                principalColumn: "Prod_Typ_Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DMT_CASE_DMT_PROD_TYP_Prod_Typ_Id",
                table: "DMT_CASE");

            migrationBuilder.DropIndex(
                name: "IX_DMT_CASE_Prod_Typ_Id",
                table: "DMT_CASE");

            migrationBuilder.DropColumn(
                name: "Prod_Typ_Id",
                table: "DMT_CASE");
        }
    }
}
