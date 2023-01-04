using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PLD.Blazor.DataAccess.Migrations
{
    public partial class ModifyTimeActivityMappingTableDecember222022 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_DMT_TM_ACT_MAP_Carr_Id",
                table: "DMT_TM_ACT_MAP",
                column: "Carr_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DMT_TM_ACT_MAP_DMT_CARR_Carr_Id",
                table: "DMT_TM_ACT_MAP",
                column: "Carr_Id",
                principalTable: "DMT_CARR",
                principalColumn: "Carr_Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DMT_TM_ACT_MAP_DMT_CARR_Carr_Id",
                table: "DMT_TM_ACT_MAP");

            migrationBuilder.DropIndex(
                name: "IX_DMT_TM_ACT_MAP_Carr_Id",
                table: "DMT_TM_ACT_MAP");
        }
    }
}
