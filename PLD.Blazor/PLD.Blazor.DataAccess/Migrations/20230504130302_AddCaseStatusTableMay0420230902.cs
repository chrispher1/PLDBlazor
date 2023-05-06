using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PLD.Blazor.DataAccess.Migrations
{
    public partial class AddCaseStatusTableMay0420230902 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DMT_CASE_STATUS",
                columns: table => new
                {
                    Status_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Crt_Dt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Crt_By = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Mod_Dt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Mod_By = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DMT_CASE_STATUS", x => x.Status_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DMT_CASE_STATUS");
        }
    }
}
