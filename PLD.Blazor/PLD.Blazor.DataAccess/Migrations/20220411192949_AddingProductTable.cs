using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PLD.Blazor.DataAccess.Migrations
{
    public partial class AddingProductTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DMT_PROD",
                columns: table => new
                {
                    Prod_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Carr_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DMT_PROD", x => x.Prod_Id);
                    table.ForeignKey(
                        name: "FK_DMT_PROD_DMT_CARR_Carr_Id",
                        column: x => x.Carr_Id,
                        principalTable: "DMT_CARR",
                        principalColumn: "Carr_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DMT_PROD_Carr_Id",
                table: "DMT_PROD",
                column: "Carr_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DMT_PROD");
        }
    }
}
