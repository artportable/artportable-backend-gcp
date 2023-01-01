using Microsoft.EntityFrameworkCore.Migrations;

namespace Artportable.API.Migrations
{
    public partial class Artworks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
             migrationBuilder.AddColumn<string>(
                name: "currency",
                table: "artworks",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "currency",
                table: "artworks",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: true);
        }
    }
}
