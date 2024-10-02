using Microsoft.EntityFrameworkCore.Migrations;

namespace Artportable.API.Migrations
{
    public partial class Aaf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "is_aaf",
                table: "artworks",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "is_aaf",
                table: "artworks");
        }
    }
}
