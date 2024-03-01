using Microsoft.EntityFrameworkCore.Migrations;

namespace Artportable.API.Migrations
{
    public partial class boostUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "boost_user",
                table: "users",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "boost_user",
                table: "users");
        }
    }
}
