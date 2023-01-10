using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PLD.Blazor.DataAccess.Migrations
{
    public partial class AddCommissionErrorTableJanuary0620231031 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DMT_COMM_ERR",
                columns: table => new
                {
                    Comm_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Carr_Id = table.Column<int>(type: "int", nullable: false),
                    Prod_Id = table.Column<int>(type: "int", nullable: false),
                    Yr_Num = table.Column<int>(type: "int", nullable: false),
                    Pol_Num = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Trans_Dt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Pol_Dt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Act_Cd = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    Comm_Prem_Amt = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DMT_COMM_ERR", x => x.Comm_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DMT_COMM_ERR");
        }
    }
}
