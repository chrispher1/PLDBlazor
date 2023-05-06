using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PLD.Blazor.DataAccess.Migrations
{
    public partial class ModifyCaseTableApril1120231009 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Carr_Id",
                table: "DMT_CASE",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DMT_CASE_Carr_Id",
                table: "DMT_CASE",
                column: "Carr_Id");

            migrationBuilder.CreateIndex(
                name: "IX_DMT_CASE_Prod_Id",
                table: "DMT_CASE",
                column: "Prod_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DMT_CASE_DMT_CARR_Carr_Id",
                table: "DMT_CASE",
                column: "Carr_Id",
                principalTable: "DMT_CARR",
                principalColumn: "Carr_Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DMT_CASE_DMT_PROD_Prod_Id",
                table: "DMT_CASE",
                column: "Prod_Id",
                principalTable: "DMT_PROD",
                principalColumn: "Prod_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DMT_CASE_DMT_CARR_Carr_Id",
                table: "DMT_CASE");

            migrationBuilder.DropForeignKey(
                name: "FK_DMT_CASE_DMT_PROD_Prod_Id",
                table: "DMT_CASE");

            migrationBuilder.DropIndex(
                name: "IX_DMT_CASE_Carr_Id",
                table: "DMT_CASE");

            migrationBuilder.DropIndex(
                name: "IX_DMT_CASE_Prod_Id",
                table: "DMT_CASE");

            migrationBuilder.AlterColumn<int>(
                name: "Carr_Id",
                table: "DMT_CASE",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
