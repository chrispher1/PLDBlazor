using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PLD.Blazor.DataAccess.Migrations
{
    public partial class AddProductTypeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DMT_PROD_TYP",
                columns: table => new
                {
                    Prod_Typ_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Prod_Typ_Cd = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CRT_Dt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CRT_By = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MOD_Dt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MOD_By = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DMT_PROD_TYP", x => x.Prod_Typ_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DMT_PROD_TYP");
        }
    }
}
