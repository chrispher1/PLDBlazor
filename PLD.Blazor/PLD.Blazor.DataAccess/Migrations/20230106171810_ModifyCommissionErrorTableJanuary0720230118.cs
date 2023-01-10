using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PLD.Blazor.DataAccess.Migrations
{
    public partial class ModifyCommissionErrorTableJanuary0720230118 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Prod_Id",
                table: "DMT_COMM_ERR",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Carr_Id",
                table: "DMT_COMM_ERR",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DMT_COMM_ERR_Act_Cd",
                table: "DMT_COMM_ERR",
                column: "Act_Cd");

            migrationBuilder.CreateIndex(
                name: "IX_DMT_COMM_ERR_Carr_Id",
                table: "DMT_COMM_ERR",
                column: "Carr_Id");

            migrationBuilder.CreateIndex(
                name: "IX_DMT_COMM_ERR_Prod_Id",
                table: "DMT_COMM_ERR",
                column: "Prod_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DMT_COMM_ERR_DMT_ACT_Act_Cd",
                table: "DMT_COMM_ERR",
                column: "Act_Cd",
                principalTable: "DMT_ACT",
                principalColumn: "Act_Cd",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DMT_COMM_ERR_DMT_CARR_Carr_Id",
                table: "DMT_COMM_ERR",
                column: "Carr_Id",
                principalTable: "DMT_CARR",
                principalColumn: "Carr_Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DMT_COMM_ERR_DMT_PROD_Prod_Id",
                table: "DMT_COMM_ERR",
                column: "Prod_Id",
                principalTable: "DMT_PROD",
                principalColumn: "Prod_Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DMT_COMM_ERR_DMT_ACT_Act_Cd",
                table: "DMT_COMM_ERR");

            migrationBuilder.DropForeignKey(
                name: "FK_DMT_COMM_ERR_DMT_CARR_Carr_Id",
                table: "DMT_COMM_ERR");

            migrationBuilder.DropForeignKey(
                name: "FK_DMT_COMM_ERR_DMT_PROD_Prod_Id",
                table: "DMT_COMM_ERR");

            migrationBuilder.DropIndex(
                name: "IX_DMT_COMM_ERR_Act_Cd",
                table: "DMT_COMM_ERR");

            migrationBuilder.DropIndex(
                name: "IX_DMT_COMM_ERR_Carr_Id",
                table: "DMT_COMM_ERR");

            migrationBuilder.DropIndex(
                name: "IX_DMT_COMM_ERR_Prod_Id",
                table: "DMT_COMM_ERR");

            migrationBuilder.AlterColumn<int>(
                name: "Prod_Id",
                table: "DMT_COMM_ERR",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Carr_Id",
                table: "DMT_COMM_ERR",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
