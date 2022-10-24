using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PLD.Blazor.DataAccess.Migrations
{
    public partial class ModifyProductTableApril122022 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Crt_By",
                table: "DMT_PROD",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Crt_Dt",
                table: "DMT_PROD",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Mod_By",
                table: "DMT_PROD",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Mod_Dt",
                table: "DMT_PROD",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "DMT_PROD",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Prod_Cd",
                table: "DMT_PROD",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Prod_Rt_Ind",
                table: "DMT_PROD",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Prod_Typ_Id",
                table: "DMT_PROD",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Prod_Typ_Rt_Ind",
                table: "DMT_PROD",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SalesLink_Carrier_Id",
                table: "DMT_PROD",
                type: "nvarchar(6)",
                maxLength: 6,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DMT_PROD_Prod_Typ_Id",
                table: "DMT_PROD",
                column: "Prod_Typ_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DMT_PROD_DMT_PROD_TYP_Prod_Typ_Id",
                table: "DMT_PROD",
                column: "Prod_Typ_Id",
                principalTable: "DMT_PROD_TYP",
                principalColumn: "Prod_Typ_Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DMT_PROD_DMT_PROD_TYP_Prod_Typ_Id",
                table: "DMT_PROD");

            migrationBuilder.DropIndex(
                name: "IX_DMT_PROD_Prod_Typ_Id",
                table: "DMT_PROD");

            migrationBuilder.DropColumn(
                name: "Crt_By",
                table: "DMT_PROD");

            migrationBuilder.DropColumn(
                name: "Crt_Dt",
                table: "DMT_PROD");

            migrationBuilder.DropColumn(
                name: "Mod_By",
                table: "DMT_PROD");

            migrationBuilder.DropColumn(
                name: "Mod_Dt",
                table: "DMT_PROD");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "DMT_PROD");

            migrationBuilder.DropColumn(
                name: "Prod_Cd",
                table: "DMT_PROD");

            migrationBuilder.DropColumn(
                name: "Prod_Rt_Ind",
                table: "DMT_PROD");

            migrationBuilder.DropColumn(
                name: "Prod_Typ_Id",
                table: "DMT_PROD");

            migrationBuilder.DropColumn(
                name: "Prod_Typ_Rt_Ind",
                table: "DMT_PROD");

            migrationBuilder.DropColumn(
                name: "SalesLink_Carrier_Id",
                table: "DMT_PROD");
        }
    }
}
