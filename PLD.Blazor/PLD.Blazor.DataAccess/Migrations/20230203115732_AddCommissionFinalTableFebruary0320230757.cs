using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PLD.Blazor.DataAccess.Migrations
{
    public partial class AddCommissionFinalTableFebruary0320230757 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DMT_COMM",
                columns: table => new
                {
                    Comm_Id = table.Column<int>(type: "int", nullable: false),
                    Carr_Id = table.Column<int>(type: "int", nullable: true),
                    Prod_Id = table.Column<int>(type: "int", nullable: true),
                    Yr_Num = table.Column<int>(type: "int", nullable: true),
                    Pol_Num = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Trans_Dt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Pol_Dt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Act_Cd = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    ActivityCode = table.Column<string>(type: "nvarchar(4)", nullable: true),
                    Comm_Prem_Amt = table.Column<decimal>(type: "numeric(16,2)", nullable: true),
                    Prem_Mode_Cd = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    PremiumModeCode = table.Column<string>(type: "nvarchar(5)", nullable: false),
                    Comm_Rt = table.Column<decimal>(type: "decimal(12,9)", nullable: true),
                    Comm_Amt = table.Column<decimal>(type: "numeric(16,2)", nullable: true),
                    Comp_Ind = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    Crt_Dt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Crt_By = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Mod_Dt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Mod_By = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DMT_COMM", x => x.Comm_Id);
                    table.ForeignKey(
                        name: "FK_DMT_COMM_DMT_ACT_ActivityCode",
                        column: x => x.ActivityCode,
                        principalTable: "DMT_ACT",
                        principalColumn: "Act_Cd");
                    table.ForeignKey(
                        name: "FK_DMT_COMM_DMT_CARR_Carr_Id",
                        column: x => x.Carr_Id,
                        principalTable: "DMT_CARR",
                        principalColumn: "Carr_Id");
                    table.ForeignKey(
                        name: "FK_DMT_COMM_DMT_PREM_MODE_CD_PremiumModeCode",
                        column: x => x.PremiumModeCode,
                        principalTable: "DMT_PREM_MODE_CD",
                        principalColumn: "Prem_Mode_Cd",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DMT_COMM_DMT_PROD_Prod_Id",
                        column: x => x.Prod_Id,
                        principalTable: "DMT_PROD",
                        principalColumn: "Prod_Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DMT_COMM_ActivityCode",
                table: "DMT_COMM",
                column: "ActivityCode");

            migrationBuilder.CreateIndex(
                name: "IX_DMT_COMM_Carr_Id",
                table: "DMT_COMM",
                column: "Carr_Id");

            migrationBuilder.CreateIndex(
                name: "IX_DMT_COMM_PremiumModeCode",
                table: "DMT_COMM",
                column: "PremiumModeCode");

            migrationBuilder.CreateIndex(
                name: "IX_DMT_COMM_Prod_Id",
                table: "DMT_COMM",
                column: "Prod_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DMT_COMM");
        }
    }
}
