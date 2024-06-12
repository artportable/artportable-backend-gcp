using Microsoft.EntityFrameworkCore.Migrations;

namespace Artportable.API.Migrations
{
    public partial class userProfileDesign : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "chosen_corners",
                table: "user_profiles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "chosen_font",
                table: "user_profiles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "chosen_frame",
                table: "user_profiles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "chosen_layout",
                table: "user_profiles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "chosen_shadow",
                table: "user_profiles",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "chosen_corners",
                table: "user_profiles");

            migrationBuilder.DropColumn(
                name: "chosen_font",
                table: "user_profiles");

            migrationBuilder.DropColumn(
                name: "chosen_frame",
                table: "user_profiles");

            migrationBuilder.DropColumn(
                name: "chosen_layout",
                table: "user_profiles");

            migrationBuilder.DropColumn(
                name: "chosen_shadow",
                table: "user_profiles");
        }
    }
}
