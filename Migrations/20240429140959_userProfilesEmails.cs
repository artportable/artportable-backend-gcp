using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Artportable.API.Migrations
{
    public partial class userProfilesEmails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "email_informed_followers_date",
                table: "user_profiles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "email_receive_artwork_uploaded",
                table: "user_profiles",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "email_informed_followers_date",
                table: "user_profiles");

            migrationBuilder.DropColumn(
                name: "email_receive_artwork_uploaded",
                table: "user_profiles");
        }
    }
}
