using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Artportable.API.Migrations
{
    public partial class PromotionDaysRemaining : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.AddColumn<int>(
                name: "promotion_days_remaining",
                table: "artworks",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.AddColumn<DateTime>(
                name: "promotion_ends",
                table: "artworks",
                type: "datetime2",
                nullable: true);
        }
    }
}
