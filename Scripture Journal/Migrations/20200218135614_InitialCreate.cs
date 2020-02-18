using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Scripture_Journal.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ScriptureNote",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    EntryDate = table.Column<DateTime>(nullable: false),
                    ScriptureBook = table.Column<string>(nullable: true),
                    ScriptureChapter = table.Column<string>(nullable: true),
                    ScriptureVerse = table.Column<string>(nullable: true),
                    JournalEntry = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScriptureNote", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScriptureNote");
        }
    }
}
