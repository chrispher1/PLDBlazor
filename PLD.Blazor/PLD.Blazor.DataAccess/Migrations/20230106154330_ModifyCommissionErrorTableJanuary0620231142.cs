using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PLD.Blazor.DataAccess.Migrations
{
    public partial class ModifyCommissionErrorTableJanuary0620231142 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Comm_Ind",
                table: "DMT_COMM_ERR",
                newName: "Comp_Ind");

            migrationBuilder.AddColumn<string>(
                name: "Crt_By",
                table: "DMT_COMM_ERR",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Crt_Dt",
                table: "DMT_COMM_ERR",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Mod_By",
                table: "DMT_COMM_ERR",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Mod_Dt",
                table: "DMT_COMM_ERR",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Crt_By",
                table: "DMT_COMM_ERR");

            migrationBuilder.DropColumn(
                name: "Crt_Dt",
                table: "DMT_COMM_ERR");

            migrationBuilder.DropColumn(
                name: "Mod_By",
                table: "DMT_COMM_ERR");

            migrationBuilder.DropColumn(
                name: "Mod_Dt",
                table: "DMT_COMM_ERR");

            migrationBuilder.RenameColumn(
                name: "Comp_Ind",
                table: "DMT_COMM_ERR",
                newName: "Comm_Ind");
        }
    }
}
