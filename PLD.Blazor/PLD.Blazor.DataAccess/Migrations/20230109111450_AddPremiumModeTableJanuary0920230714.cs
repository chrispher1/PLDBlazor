using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PLD.Blazor.DataAccess.Migrations
{
    public partial class AddPremiumModeTableJanuary0920230714 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DMT_PREM_MODE_CD",
                columns: table => new
                {
                    Prem_Mode_Cd = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Desc_Txt = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Crt_Dt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Crt_By = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Mod_Dt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Mod_By = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DMT_PREM_MODE_CD", x => x.Prem_Mode_Cd);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DMT_PREM_MODE_CD");
        }
    }
}
