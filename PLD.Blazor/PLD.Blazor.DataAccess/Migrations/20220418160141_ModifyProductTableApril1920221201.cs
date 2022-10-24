using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PLD.Blazor.DataAccess.Migrations
{
    public partial class ModifyProductTableApril1920221201 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Carr_Id",
                table: "DMT_PROD",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DMT_PROD_Carr_Id",
                table: "DMT_PROD",
                column: "Carr_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DMT_PROD_DMT_CARR_Carr_Id",
                table: "DMT_PROD",
                column: "Carr_Id",
                principalTable: "DMT_CARR",
                principalColumn: "Carr_Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DMT_PROD_DMT_CARR_Carr_Id",
                table: "DMT_PROD");

            migrationBuilder.DropIndex(
                name: "IX_DMT_PROD_Carr_Id",
                table: "DMT_PROD");

            migrationBuilder.DropColumn(
                name: "Carr_Id",
                table: "DMT_PROD");
        }
    }
}
