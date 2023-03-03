using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PLD.Blazor.DataAccess.Migrations
{
    public partial class ModifyCommissionFinalTableFebruary0320230855 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DMT_COMM_DMT_ACT_ActivityCode",
                table: "DMT_COMM");

            migrationBuilder.DropForeignKey(
                name: "FK_DMT_COMM_DMT_CARR_Carr_Id",
                table: "DMT_COMM");

            migrationBuilder.DropForeignKey(
                name: "FK_DMT_COMM_DMT_PREM_MODE_CD_PremiumModeCode",
                table: "DMT_COMM");

            migrationBuilder.DropForeignKey(
                name: "FK_DMT_COMM_DMT_PROD_Prod_Id",
                table: "DMT_COMM");

            migrationBuilder.DropIndex(
                name: "IX_DMT_COMM_ActivityCode",
                table: "DMT_COMM");

            migrationBuilder.DropIndex(
                name: "IX_DMT_COMM_PremiumModeCode",
                table: "DMT_COMM");

            migrationBuilder.DropColumn(
                name: "ActivityCode",
                table: "DMT_COMM");

            migrationBuilder.DropColumn(
                name: "PremiumModeCode",
                table: "DMT_COMM");

            migrationBuilder.CreateIndex(
                name: "IX_DMT_COMM_Act_Cd",
                table: "DMT_COMM",
                column: "Act_Cd");

            migrationBuilder.CreateIndex(
                name: "IX_DMT_COMM_Prem_Mode_Cd",
                table: "DMT_COMM",
                column: "Prem_Mode_Cd");

            migrationBuilder.AddForeignKey(
                name: "FK_DMT_COMM_DMT_ACT_Act_Cd",
                table: "DMT_COMM",
                column: "Act_Cd",
                principalTable: "DMT_ACT",
                principalColumn: "Act_Cd",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DMT_COMM_DMT_CARR_Carr_Id",
                table: "DMT_COMM",
                column: "Carr_Id",
                principalTable: "DMT_CARR",
                principalColumn: "Carr_Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DMT_COMM_DMT_PREM_MODE_CD_Prem_Mode_Cd",
                table: "DMT_COMM",
                column: "Prem_Mode_Cd",
                principalTable: "DMT_PREM_MODE_CD",
                principalColumn: "Prem_Mode_Cd",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DMT_COMM_DMT_PROD_Prod_Id",
                table: "DMT_COMM",
                column: "Prod_Id",
                principalTable: "DMT_PROD",
                principalColumn: "Prod_Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DMT_COMM_DMT_ACT_Act_Cd",
                table: "DMT_COMM");

            migrationBuilder.DropForeignKey(
                name: "FK_DMT_COMM_DMT_CARR_Carr_Id",
                table: "DMT_COMM");

            migrationBuilder.DropForeignKey(
                name: "FK_DMT_COMM_DMT_PREM_MODE_CD_Prem_Mode_Cd",
                table: "DMT_COMM");

            migrationBuilder.DropForeignKey(
                name: "FK_DMT_COMM_DMT_PROD_Prod_Id",
                table: "DMT_COMM");

            migrationBuilder.DropIndex(
                name: "IX_DMT_COMM_Act_Cd",
                table: "DMT_COMM");

            migrationBuilder.DropIndex(
                name: "IX_DMT_COMM_Prem_Mode_Cd",
                table: "DMT_COMM");

            migrationBuilder.AddColumn<string>(
                name: "ActivityCode",
                table: "DMT_COMM",
                type: "nvarchar(4)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PremiumModeCode",
                table: "DMT_COMM",
                type: "nvarchar(5)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_DMT_COMM_ActivityCode",
                table: "DMT_COMM",
                column: "ActivityCode");

            migrationBuilder.CreateIndex(
                name: "IX_DMT_COMM_PremiumModeCode",
                table: "DMT_COMM",
                column: "PremiumModeCode");

            migrationBuilder.AddForeignKey(
                name: "FK_DMT_COMM_DMT_ACT_ActivityCode",
                table: "DMT_COMM",
                column: "ActivityCode",
                principalTable: "DMT_ACT",
                principalColumn: "Act_Cd");

            migrationBuilder.AddForeignKey(
                name: "FK_DMT_COMM_DMT_CARR_Carr_Id",
                table: "DMT_COMM",
                column: "Carr_Id",
                principalTable: "DMT_CARR",
                principalColumn: "Carr_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DMT_COMM_DMT_PREM_MODE_CD_PremiumModeCode",
                table: "DMT_COMM",
                column: "PremiumModeCode",
                principalTable: "DMT_PREM_MODE_CD",
                principalColumn: "Prem_Mode_Cd",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DMT_COMM_DMT_PROD_Prod_Id",
                table: "DMT_COMM",
                column: "Prod_Id",
                principalTable: "DMT_PROD",
                principalColumn: "Prod_Id");
        }
    }
}
