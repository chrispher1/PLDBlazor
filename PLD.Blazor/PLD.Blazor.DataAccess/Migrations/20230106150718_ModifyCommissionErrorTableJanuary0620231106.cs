using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PLD.Blazor.DataAccess.Migrations
{
    public partial class ModifyCommissionErrorTableJanuary0620231106 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Comm_Amt",
                table: "DMT_COMM_ERR",
                type: "numeric(16,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Comm_Ind",
                table: "DMT_COMM_ERR",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Comm_Rt",
                table: "DMT_COMM_ERR",
                type: "decimal(12,9)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Prem_Mode_Cd",
                table: "DMT_COMM_ERR",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comm_Amt",
                table: "DMT_COMM_ERR");

            migrationBuilder.DropColumn(
                name: "Comm_Ind",
                table: "DMT_COMM_ERR");

            migrationBuilder.DropColumn(
                name: "Comm_Rt",
                table: "DMT_COMM_ERR");

            migrationBuilder.DropColumn(
                name: "Prem_Mode_Cd",
                table: "DMT_COMM_ERR");
        }
    }
}
