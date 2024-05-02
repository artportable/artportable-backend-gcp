using Microsoft.EntityFrameworkCore.Migrations;

namespace Artportable.API.Migrations
{
    public partial class emailDecline : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "email_receive_artwork_uploaded",
                table: "users",
                newName: "email_declined_artwork_upload");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "email_declined_artwork_upload",
                table: "users",
                newName: "email_receive_artwork_uploaded");
        }
    }
}
