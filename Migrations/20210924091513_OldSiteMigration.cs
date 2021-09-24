using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Artportable.API.Migrations
{
    public partial class OldSiteMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "files",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    width = table.Column<int>(type: "int", nullable: true),
                    height = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_files", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_products", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tags",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tags", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "subscriptions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_id = table.Column<int>(type: "int", nullable: false),
                    customer_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    expiration_date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_subscriptions", x => x.id);
                    table.ForeignKey(
                        name: "fk_subscriptions_products_product_id",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    subscription_id = table.Column<int>(type: "int", nullable: false),
                    file_id = table.Column<int>(type: "int", nullable: true),
                    cover_photo_file_id = table.Column<int>(type: "int", nullable: true),
                    username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                    created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    language = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false, comment: "According to the ISO 639-1 standard")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.id);
                    table.ForeignKey(
                        name: "fk_users_files_cover_photo_file_id",
                        column: x => x.cover_photo_file_id,
                        principalTable: "files",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_users_files_file_id",
                        column: x => x.file_id,
                        principalTable: "files",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_users_subscriptions_subscription_id",
                        column: x => x.subscription_id,
                        principalTable: "subscriptions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "artworks",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    public_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    primary_file_id = table.Column<int>(type: "int", nullable: false),
                    secondary_file_id = table.Column<int>(type: "int", nullable: true),
                    tertiary_file_id = table.Column<int>(type: "int", nullable: true),
                    title = table.Column<string>(type: "nvarchar(240)", maxLength: 240, nullable: true),
                    description = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: true),
                    published = table.Column<DateTime>(type: "datetime2", nullable: false),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_artworks", x => x.id);
                    table.ForeignKey(
                        name: "fk_artworks_files_primary_file_id",
                        column: x => x.primary_file_id,
                        principalTable: "files",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_artworks_files_secondary_file_id",
                        column: x => x.secondary_file_id,
                        principalTable: "files",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_artworks_files_tertiary_file_id",
                        column: x => x.tertiary_file_id,
                        principalTable: "files",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_artworks_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "connections",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    follower_id = table.Column<int>(type: "int", nullable: false),
                    followee_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_connections", x => x.id);
                    table.ForeignKey(
                        name: "fk_connections_users_followee_id",
                        column: x => x.followee_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_connections_users_follower_id",
                        column: x => x.follower_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "user_profiles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(140)", maxLength: 140, nullable: false),
                    surname = table.Column<string>(type: "nvarchar(140)", maxLength: 140, nullable: true),
                    date_of_birth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    location = table.Column<string>(type: "nvarchar(280)", maxLength: 280, nullable: true),
                    title = table.Column<string>(type: "nvarchar(140)", maxLength: 140, nullable: true),
                    headline = table.Column<string>(type: "nvarchar(140)", maxLength: 140, nullable: true),
                    about = table.Column<string>(type: "Text", nullable: true),
                    inspired_by = table.Column<string>(type: "Text", nullable: true),
                    studio_text = table.Column<string>(type: "nvarchar(280)", maxLength: 280, nullable: true),
                    studio_location = table.Column<string>(type: "nvarchar(140)", maxLength: 140, nullable: true),
                    website = table.Column<string>(type: "nvarchar(280)", maxLength: 280, nullable: true),
                    instagram_url = table.Column<string>(type: "nvarchar(280)", maxLength: 280, nullable: true),
                    facebook_url = table.Column<string>(type: "nvarchar(280)", maxLength: 280, nullable: true),
                    linked_in_url = table.Column<string>(type: "nvarchar(280)", maxLength: 280, nullable: true),
                    behance_url = table.Column<string>(type: "nvarchar(280)", maxLength: 280, nullable: true),
                    dribble_url = table.Column<string>(type: "nvarchar(280)", maxLength: 280, nullable: true),
                    technique = table.Column<string>(type: "Text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_profiles", x => x.id);
                    table.ForeignKey(
                        name: "fk_user_profiles_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "artwork_tag",
                columns: table => new
                {
                    artworks_id = table.Column<int>(type: "int", nullable: false),
                    tags_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_artwork_tag", x => new { x.artworks_id, x.tags_id });
                    table.ForeignKey(
                        name: "fk_artwork_tag_artworks_artworks_id",
                        column: x => x.artworks_id,
                        principalTable: "artworks",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_artwork_tag_tags_tags_id",
                        column: x => x.tags_id,
                        principalTable: "tags",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "likes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    artwork_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_likes", x => x.id);
                    table.ForeignKey(
                        name: "fk_likes_artworks_artwork_id",
                        column: x => x.artwork_id,
                        principalTable: "artworks",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_likes_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "educations",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_profile_id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "Text", nullable: true),
                    from = table.Column<int>(type: "int", nullable: true),
                    to = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_educations", x => x.id);
                    table.ForeignKey(
                        name: "fk_educations_user_profiles_user_profile_id",
                        column: x => x.user_profile_id,
                        principalTable: "user_profiles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "exhibitions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_profile_id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "Text", nullable: true),
                    place = table.Column<string>(type: "nvarchar(140)", maxLength: 140, nullable: true),
                    from = table.Column<DateTime>(type: "Date", nullable: true),
                    to = table.Column<DateTime>(type: "Date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_exhibitions", x => x.id);
                    table.ForeignKey(
                        name: "fk_exhibitions_user_profiles_user_profile_id",
                        column: x => x.user_profile_id,
                        principalTable: "user_profiles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "Bas" },
                    { 2, "Portfolio" },
                    { 3, "Portfolio Premium" }
                });

            migrationBuilder.InsertData(
                table: "tags",
                columns: new[] { "id", "title" },
                values: new object[,]
                {
                    { 49, "seasons" },
                    { 48, "big-city" },
                    { 47, "water" },
                    { 46, "politics" },
                    { 45, "places" },
                    { 44, "figurative" },
                    { 42, "pop-culture" },
                    { 50, "cats" },
                    { 41, "celebrity" },
                    { 40, "pattern" },
                    { 39, "fantasy" },
                    { 38, "flowers" },
                    { 37, "geometric" },
                    { 43, "minimalism" },
                    { 51, "dogs" },
                    { 53, "travel" },
                    { 36, "fashion" },
                    { 67, "group-exhibition" },
                    { 66, "gallery" },
                    { 65, "art-exhibition" },
                    { 64, "mural" },
                    { 63, "installation" },
                    { 62, "triptych" },
                    { 52, "nude" },
                    { 61, "performance-art" },
                    { 59, "illustration" },
                    { 58, "digital" },
                    { 57, "sculpture" },
                    { 56, "photography" },
                    { 55, "seascape" },
                    { 54, "food-drink" },
                    { 60, "video-art" },
                    { 35, "nature" },
                    { 33, "drawing" },
                    { 68, "posters" },
                    { 14, "abstract" },
                    { 13, "impressionism" },
                    { 12, "ink" },
                    { 11, "gouache" }
                });

            migrationBuilder.InsertData(
                table: "tags",
                columns: new[] { "id", "title" },
                values: new object[,]
                {
                    { 10, "textile" },
                    { 9, "glass" },
                    { 15, "realism" },
                    { 8, "clay" },
                    { 6, "pencil" },
                    { 5, "ceramic" },
                    { 4, "mixed-media" },
                    { 3, "aquarelle" },
                    { 2, "acrylic" },
                    { 1, "oil" },
                    { 7, "charcoal" },
                    { 34, "architecture" },
                    { 16, "surrealism" },
                    { 18, "cubism" },
                    { 32, "collage" },
                    { 31, "animal" },
                    { 30, "pastel" },
                    { 29, "landscape" },
                    { 28, "still-life" },
                    { 27, "street-art" },
                    { 17, "expressionism" },
                    { 26, "conceptual" },
                    { 24, "portraiture" },
                    { 23, "graffiti" },
                    { 22, "abstract-expressionism" },
                    { 21, "photorealism" },
                    { 20, "documentary-photography" },
                    { 19, "pop-art" },
                    { 25, "arts-craft" },
                    { 69, "artwork" }
                });

            migrationBuilder.CreateIndex(
                name: "ix_artwork_tag_tags_id",
                table: "artwork_tag",
                column: "tags_id");

            migrationBuilder.CreateIndex(
                name: "ix_artworks_primary_file_id",
                table: "artworks",
                column: "primary_file_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_artworks_secondary_file_id",
                table: "artworks",
                column: "secondary_file_id",
                unique: true,
                filter: "[secondary_file_id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "ix_artworks_tertiary_file_id",
                table: "artworks",
                column: "tertiary_file_id",
                unique: true,
                filter: "[tertiary_file_id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "ix_artworks_user_id",
                table: "artworks",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_connections_followee_id",
                table: "connections",
                column: "followee_id");

            migrationBuilder.CreateIndex(
                name: "ix_connections_follower_id",
                table: "connections",
                column: "follower_id");

            migrationBuilder.CreateIndex(
                name: "ix_educations_user_profile_id",
                table: "educations",
                column: "user_profile_id");

            migrationBuilder.CreateIndex(
                name: "ix_exhibitions_user_profile_id",
                table: "exhibitions",
                column: "user_profile_id");

            migrationBuilder.CreateIndex(
                name: "ix_likes_artwork_id",
                table: "likes",
                column: "artwork_id");

            migrationBuilder.CreateIndex(
                name: "ix_likes_user_id",
                table: "likes",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_subscriptions_product_id",
                table: "subscriptions",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "ix_user_profiles_user_id",
                table: "user_profiles",
                column: "user_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_users_cover_photo_file_id",
                table: "users",
                column: "cover_photo_file_id");

            migrationBuilder.CreateIndex(
                name: "ix_users_file_id",
                table: "users",
                column: "file_id");

            migrationBuilder.CreateIndex(
                name: "ix_users_subscription_id",
                table: "users",
                column: "subscription_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_users_username",
                table: "users",
                column: "username",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "artwork_tag");

            migrationBuilder.DropTable(
                name: "connections");

            migrationBuilder.DropTable(
                name: "educations");

            migrationBuilder.DropTable(
                name: "exhibitions");

            migrationBuilder.DropTable(
                name: "likes");

            migrationBuilder.DropTable(
                name: "tags");

            migrationBuilder.DropTable(
                name: "user_profiles");

            migrationBuilder.DropTable(
                name: "artworks");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "files");

            migrationBuilder.DropTable(
                name: "subscriptions");

            migrationBuilder.DropTable(
                name: "products");
        }
    }
}
