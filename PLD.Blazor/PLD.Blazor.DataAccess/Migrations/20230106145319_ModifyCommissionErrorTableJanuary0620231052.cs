using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PLD.Blazor.DataAccess.Migrations
{
    public partial class ModifyCommissionErrorTableJanuary0620231052 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Comm_Prem_Amt",
                table: "DMT_COMM_ERR",
                type: "numeric(16,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(16,2)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Comm_Prem_Amt",
                table: "DMT_COMM_ERR",
                type: "decimal(16,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric(16,2)",
                oldNullable: true);
        }
    }
}
