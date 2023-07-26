using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PLD.Blazor.DataAccess.Migrations
{
    public partial class AddPaymentTableJuly0520231132 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DMT_PAY",
                columns: table => new
                {
                    Pay_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Carr_Id = table.Column<int>(type: "int", nullable: false),
                    Pay_Dt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Chk_Wire_Num = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dep_Dt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Eft_Ovr_Amt = table.Column<decimal>(type: "numeric(16,2)", nullable: false),
                    Crt_Dt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Crt_By = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Mod_Dt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Mod_By = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DMT_PAY", x => x.Pay_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DMT_PAY");
        }
    }
}
