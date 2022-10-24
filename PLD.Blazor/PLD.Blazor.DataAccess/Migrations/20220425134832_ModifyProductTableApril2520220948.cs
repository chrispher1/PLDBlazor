using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PLD.Blazor.DataAccess.Migrations
{
    public partial class ModifyProductTableApril2520220948 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DMT_PROD_DMT_CARR_Carr_Id",
                table: "DMT_PROD");

            migrationBuilder.DropForeignKey(
                name: "FK_DMT_PROD_DMT_PROD_TYP_Prod_Typ_Id",
                table: "DMT_PROD");

            migrationBuilder.DropIndex(
                name: "IX_DMT_PROD_Carr_Id",
                table: "DMT_PROD");

            migrationBuilder.DropIndex(
                name: "IX_DMT_PROD_Prod_Typ_Id",
                table: "DMT_PROD");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_DMT_PROD_Carr_Id",
                table: "DMT_PROD",
                column: "Carr_Id");

            migrationBuilder.CreateIndex(
                name: "IX_DMT_PROD_Prod_Typ_Id",
                table: "DMT_PROD",
                column: "Prod_Typ_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DMT_PROD_DMT_CARR_Carr_Id",
                table: "DMT_PROD",
                column: "Carr_Id",
                principalTable: "DMT_CARR",
                principalColumn: "Carr_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DMT_PROD_DMT_PROD_TYP_Prod_Typ_Id",
                table: "DMT_PROD",
                column: "Prod_Typ_Id",
                principalTable: "DMT_PROD_TYP",
                principalColumn: "Prod_Typ_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
