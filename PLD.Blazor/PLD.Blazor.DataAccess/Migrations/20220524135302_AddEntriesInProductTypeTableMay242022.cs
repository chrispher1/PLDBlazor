using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PLD.Blazor.DataAccess.Migrations
{
    public partial class AddEntriesInProductTypeTableMay242022 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO DMT_PROD_TYP ([Prod_Typ_Cd], [Name], [Crt_Dt], [Crt_By]) VALUES ('0', 'Unknown', GETDATE(), 'SYSTEM')");
            migrationBuilder.Sql("INSERT INTO DMT_PROD_TYP ([Prod_Typ_Cd], [Name], [Crt_Dt], [Crt_By]) VALUES ('1', 'Whole Life', GETDATE(), 'SYSTEM')");
            migrationBuilder.Sql("INSERT INTO DMT_PROD_TYP ([Prod_Typ_Cd], [Name], [Crt_Dt], [Crt_By]) VALUES ('2', 'Term', GETDATE(), 'SYSTEM')");
            migrationBuilder.Sql("INSERT INTO DMT_PROD_TYP ([Prod_Typ_Cd], [Name], [Crt_Dt], [Crt_By]) VALUES ('3', 'Universal Life', GETDATE(), 'SYSTEM')");
            migrationBuilder.Sql("INSERT INTO DMT_PROD_TYP ([Prod_Typ_Cd], [Name], [Crt_Dt], [Crt_By]) VALUES ('4', 'Variable Universal Life', GETDATE(), 'SYSTEM')");
            migrationBuilder.Sql("INSERT INTO DMT_PROD_TYP ([Prod_Typ_Cd], [Name], [Crt_Dt], [Crt_By]) VALUES ('5', 'Indexed Universal Life', GETDATE(), 'SYSTEM')");
            migrationBuilder.Sql("INSERT INTO DMT_PROD_TYP ([Prod_Typ_Cd], [Name], [Crt_Dt], [Crt_By]) VALUES ('6', 'Interest Sensitive Whole Life', GETDATE(), 'SYSTEM')");
            migrationBuilder.Sql("INSERT INTO DMT_PROD_TYP ([Prod_Typ_Cd], [Name], [Crt_Dt], [Crt_By]) VALUES ('7', 'Variable Whole Life', GETDATE(), 'SYSTEM')");
            migrationBuilder.Sql("INSERT INTO DMT_PROD_TYP ([Prod_Typ_Cd], [Name], [Crt_Dt], [Crt_By]) VALUES ('8', 'Term with Cash Value', GETDATE(), 'SYSTEM')");
            migrationBuilder.Sql("INSERT INTO DMT_PROD_TYP ([Prod_Typ_Cd], [Name], [Crt_Dt], [Crt_By]) VALUES ('9', 'Guarranteed Insurability', GETDATE(), 'SYSTEM')");
            migrationBuilder.Sql("INSERT INTO DMT_PROD_TYP ([Prod_Typ_Cd], [Name], [Crt_Dt], [Crt_By]) VALUES ('10', 'Disability', GETDATE(), 'SYSTEM')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
