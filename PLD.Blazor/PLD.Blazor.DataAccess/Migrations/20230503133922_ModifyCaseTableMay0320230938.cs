using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PLD.Blazor.DataAccess.Migrations
{
    public partial class ModifyCaseTableMay0320230938 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Prod_Typ_Id",
                table: "DMT_CASE",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Prod_Typ_Id",
                table: "DMT_CASE",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
