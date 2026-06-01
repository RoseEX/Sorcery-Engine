using Microsoft.EntityFrameworkCore.Migrations;

namespace Intersect.Server.Migrations.Sqlite.Game;

public partial class AddDomainExpansionAndParry : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.Sql(@"
        CREATE TABLE IF NOT EXISTS DomainExpansions (
            Id TEXT NOT NULL CONSTRAINT PK_DomainExpansions PRIMARY KEY,
            TimeCreated INTEGER NOT NULL,
            Name TEXT NULL,
            Radius INTEGER NOT NULL DEFAULT 5,
            Duration INTEGER NOT NULL DEFAULT 10000,
            Cooldown INTEGER NOT NULL DEFAULT 60000,
            TrapsEntities INTEGER NOT NULL DEFAULT 1,
            LockedSpellId TEXT NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000',
            DomainPower INTEGER NOT NULL DEFAULT 100,
            OverlayTexture TEXT NULL,
            Icon TEXT NULL,
            Folder TEXT NULL
        );
    ");

        migrationBuilder.Sql(@"
        ALTER TABLE Spells ADD COLUMN DomainExpansionId TEXT NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';
    ");

        migrationBuilder.Sql(@"
        ALTER TABLE Spells ADD COLUMN Unparriable INTEGER NOT NULL DEFAULT 0;
    ");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(name: "DomainExpansionId", table: "Spells");
        migrationBuilder.DropColumn(name: "Unparriable", table: "Spells");
        migrationBuilder.DropTable(name: "DomainExpansions");
    }
}