using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PLD.Blazor.DataAccess.Migrations
{
    public partial class ModifyCommissionErrorTableJanuary0720230149 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DMT_COMM_ERR_DMT_CARR_Carr_Id",
                table: "DMT_COMM_ERR");

            migrationBuilder.AlterColumn<int>(
                name: "Carr_Id",
                table: "DMT_COMM_ERR",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_DMT_COMM_ERR_DMT_CARR_Carr_Id",
                table: "DMT_COMM_ERR",
                column: "Carr_Id",
                principalTable: "DMT_CARR",
                principalColumn: "Carr_Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DMT_COMM_ERR_DMT_CARR_Carr_Id",
                table: "DMT_COMM_ERR");

            migrationBuilder.AlterColumn<int>(
                name: "Carr_Id",
                table: "DMT_COMM_ERR",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DMT_COMM_ERR_DMT_CARR_Carr_Id",
                table: "DMT_COMM_ERR",
                column: "Carr_Id",
                principalTable: "DMT_CARR",
                principalColumn: "Carr_Id");
        }
    }
}
