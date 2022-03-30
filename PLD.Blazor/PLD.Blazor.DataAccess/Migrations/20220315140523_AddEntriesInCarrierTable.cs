using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PLD.Blazor.DataAccess.Migrations
{
    public partial class AddEntriesInCarrierTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO DMT_CARR ( [CARR_CD], [Name], [CRT_DT],[CRT_BY], [MOD_DT],[MOD_BY]) VALUES( 'AIG', 'AIG', GETDATE(), 'SYSTEM', NULL, NULL )");
            migrationBuilder.Sql("INSERT INTO DMT_CARR ( [CARR_CD], [Name], [CRT_DT],[CRT_BY], [MOD_DT],[MOD_BY]) VALUES( 'JH', 'John Hancock', GETDATE(), 'SYSTEM', NULL, NULL )");
            migrationBuilder.Sql("INSERT INTO DMT_CARR ( [CARR_CD], [Name], [CRT_DT],[CRT_BY], [MOD_DT],[MOD_BY]) VALUES( 'LIN', 'Lincoln', GETDATE(), 'SYSTEM', NULL, NULL )");
            migrationBuilder.Sql("INSERT INTO DMT_CARR ( [CARR_CD], [Name], [CRT_DT],[CRT_BY], [MOD_DT],[MOD_BY]) VALUES( 'PAC', 'Pacific Life', GETDATE(), 'SYSTEM', NULL, NULL )");
            migrationBuilder.Sql("INSERT INTO DMT_CARR ( [CARR_CD], [Name], [CRT_DT],[CRT_BY], [MOD_DT],[MOD_BY]) VALUES( 'PROT', 'Protective', GETDATE(), 'SYSTEM', NULL, NULL )");
            migrationBuilder.Sql("INSERT INTO DMT_CARR ( [CARR_CD], [Name], [CRT_DT],[CRT_BY], [MOD_DT],[MOD_BY]) VALUES( 'MM', 'Mass Mutual', GETDATE(), 'SYSTEM', NULL, NULL )");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
