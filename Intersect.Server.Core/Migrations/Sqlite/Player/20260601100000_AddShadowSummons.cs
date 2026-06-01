using Microsoft.EntityFrameworkCore.Migrations;

namespace Intersect.Server.Migrations.Sqlite.Player;

public partial class AddShadowSummons : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        // TamedShadows stored as a JSON array of Guid strings on the player row
        migrationBuilder.Sql(@"
            ALTER TABLE Players ADD COLUMN TamedShadows TEXT NOT NULL DEFAULT '[]';
        ");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        // SQLite cannot drop columns — recreate the table if a rollback is needed
    }
}
