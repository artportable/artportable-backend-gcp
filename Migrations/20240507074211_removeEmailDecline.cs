using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Artportable.API.Migrations
{
    public partial class removeEmailDecline : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "email_declined_artwork_upload",
                table: "user_profiles");

            migrationBuilder.DropColumn(
                name: "email_informed_followers_date",
                table: "user_profiles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "email_declined_artwork_upload",
                table: "user_profiles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "email_informed_followers_date",
                table: "user_profiles",
                type: "datetime2",
                nullable: true);
        }
    }
}
