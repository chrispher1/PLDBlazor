using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PLD.Blazor.DataAccess.Migrations
{
    public partial class ModifyCommissionErrorTableJanuary0720230134 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DMT_COMM_ERR_DMT_CARR_Carr_Id",
                table: "DMT_COMM_ERR");

            migrationBuilder.AddForeignKey(
                name: "FK_DMT_COMM_ERR_DMT_CARR_Carr_Id",
                table: "DMT_COMM_ERR",
                column: "Carr_Id",
                principalTable: "DMT_CARR",
                principalColumn: "Carr_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DMT_COMM_ERR_DMT_CARR_Carr_Id",
                table: "DMT_COMM_ERR");

            migrationBuilder.AddForeignKey(
                name: "FK_DMT_COMM_ERR_DMT_CARR_Carr_Id",
                table: "DMT_COMM_ERR",
                column: "Carr_Id",
                principalTable: "DMT_CARR",
                principalColumn: "Carr_Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
