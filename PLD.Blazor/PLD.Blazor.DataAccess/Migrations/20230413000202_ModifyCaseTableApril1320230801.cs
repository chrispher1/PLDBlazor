using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PLD.Blazor.DataAccess.Migrations
{
    public partial class ModifyCaseTableApril1320230801 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DMT_CASE_DMT_PROD_Prod_Id",
                table: "DMT_CASE");

            migrationBuilder.AlterColumn<int>(
                name: "Carr_Id",
                table: "DMT_CASE",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_DMT_CASE_DMT_PROD_Prod_Id",
                table: "DMT_CASE",
                column: "Prod_Id",
                principalTable: "DMT_PROD",
                principalColumn: "Prod_Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DMT_CASE_DMT_PROD_Prod_Id",
                table: "DMT_CASE");

            migrationBuilder.AlterColumn<int>(
                name: "Carr_Id",
                table: "DMT_CASE",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DMT_CASE_DMT_PROD_Prod_Id",
                table: "DMT_CASE",
                column: "Prod_Id",
                principalTable: "DMT_PROD",
                principalColumn: "Prod_Id");
        }
    }
}
