using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PLD.Blazor.DataAccess.Migrations
{
    public partial class ModifyProductTableApril1920221224 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Prod_Typ_Id",
                table: "DMT_PROD",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DMT_PROD_Prod_Typ_Id",
                table: "DMT_PROD",
                column: "Prod_Typ_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DMT_PROD_DMT_PROD_TYP_Prod_Typ_Id",
                table: "DMT_PROD",
                column: "Prod_Typ_Id",
                principalTable: "DMT_PROD_TYP",
                principalColumn: "Prod_Typ_Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DMT_PROD_DMT_PROD_TYP_Prod_Typ_Id",
                table: "DMT_PROD");

            migrationBuilder.DropIndex(
                name: "IX_DMT_PROD_Prod_Typ_Id",
                table: "DMT_PROD");

            migrationBuilder.DropColumn(
                name: "Prod_Typ_Id",
                table: "DMT_PROD");
        }
    }
}
