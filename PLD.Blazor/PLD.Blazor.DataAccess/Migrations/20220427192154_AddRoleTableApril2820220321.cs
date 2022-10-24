using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PLD.Blazor.DataAccess.Migrations
{
    public partial class AddRoleTableApril2820220321 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DMT_ROLE",
                columns: table => new
                {
                    Role_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Role_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Crt_Dt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Crt_By = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Mod_Dt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Mod_By = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DMT_ROLE", x => x.Role_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DMT_ROLE");
        }
    }
}
