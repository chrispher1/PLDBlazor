using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PLD.Blazor.DataAccess.Migrations
{
    public partial class ModifyCarrierTableApril052022 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MOD_DT",
                table: "DMT_CARR",
                newName: "Mod_Dt");

            migrationBuilder.RenameColumn(
                name: "MOD_BY",
                table: "DMT_CARR",
                newName: "Mod_By");

            migrationBuilder.RenameColumn(
                name: "CRT_DT",
                table: "DMT_CARR",
                newName: "Crt_Dt");

            migrationBuilder.RenameColumn(
                name: "CRT_BY",
                table: "DMT_CARR",
                newName: "Crt_By");

            migrationBuilder.RenameColumn(
                name: "CARR_CD",
                table: "DMT_CARR",
                newName: "Carr_Cd");

            migrationBuilder.RenameColumn(
                name: "CARR_ID",
                table: "DMT_CARR",
                newName: "Carr_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Mod_Dt",
                table: "DMT_CARR",
                newName: "MOD_DT");

            migrationBuilder.RenameColumn(
                name: "Mod_By",
                table: "DMT_CARR",
                newName: "MOD_BY");

            migrationBuilder.RenameColumn(
                name: "Crt_Dt",
                table: "DMT_CARR",
                newName: "CRT_DT");

            migrationBuilder.RenameColumn(
                name: "Crt_By",
                table: "DMT_CARR",
                newName: "CRT_BY");

            migrationBuilder.RenameColumn(
                name: "Carr_Cd",
                table: "DMT_CARR",
                newName: "CARR_CD");

            migrationBuilder.RenameColumn(
                name: "Carr_Id",
                table: "DMT_CARR",
                newName: "CARR_ID");
        }
    }
}
