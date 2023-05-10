using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Artportable.API.Migrations
{
    public partial class userposts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_likes_artworks_artwork_id",
                table: "likes");

            migrationBuilder.AddColumn<int>(
                name: "post_id",
                table: "likes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "posts",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    content = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_posts", x => x.id);
                    table.ForeignKey(
                        name: "fk_posts_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "tags",
                columns: new[] { "id", "title" },
                values: new object[] { 70, "print" });

            migrationBuilder.InsertData(
                table: "tags",
                columns: new[] { "id", "title" },
                values: new object[] { 71, "jewelry" });

            migrationBuilder.InsertData(
                table: "tags",
                columns: new[] { "id", "title" },
                values: new object[] { 72, "graphic" });

            migrationBuilder.CreateIndex(
                name: "ix_likes_post_id",
                table: "likes",
                column: "post_id");

            migrationBuilder.CreateIndex(
                name: "ix_posts_user_id",
                table: "posts",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "fk_likes_artworks_artwork_id",
                table: "likes",
                column: "artwork_id",
                principalTable: "artworks",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_likes_posts_post_id",
                table: "likes",
                column: "post_id",
                principalTable: "posts",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_likes_artworks_artwork_id",
                table: "likes");

            migrationBuilder.DropForeignKey(
                name: "fk_likes_posts_post_id",
                table: "likes");

            migrationBuilder.DropTable(
                name: "posts");

            migrationBuilder.DropIndex(
                name: "ix_likes_post_id",
                table: "likes");

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
                name: "post_id",
                table: "likes");

            migrationBuilder.AddForeignKey(
                name: "fk_likes_artworks_artwork_id",
                table: "likes",
                column: "artwork_id",
                principalTable: "artworks",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
