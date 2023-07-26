using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PLD.Blazor.DataAccess.Migrations
{
    public partial class ModifyPaymentTableJuly0520231158 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_DMT_PAY_Carr_Id",
                table: "DMT_PAY",
                column: "Carr_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DMT_PAY_DMT_CARR_Carr_Id",
                table: "DMT_PAY",
                column: "Carr_Id",
                principalTable: "DMT_CARR",
                principalColumn: "Carr_Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DMT_PAY_DMT_CARR_Carr_Id",
                table: "DMT_PAY");

            migrationBuilder.DropIndex(
                name: "IX_DMT_PAY_Carr_Id",
                table: "DMT_PAY");
        }
    }
}
