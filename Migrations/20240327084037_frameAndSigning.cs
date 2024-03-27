using Microsoft.EntityFrameworkCore.Migrations;

namespace Artportable.API.Migrations
{
    public partial class frameAndSigning : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "frame_included",
                table: "artworks",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "signed_by_artist",
                table: "artworks",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "frame_included",
                table: "artworks");

            migrationBuilder.DropColumn(
                name: "signed_by_artist",
                table: "artworks");
        }
    }
}
