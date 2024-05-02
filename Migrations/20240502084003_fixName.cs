using Microsoft.EntityFrameworkCore.Migrations;

namespace Artportable.API.Migrations
{
    public partial class fixName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "email_receive_artwork_uploaded",
                table: "user_profiles",
                newName: "email_declined_artwork_upload");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "email_declined_artwork_upload",
                table: "user_profiles",
                newName: "email_receive_artwork_uploaded");
        }
    }
}
