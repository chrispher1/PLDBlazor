using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PLD.Blazor.DataAccess.Migrations
{
    public partial class ModifyProductTypeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MOD_Dt",
                table: "DMT_PROD_TYP",
                newName: "Mod_Dt");

            migrationBuilder.RenameColumn(
                name: "MOD_By",
                table: "DMT_PROD_TYP",
                newName: "Mod_By");

            migrationBuilder.RenameColumn(
                name: "CRT_Dt",
                table: "DMT_PROD_TYP",
                newName: "Crt_Dt");

            migrationBuilder.RenameColumn(
                name: "CRT_By",
                table: "DMT_PROD_TYP",
                newName: "Crt_By");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Mod_Dt",
                table: "DMT_PROD_TYP",
                newName: "MOD_Dt");

            migrationBuilder.RenameColumn(
                name: "Mod_By",
                table: "DMT_PROD_TYP",
                newName: "MOD_By");

            migrationBuilder.RenameColumn(
                name: "Crt_Dt",
                table: "DMT_PROD_TYP",
                newName: "CRT_Dt");

            migrationBuilder.RenameColumn(
                name: "Crt_By",
                table: "DMT_PROD_TYP",
                newName: "CRT_By");
        }
    }
}
