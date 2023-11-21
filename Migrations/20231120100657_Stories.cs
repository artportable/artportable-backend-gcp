using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Artportable.API.Migrations
{
    public partial class Stories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "stories",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    public_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    title = table.Column<string>(type: "nvarchar(240)", maxLength: 240, nullable: false),
                    description = table.Column<string>(type: "Text", nullable: true),
                    published = table.Column<DateTime>(type: "datetime2", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    primary_file_id = table.Column<int>(type: "int", nullable: false),
                    secondary_file_id = table.Column<int>(type: "int", nullable: true),
                    tertiary_file_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_stories", x => x.id);
                    table.ForeignKey(
                        name: "fk_stories_files_primary_file_id",
                        column: x => x.primary_file_id,
                        principalTable: "files",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_stories_files_secondary_file_id",
                        column: x => x.secondary_file_id,
                        principalTable: "files",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_stories_files_tertiary_file_id",
                        column: x => x.tertiary_file_id,
                        principalTable: "files",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_stories_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            

            migrationBuilder.CreateIndex(
                name: "ix_stories_primary_file_id",
                table: "stories",
                column: "primary_file_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_stories_public_id",
                table: "stories",
                column: "public_id");

            migrationBuilder.CreateIndex(
                name: "ix_stories_secondary_file_id",
                table: "stories",
                column: "secondary_file_id",
                unique: true,
                filter: "[secondary_file_id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "ix_stories_tertiary_file_id",
                table: "stories",
                column: "tertiary_file_id",
                unique: true,
                filter: "[tertiary_file_id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "ix_stories_user_id",
                table: "stories",
                column: "user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "stories");

        }
    }
}
