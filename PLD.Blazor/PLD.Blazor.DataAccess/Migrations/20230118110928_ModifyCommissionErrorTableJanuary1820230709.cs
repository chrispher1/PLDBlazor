using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PLD.Blazor.DataAccess.Migrations
{
    public partial class ModifyCommissionErrorTableJanuary1820230709 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_DMT_COMM_ERR_Prem_Mode_Cd",
                table: "DMT_COMM_ERR",
                column: "Prem_Mode_Cd");

            migrationBuilder.AddForeignKey(
                name: "FK_DMT_COMM_ERR_DMT_PREM_MODE_CD_Prem_Mode_Cd",
                table: "DMT_COMM_ERR",
                column: "Prem_Mode_Cd",
                principalTable: "DMT_PREM_MODE_CD",
                principalColumn: "Prem_Mode_Cd",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DMT_COMM_ERR_DMT_PREM_MODE_CD_Prem_Mode_Cd",
                table: "DMT_COMM_ERR");

            migrationBuilder.DropIndex(
                name: "IX_DMT_COMM_ERR_Prem_Mode_Cd",
                table: "DMT_COMM_ERR");
        }
    }
}
