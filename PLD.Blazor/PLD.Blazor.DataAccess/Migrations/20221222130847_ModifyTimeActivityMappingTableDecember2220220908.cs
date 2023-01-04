using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PLD.Blazor.DataAccess.Migrations
{
    public partial class ModifyTimeActivityMappingTableDecember2220220908 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_DMT_TM_ACT_MAP_Act_Cd",
                table: "DMT_TM_ACT_MAP",
                column: "Act_Cd");

            migrationBuilder.AddForeignKey(
                name: "FK_DMT_TM_ACT_MAP_DMT_ACT_Act_Cd",
                table: "DMT_TM_ACT_MAP",
                column: "Act_Cd",
                principalTable: "DMT_ACT",
                principalColumn: "Act_Cd",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DMT_TM_ACT_MAP_DMT_ACT_Act_Cd",
                table: "DMT_TM_ACT_MAP");

            migrationBuilder.DropIndex(
                name: "IX_DMT_TM_ACT_MAP_Act_Cd",
                table: "DMT_TM_ACT_MAP");
        }
    }
}
