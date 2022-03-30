using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PLD.Blazor.DataAccess.Migrations
{
    public partial class ModifyCarrierTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Carrier",
                table: "Carrier");

            migrationBuilder.RenameTable(
                name: "Carrier",
                newName: "DMT_CARR");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "DMT_CARR",
                newName: "MOD_DT");

            migrationBuilder.RenameColumn(
                name: "ModifiedBy",
                table: "DMT_CARR",
                newName: "MOD_BY");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "DMT_CARR",
                newName: "CRT_DT");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "DMT_CARR",
                newName: "CRT_BY");

            migrationBuilder.RenameColumn(
                name: "CarrierCode",
                table: "DMT_CARR",
                newName: "CARR_CD");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "DMT_CARR",
                newName: "CARR_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DMT_CARR",
                table: "DMT_CARR",
                column: "CARR_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DMT_CARR",
                table: "DMT_CARR");

            migrationBuilder.RenameTable(
                name: "DMT_CARR",
                newName: "Carrier");

            migrationBuilder.RenameColumn(
                name: "MOD_DT",
                table: "Carrier",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "MOD_BY",
                table: "Carrier",
                newName: "ModifiedBy");

            migrationBuilder.RenameColumn(
                name: "CRT_DT",
                table: "Carrier",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "CRT_BY",
                table: "Carrier",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "CARR_CD",
                table: "Carrier",
                newName: "CarrierCode");

            migrationBuilder.RenameColumn(
                name: "CARR_ID",
                table: "Carrier",
                newName: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Carrier",
                table: "Carrier",
                column: "Id");
        }
    }
}
