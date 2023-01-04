using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PLD.Blazor.DataAccess.Migrations
{
    public partial class ModifyTimeActivityMappingTableDecember3020221039 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_DMT_TM_ACT_MAP_Carr_Id_Src_Tm_Cd_Src_Act_Cd_Yr_Start_Num_Yr_End_Num",
                table: "DMT_TM_ACT_MAP");

            migrationBuilder.CreateIndex(
                name: "IX_DMT_TM_ACT_MAP_Carr_Id_Src_Tm_Cd_Src_Act_Cd_Yr_Start_Num_Yr_End_Num",
                table: "DMT_TM_ACT_MAP",
                columns: new[] { "Carr_Id", "Src_Tm_Cd", "Src_Act_Cd", "Yr_Start_Num", "Yr_End_Num" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_DMT_TM_ACT_MAP_Carr_Id_Src_Tm_Cd_Src_Act_Cd_Yr_Start_Num_Yr_End_Num",
                table: "DMT_TM_ACT_MAP");

            migrationBuilder.CreateIndex(
                name: "IX_DMT_TM_ACT_MAP_Carr_Id_Src_Tm_Cd_Src_Act_Cd_Yr_Start_Num_Yr_End_Num",
                table: "DMT_TM_ACT_MAP",
                columns: new[] { "Carr_Id", "Src_Tm_Cd", "Src_Act_Cd", "Yr_Start_Num", "Yr_End_Num" },
                unique: true,
                filter: "[Src_Tm_Cd] IS NOT NULL");
        }
    }
}
