using Microsoft.EntityFrameworkCore.Migrations;

namespace Intersect.Server.Migrations.Sqlite.Game;

public partial class AddShadowSummonDescriptors : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.Sql(@"
            CREATE TABLE IF NOT EXISTS ShadowSummons (
                Id             TEXT    NOT NULL CONSTRAINT PK_ShadowSummons PRIMARY KEY,
                TimeCreated    INTEGER NOT NULL,
                Name           TEXT    NULL,
                ShadowType     INTEGER NOT NULL DEFAULT 0,
                SummonNpcId    TEXT    NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000',
                SummonCost     INTEGER NOT NULL DEFAULT 20,
                MaxActive      INTEGER NOT NULL DEFAULT 1,
                PermanentDeath INTEGER NOT NULL DEFAULT 0,
                Icon           TEXT    NULL,
                Description    TEXT    NULL,
                Folder         TEXT    NULL
            );
        ");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable("ShadowSummons");
    }
}
