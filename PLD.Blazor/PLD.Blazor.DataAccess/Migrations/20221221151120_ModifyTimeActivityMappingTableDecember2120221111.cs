using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PLD.Blazor.DataAccess.Migrations
{
    public partial class ModifyTimeActivityMappingTableDecember2120221111 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TimeActivityMapping",
                table: "TimeActivityMapping");

            migrationBuilder.RenameTable(
                name: "TimeActivityMapping",
                newName: "DMT_TM_ACT_MAP");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DMT_TM_ACT_MAP",
                table: "DMT_TM_ACT_MAP",
                column: "Time_Activity_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DMT_TM_ACT_MAP",
                table: "DMT_TM_ACT_MAP");

            migrationBuilder.RenameTable(
                name: "DMT_TM_ACT_MAP",
                newName: "TimeActivityMapping");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TimeActivityMapping",
                table: "TimeActivityMapping",
                column: "Time_Activity_Id");
        }
    }
}
