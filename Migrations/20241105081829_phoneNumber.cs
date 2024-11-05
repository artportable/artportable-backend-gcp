using Microsoft.EntityFrameworkCore.Migrations;

namespace Artportable.API.Migrations
{
    public partial class phoneNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "phone_number",
                table: "users",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "phone_number",
                table: "users");
        }
    }
}
