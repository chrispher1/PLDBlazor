using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PLD.Blazor.DataAccess.Migrations
{
    public partial class AddUserRoleTableApril2820220501 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DMT_USER_ROLE",
                columns: table => new
                {
                    User_Id = table.Column<int>(type: "int", nullable: false),
                    Role_Id = table.Column<int>(type: "int", nullable: false),
                    Crt_Dt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Crt_By = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Mod_Dt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Mod_By = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DMT_USER_ROLE", x => new { x.User_Id, x.Role_Id });
                    table.ForeignKey(
                        name: "FK_DMT_USER_ROLE_DMT_ROLE_Role_Id",
                        column: x => x.Role_Id,
                        principalTable: "DMT_ROLE",
                        principalColumn: "Role_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DMT_USER_ROLE_DMT_USER_User_Id",
                        column: x => x.User_Id,
                        principalTable: "DMT_USER",
                        principalColumn: "User_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DMT_USER_ROLE_Role_Id",
                table: "DMT_USER_ROLE",
                column: "Role_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DMT_USER_ROLE");
        }
    }
}
