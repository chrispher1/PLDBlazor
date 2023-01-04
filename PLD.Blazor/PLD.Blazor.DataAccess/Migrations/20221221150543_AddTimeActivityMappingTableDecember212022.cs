using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PLD.Blazor.DataAccess.Migrations
{
    public partial class AddTimeActivityMappingTableDecember212022 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TimeActivityMapping",
                columns: table => new
                {
                    Time_Activity_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Carr_Id = table.Column<int>(type: "int", nullable: false),
                    Src_Tm_Cd = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    Src_Act_Cd = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Yr_Start_Num = table.Column<int>(type: "int", nullable: false),
                    Yr_End_Num = table.Column<int>(type: "int", nullable: false),
                    Tm_Cd = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    Act_Cd = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    Comp_Ind = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Crt_Dt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Crt_By = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Mod_Dt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Mod_By = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeActivityMapping", x => x.Time_Activity_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TimeActivityMapping");
        }
    }
}
