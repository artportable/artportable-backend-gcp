using Microsoft.EntityFrameworkCore.Migrations;

namespace Artportable.API.Migrations
{
    public partial class countrycity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "city",
                table: "user_profiles",
                type: "nvarchar(140)",
                maxLength: 140,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "country",
                table: "user_profiles",
                type: "nvarchar(140)",
                maxLength: 140,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tags",
                keyColumn: "id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "tags",
                keyColumn: "id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "tags",
                keyColumn: "id",
                keyValue: 72);

            migrationBuilder.DropColumn(
                name: "city",
                table: "user_profiles");

            migrationBuilder.DropColumn(
                name: "country",
                table: "user_profiles");
        }
    }
}
