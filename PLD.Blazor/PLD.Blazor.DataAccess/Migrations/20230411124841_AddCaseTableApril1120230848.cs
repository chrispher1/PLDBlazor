using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PLD.Blazor.DataAccess.Migrations
{
    public partial class AddCaseTableApril1120230848 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DMT_CASE",
                columns: table => new
                {
                    Case_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Carr_Id = table.Column<int>(type: "int", nullable: true),
                    Policy_Number = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Case_Type = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Prod_Id = table.Column<int>(type: "int", nullable: true),
                    Prim_Ins_FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Prim_Ins_LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Issue_State = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    Issue_Age = table.Column<int>(type: "int", nullable: true),
                    App_Receipt_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Issue_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Policy_Eff_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Policy_Placed_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Face_Amt = table.Column<decimal>(type: "numeric(16,2)", nullable: true),
                    Modal_Premium = table.Column<decimal>(type: "numeric(16,2)", nullable: true),
                    Premium_Mode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Annualized_Premium = table.Column<decimal>(type: "numeric(16,2)", nullable: true),
                    Target_Prem_Amt = table.Column<decimal>(type: "numeric(16,2)", nullable: true),
                    Excess_Premium = table.Column<decimal>(type: "numeric(16,2)", nullable: true),
                    Crt_Dt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Crt_By = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Mod_Dt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Mod_By = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DMT_CASE", x => x.Case_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DMT_CASE");
        }
    }
}
